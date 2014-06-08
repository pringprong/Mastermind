using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mastermind
{
    public partial class MastermindMainWindow : Form
    {
        private int numberOfColours;
        private int numberOfSpaces;
        private bool repeatsAllowed;
        private int totalSolutions;
        private int totalSolutionsWithRepeats;
        private int numPossibleSolutions;
        private int numberOfAllowedGuesses = 12;
        private int maxNumberOfColors = 13;
        //private MastermindColorChooser colorChooser;
        private DataGridViewCell selectedCell;
        private int numberOfGuesses = 0;
        private Color backgroundColor = Color.Ivory;
        //private Color selectionBackgroundColor = Color.Magenta;
        private List<Guess> allSolutions;
        private possibleSolutionsForm possibleSolutions;
        private Guess solution;
        private Random rnd;
        private Guess currentGuess;
        private Color rightColorRightPlaceMarker = Color.Black;
        private Color rightColorWrongPlaceMarker = Color.LightGray;
        private List<Guess> guessHistory;
        private Color[] colorArray;
        private Color[] guessInProgress;

        public MastermindMainWindow()
        {
            InitializeComponent();
            numberOfColours = 5;
            numberOfColorsUpDown.Value = 5;
            numberOfColorsUpDown.Maximum = maxNumberOfColors;
            repeatsAllowed = true;
            repeatsAllowedCheckbox.Checked = true;
            repeatsAllowedDisplayCheckbox.Checked = true;
            numberOfSpaces = 3;
            numberOfSpacesUpDown.Value = 3;
           
            calculateTotalSolutions();
            guessHistoryDGV.Hide();
            //guessHistoryDGV.BackgroundColor = backgroundColor;
            cluesDGV.Hide();
            repeatsAllowedDisplayCheckbox.Hide();
            submit.Hide();
            solutionDataGridView.Hide();
            showSolutions.Hide();
            possibleSolutions = new possibleSolutionsForm();
            possibleSolutions.Hide();
            checkGuessButton.Hide();
            checkGuessResult.Hide();
            colorDataGridView.Hide();
            rnd = new Random();
            // make sure none of these are the same color as backgroundColor
            colorArray = new Color[maxNumberOfColors];
            colorArray[0] = Color.Red;
            colorArray[1] = Color.Blue;
            colorArray[2] = Color.Green;
            colorArray[3] = Color.Yellow;
            colorArray[4] = Color.Orange;
            colorArray[5] = Color.Purple;
            colorArray[6] = Color.Brown;
            colorArray[7] = Color.Magenta;
            colorArray[8] = Color.Cyan;
            colorArray[9] = Color.Pink;
            colorArray[10] = Color.DarkGray;
            colorArray[11] = Color.Black;
            colorArray[12] = Color.Tan;
        }

        private void calculateTotalSolutions()
        {
            totalSolutions = 1;
            totalSolutionsWithRepeats = 1;
            int tempColours = numberOfColours;
            for (int i = 0; i < numberOfSpaces; i++)
            {
                totalSolutions = totalSolutions * tempColours;
                if (!repeatsAllowed)
                    tempColours--;
                totalSolutionsWithRepeats = totalSolutionsWithRepeats * numberOfColours;
            }
            label2.Text = Convert.ToString(totalSolutions);
            label4.Text = label2.Text;
        }

        private void newGame()
        {
            numberOfGuesses = 0;
            guessHistoryDGV.RowCount = numberOfAllowedGuesses;
            guessHistoryDGV.ColumnCount = numberOfSpaces;
            foreach (DataGridViewColumn c in guessHistoryDGV.Columns)
            {
                c.Width = guessHistoryDGV.Width / guessHistoryDGV.ColumnCount;
                for (int i = 0; i < numberOfAllowedGuesses; i++)
                {
                    guessHistoryDGV[c.Index, i].Style.BackColor = backgroundColor;
                    guessHistoryDGV[c.Index, i].Style.SelectionBackColor = backgroundColor;
                }
            }
            foreach (DataGridViewRow r in guessHistoryDGV.Rows)
            {
                r.Height = guessHistoryDGV.Height / guessHistoryDGV.RowCount;
            }
            //selectedCell = guessHistoryDGV[0, numberOfAllowedGuesses - 1];
            //guessHistoryDGV.Show();

            cluesDGV.RowCount = numberOfAllowedGuesses;
            cluesDGV.ColumnCount = numberOfSpaces;
            foreach (DataGridViewColumn c in cluesDGV.Columns)
            {
                c.Width = cluesDGV.Width / cluesDGV.ColumnCount;
                for (int i = 0; i < numberOfAllowedGuesses; i++)
                {
                    cluesDGV[c.Index, i].Style.BackColor = backgroundColor;
                    cluesDGV[c.Index, i].Style.SelectionBackColor = backgroundColor;
                }
            }
            foreach (DataGridViewRow r in cluesDGV.Rows)
            {
                r.Height = cluesDGV.Height / cluesDGV.RowCount;
            }
            cluesDGV.Show();

            solutionDataGridView.RowCount = 1;
            solutionDataGridView.ColumnCount = numberOfSpaces;
            foreach (DataGridViewColumn c in solutionDataGridView.Columns)
            {
                c.Width = solutionDataGridView.Width / solutionDataGridView.ColumnCount;
                solutionDataGridView[c.Index, 0].Style.BackColor = backgroundColor;
                solutionDataGridView[c.Index, 0].Style.SelectionBackColor = backgroundColor;
            }
            foreach (DataGridViewRow r in solutionDataGridView.Rows)
            {
                r.Height = solutionDataGridView.Height / solutionDataGridView.RowCount;
            }

            // initialize the list of possible colors and guess history grid
            guessHistory = new List<Guess>();

            colorDataGridView.RowCount = 1;
            colorDataGridView.ColumnCount = numberOfColours;
            foreach(DataGridViewColumn c in colorDataGridView.Columns)
            {
                c.Width = colorDataGridView.Width / colorDataGridView.ColumnCount;
                colorDataGridView[c.Index, 0].Style.BackColor = colorArray[c.Index];
                colorDataGridView[c.Index, 0].Style.SelectionBackColor = colorArray[c.Index];
            }
            foreach (DataGridViewRow r in colorDataGridView.Rows)
            {
                r.Height = colorDataGridView.Height / colorDataGridView.RowCount;
            }

            guessInProgress = new Color[numberOfSpaces];
            for (int i = 0; i < numberOfSpaces; i++ )
            {
                guessInProgress[i] = backgroundColor;
            }

            // initialize the list of possible solutions
            allSolutions = new List<Guess>();
            int factor;
            //int current_guess_index = 0;
            for (int i = 0; i < totalSolutionsWithRepeats; i++)
            {
                Guess newGuess = new Guess(numberOfSpaces);
                factor = 1;
                for (int j = numberOfSpaces-1; j >= 0; j--)
                    {
                    double d = i / factor;
                    int mod = Convert.ToInt32(Math.Floor(d));
                    int color_index = mod % numberOfColours;
                    if (!repeatsAllowed)
                    {
                        for (int k = numberOfSpaces - 1; k > j; k--)
                        {
                            // need to go to next i because this color already exists in this guess
                            if (newGuess.getColor(k) == colorArray[color_index])
                                goto newI;
                        }
                    }
                    newGuess.setColor(j, colorArray[color_index]);
                    factor = factor * numberOfColours;
                }
                allSolutions.Add(newGuess);
                newI: ; // skipped combinations (due to repeats not being allowed) jump to here
             }

            // pick one of the solutions as The Solution
            int solutionIndex = rnd.Next(0, totalSolutions);
            solution = allSolutions.ElementAt(solutionIndex);

            // show and hide the appropriate items
            label4.Text = label2.Text; 
            submit.Enabled = true;
            submit.Show();
            solutionDataGridView.Show();
            showSolutions.Show();
            repeatsAllowedDisplayCheckbox.Show();
            panel3.Hide();
            checkGuessButton.Show();
            checkGuessResult.Show();
            //selectCell(1, numberOfAllowedGuesses - 1);
            guessHistoryDGV.Show();
            guessHistoryDGV.Hide();
            guessHistoryDGV.Show();
            colorDataGridView.Show();
            selectCell(0, numberOfAllowedGuesses - 1);
            guessHistoryDGV.Invalidate();
        }
  
        private void newGameButton_Click(object sender, EventArgs e)
        {
            newGame();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            bool canContinue = checkSubmission();
            if (canContinue)
                submitGuess();
        }

        private bool checkSubmission()
        {
            // check for empty cells
            for (int i = 0; i < numberOfSpaces; i++)
            {
                if (guessInProgress[i] == backgroundColor)
                {
                    MessageBox.Show("Submission contains empty cells");
                    return false;
                }
            }
            return true;
        }

        private void selectCell(int column, int row)
        {
            if (selectedCell != null)
            {
                DataGridViewCell oldcell = selectedCell;
                selectedCell = guessHistoryDGV[column, row];
                guessHistoryDGV.InvalidateCell(oldcell);
                guessHistoryDGV.InvalidateCell(selectedCell);
            }
            else
            {
                selectedCell = guessHistoryDGV[column, row];
                guessHistoryDGV.InvalidateCell(selectedCell);

            }
            guessHistoryDGV.Invalidate();
        }

        private void submitGuess()
        {
            checkGuessResult.Text = "";
            // initialize currentGuess
            int guessHistoryRowNumber = numberOfAllowedGuesses - 1 - numberOfGuesses;
            currentGuess = new Guess(numberOfSpaces);
            for (int i = 0; i < numberOfSpaces; i++)
            {
                currentGuess.setColor(i, guessInProgress[i]);
                guessInProgress[i] = backgroundColor;
            }

            // get results of guess
            int[] guessResult = solution.compare(currentGuess);
            int rightColorRightPlace = guessResult[0];
            int rightColorWrongPlace = guessResult[1];
            int j = 0;
            for (int k = 0; k < rightColorRightPlace; k++)
            {
                cluesDGV[j, guessHistoryRowNumber].Style.BackColor = rightColorRightPlaceMarker;
                cluesDGV[j, guessHistoryRowNumber].Style.SelectionBackColor = rightColorRightPlaceMarker;
                j++;
            }
            for (int k = 0; k < rightColorWrongPlace; k++)
            {
                cluesDGV[j, guessHistoryRowNumber].Style.BackColor = rightColorWrongPlaceMarker;
                cluesDGV[j, guessHistoryRowNumber].Style.SelectionBackColor = rightColorWrongPlaceMarker;
                j++;
            }
            currentGuess.setRightColorRightPlace(rightColorRightPlace);
            currentGuess.setRightColorWrongPlace(rightColorWrongPlace);
            
                // update possibleSolutions
            guessHistory.Add(currentGuess);
            List<Guess> toRemove = new List<Guess>();
            int[] results;
            foreach (Guess g in allSolutions)
            {
                results = g.compare(currentGuess);
                if (results[0] != currentGuess.getRightColorRightPlace() || results[1] != currentGuess.getRightColorWrongPlace())
                    toRemove.Add(g);
            }
            foreach (Guess g in toRemove)
            {
                allSolutions.Remove(g);
            }

            numPossibleSolutions = allSolutions.Count();
            label4.Text = numPossibleSolutions.ToString();
            // end of game
            if (rightColorRightPlace == numberOfSpaces || numberOfGuesses == numberOfAllowedGuesses-1)
            {
                revealSolution();
                submit.Enabled = false;
                if (rightColorRightPlace != numberOfSpaces)
                {
                    MessageBox.Show("Better luck next time.");
                }
                else
                {
                    MessageBox.Show("You win!");
                }
                panel3.Show();
            }
            numberOfGuesses++;
            selectCell(0, numberOfAllowedGuesses - numberOfGuesses - 1);
        }

        private void showSolutions_Click(object sender, EventArgs e)
        {
            possibleSolutions.update(numberOfSpaces, allSolutions);
            possibleSolutions.Show();
            possibleSolutions.Location = new Point(this.Location.X + this.Width, this.Location.Y);
        }

        private void revealSolution()
        {
            for (int i = 0; i < numberOfSpaces; i++)
            {
                DataGridViewCell cell = solutionDataGridView[i, 0];
                cell.Style.BackColor = solution.getColor(i);
                cell.Style.SelectionBackColor = solution.getColor(i);
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void repeatsAllowedCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)sender;
            repeatsAllowed = c.Checked;
            repeatsAllowedDisplayCheckbox.Checked = c.Checked;
            calculateTotalSolutions();
        }

        private void numberOfColorsUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown n = (NumericUpDown)sender;
            numberOfColours = Convert.ToInt32(n.Value);
            calculateTotalSolutions();
        }

        private void numberOfSpacesUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown n = (NumericUpDown)sender;
            numberOfSpaces = Convert.ToInt32(n.Value);
            calculateTotalSolutions();
        }

        private void checkGuessButton_Click(object sender, EventArgs e)
        {
            Guess thisGuess = new Guess(numberOfSpaces);

            // check for empty cells
            for (int i = 0; i < numberOfSpaces; i++)
            {
                if(guessInProgress[i] == backgroundColor)
                {
                    checkGuessResult.Text = "Submission contains empty cells";
                    return;
                }
            }
            // check for repeated colors
            if (!repeatsAllowed)
            {
                Color[] colorRepeatCheck = new Color[numberOfSpaces];
                int j = 0;
                for (int i = 0; i < numberOfSpaces; i++)
                {
                    for (int k = 0; k < j; k++)
                    {
                        if (colorRepeatCheck[k] == guessInProgress[i])
                        {
                            checkGuessResult.Text = "Submission contains repeated colours, which are currently not allowed";
                            return;
                        }
                    }
                    colorRepeatCheck[j] = guessInProgress[i];
                    j++;
                }
            } 

            int[] results = new int[2];
            for (int i = 0; i < numberOfSpaces; i++)
            {
                thisGuess.setColor(i, guessInProgress[i]);
            }
            int m = 1;
            foreach (Guess g in guessHistory)
            {
                results = g.compare(thisGuess);
                if (results[0] != g.getRightColorRightPlace())
                {
                    checkGuessResult.Text = "No match: Right Color Right Place, guess " + m + ".";
                    return;
                }
                else if (results[1] != g.getRightColorWrongPlace())
                {
                    checkGuessResult.Text = "No match: Right Color Wrong Place, guess number " + m + ".";
                    return;
                }
                m++;
            }
            checkGuessResult.Text = "OK!";
        }

        private void guessHistoryDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell clickedCell = guessHistoryDGV.CurrentCell;
            if (clickedCell.RowIndex == numberOfAllowedGuesses - numberOfGuesses - 1)
            {
                selectCell(clickedCell.ColumnIndex, clickedCell.RowIndex);
            }

        }

        private void guessHistoryDGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Ivory);
            System.Drawing.Pen p = new Pen(Brushes.Black);
            Rectangle bigr = new Rectangle(e.CellBounds.X + 2, e.CellBounds.Y + 8, e.CellBounds.Width - 10, e.CellBounds.Height - 15);
            Rectangle smallr = new Rectangle(e.CellBounds.X + 4, e.CellBounds.Y + 10, e.CellBounds.Width - 14, e.CellBounds.Height - 19);
            Rectangle highlightr = new Rectangle(e.CellBounds.X + 6, e.CellBounds.Y + 12, e.CellBounds.Width - 18, e.CellBounds.Height - 23);
            e.Graphics.FillEllipse(myBrush, smallr);
            e.Graphics.DrawEllipse(p, bigr);
            if (e.RowIndex == numberOfAllowedGuesses-1-numberOfGuesses)
            {
                myBrush = new SolidBrush(guessInProgress[e.ColumnIndex]);
            }
            else if (e.RowIndex > numberOfAllowedGuesses -1 - numberOfGuesses)
            {
                int guessHistoryIndex = numberOfAllowedGuesses - e.RowIndex -1 ;
                Guess guessAtRow = guessHistory.ElementAt(guessHistoryIndex);
                myBrush = new SolidBrush(guessAtRow.getColor(e.ColumnIndex));
            }
            e.Graphics.FillEllipse(myBrush, smallr);

            if (e.ColumnIndex == selectedCell.ColumnIndex && e.RowIndex == selectedCell.RowIndex) 
            {
                e.Graphics.DrawEllipse(Pens.Fuchsia, highlightr);
                //e.PaintBackground(e.ClipBounds, true);
                //e.Paint(e.ClipBounds, (DataGridViewPaintParts.ContentForeground | DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentBackground));
            }
            e.PaintContent(e.ClipBounds);
            e.Handled = true;
            myBrush.Dispose();
            p.Dispose();

        }

        private void colorDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (selectedCell != null)
            {
                selectedCell.Style.BackColor = colorArray[e.ColumnIndex];
                selectedCell.Style.SelectionBackColor = colorArray[e.ColumnIndex];
                guessInProgress[selectedCell.ColumnIndex] = colorArray[e.ColumnIndex];
                incrementSelection();
            }
        }

        private void incrementSelection()
        {
            if (selectedCell == null)
            {
                selectedCell = guessHistoryDGV[0, numberOfAllowedGuesses - 1 - numberOfGuesses];
            }
            else if (selectedCell.ColumnIndex == numberOfSpaces-1)
            {
                selectedCell = guessHistoryDGV[0, selectedCell.RowIndex];
            }
            else
            {
                selectedCell = guessHistoryDGV[selectedCell.ColumnIndex + 1, selectedCell.RowIndex];
            }
            guessHistoryDGV.Invalidate();
        }

        private void colorDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (selectedCell != null)
            {
                //selectedCell.Style.BackColor = colorArray[e.ColumnIndex];
                //selectedCell.Style.SelectionBackColor = colorArray[e.ColumnIndex];
                guessInProgress[selectedCell.ColumnIndex] = colorArray[e.ColumnIndex];
                incrementSelection();

            }
        }

        private void guessHistoryDGV_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts = DataGridViewPaintParts.Background | DataGridViewPaintParts.Border;
            e.PaintCells(e.ClipBounds, e.PaintParts);
            e.Handled = true;
          /*  Rectangle borderRect = new Rectangle(e.RowBounds.X, e.RowBounds.Y, e.RowBounds.Width - 1, e.RowBounds.Height - 1);

            {
                if ((e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
                {
                    using (LinearGradientBrush lgb = new LinearGradientBrush(e.RowBounds, ProfessionalColors.ToolStripGradientMiddle, ProfessionalColors.ToolStripContentPanelGradientBegin, 90F))
                    {
                        using (Pen p = new Pen(ProfessionalColors.ButtonPressedBorder))
                        {
                            e.Graphics.FillRectangle(lgb, borderRect);
                            e.Graphics.DrawRectangle(p, borderRect);
                        }
                    }
                }
                else
                {
                    using (LinearGradientBrush lgb = new LinearGradientBrush(e.RowBounds, ProfessionalColors.ToolStripContentPanelGradientEnd, ProfessionalColors.ToolStripContentPanelGradientBegin, 0F))
                    {
                        e.Graphics.FillRectangle(lgb, e.RowBounds);
                    }
                }
            }*/
        }
    }

    public class Guess
    {
        private Color[] colors;
        private int numSpaces;
        private Color default_color = Color.WhiteSmoke;
        private int rightColorRightPlace;
        private int rightColorWrongPlace;

        Guess() 
        {
            numSpaces = 0;
        }

        public Guess(int num)
        {
            numSpaces = num;
            colors = new Color[numSpaces];
        }

        public Guess(Color[] color_array)
        {
            colors = color_array;
            numSpaces = colors.Length;
        }

        public Color getColor(int n)
        {
            if (n < numSpaces) return colors[n];
            else return default_color;
        }

        public int getNumSpaces()
        {
            return numSpaces;
        }

        public void setColor(int n, Color c)
        {
            if (n < numSpaces) colors[n] = c;
        }

        public String toString()
        {
            String outString = "";
            for (int i = 0; i < numSpaces; i++) 
            {
                outString = outString + colors[i].Name + " ";
            }
            return outString;
        }

        public bool isSame(Guess g)
        {
            if (g.getNumSpaces() != this.numSpaces)
                return false;
            bool sameColors = true;
            for (int i = 0; i < numSpaces; i++)
            {
                if (g.getColor(i) != this.getColor(i))
                    sameColors = false;
            }
            return sameColors;
        }

        public bool isSameNumSpaces(Guess g)
        {
            return g.getNumSpaces() == this.numSpaces;
        }

        public int[] compare(Guess g)
        {
            int[] result = new int[2];
            result[0] = 0;
            result[1] = 0;
            if (g.getNumSpaces() != this.numSpaces)
            {
                MessageBox.Show("comparing two guess with different numbers of spaces.");
                return result;
            }
 
            // count same color same place
            for (int i = 0; i < numSpaces; i++)
            {
                if(g.getColor(i) == getColor(i))
                {
                    result[0] = result[0] + 1;
                }
            }

            // count same color different place
            // for this we need to get the intersection of the two color arrays
            // keeping duplicates
            // got this from http://stackoverflow.com/questions/5011948/how-do-i-do-an-integer-list-intersection-while-keeping-duplicates
            ILookup<Color, Color> lookup1 = colors.ToLookup(i => i);
            List<Color> tempOther = new List<Color>();
            for (int i = 0; i < numSpaces; i++)
            {
                tempOther.Add(g.getColor(i));
            }
            ILookup<Color, Color> lookup2 = tempOther.ToLookup(i => i);
            Color[] intersection =  (
                 from group1 in lookup1
                   let group2 = lookup2[group1.Key]
                     where group2.Any()
                       let smallerGroup = group1.Count() < group2.Count() ? group1 : group2
                         from i in smallerGroup
                           select i
                           ).ToArray();
            result[1] = intersection.Count() - result[0];
            return result;
        }

        public void setRightColorRightPlace(int i)
        {
            rightColorRightPlace = i;
        }

        public int getRightColorRightPlace()
        {
            return rightColorRightPlace;
        }

        public void setRightColorWrongPlace(int i)
        {
            rightColorWrongPlace = i;
        }

        public int getRightColorWrongPlace()
        {
            return rightColorWrongPlace;
        }
    }
}
