using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

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
        private System.Drawing.Color backgroundColor = System.Drawing.Color.Ivory;
        private System.Drawing.Color selectionBackgroundColor = System.Drawing.Color.Fuchsia;
        private List<Guess> allSolutions;
        private possibleSolutionsForm possibleSolutions;
        private Guess solution;
        private Random rnd;
        private Guess currentGuess;
        private System.Drawing.Color rightColorRightPlaceMarker = System.Drawing.Color.Black;
        private System.Drawing.Color rightColorWrongPlaceMarker = System.Drawing.Color.White;
        private List<Guess> guessHistory;
        private System.Drawing.Color[] colorArray;
        private System.Drawing.Color[] guessInProgress;
        private bool revealSolution = false;
        private int rowHeight = 0;

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
            guessHistoryDGV.BackgroundColor = backgroundColor;
            cluesDGV.Hide();
            cluesDGV.BackgroundColor = backgroundColor;
            repeatsAllowedDisplayCheckbox.Hide();
            submit.Hide();
            solutionDGV.Hide();
            solutionDGV.BackgroundColor = backgroundColor;
            showSolutions.Hide();
            possibleSolutions = new possibleSolutionsForm();
            possibleSolutions.Hide();
            checkGuessButton.Hide();
            checkGuessResult.Hide();
            colorDataGridView.Hide();
            colorDataGridView.BackgroundColor = backgroundColor;
            rnd = new Random();
            // make sure none of these are the same color as backgroundColor
            colorArray = new System.Drawing.Color[maxNumberOfColors];
            colorArray[0] = System.Drawing.Color.Red;
            colorArray[1] = System.Drawing.Color.Blue;
            colorArray[2] = System.Drawing.Color.LightGreen;
            colorArray[3] = System.Drawing.Color.Yellow;
            colorArray[4] = System.Drawing.Color.DarkOrange;
            colorArray[5] = System.Drawing.Color.Purple;
            colorArray[6] = System.Drawing.Color.ForestGreen;
            colorArray[7] = System.Drawing.Color.Magenta;
            colorArray[8] = System.Drawing.Color.Cyan;
            colorArray[9] = System.Drawing.Color.Pink;
            colorArray[10] = System.Drawing.Color.LightGray;
            colorArray[11] = System.Drawing.Color.Black;
            colorArray[12] = System.Drawing.Color.CornflowerBlue;
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
            revealSolution = false;
            solutionDGV.Hide();
            colorDataGridView.Hide();
            guessHistoryDGV.Hide();
            cluesDGV.Hide();

            guessHistoryDGV.RowCount = numberOfAllowedGuesses;
            guessHistoryDGV.ColumnCount = numberOfSpaces;
            foreach (DataGridViewColumn c in guessHistoryDGV.Columns)
            {
                c.Width = guessHistoryDGV.Width / guessHistoryDGV.ColumnCount;
            }
            foreach (DataGridViewRow r in guessHistoryDGV.Rows)
            {
                r.Height = guessHistoryDGV.Height / guessHistoryDGV.RowCount;
            }
            rowHeight = guessHistoryDGV.Height / guessHistoryDGV.RowCount;

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

            solutionDGV.RowCount = 1;
            solutionDGV.ColumnCount = numberOfSpaces;
            foreach (DataGridViewColumn c in solutionDGV.Columns)
            {
                c.Width = solutionDGV.Width / solutionDGV.ColumnCount;
            }
            foreach (DataGridViewRow r in solutionDGV.Rows)
            {
                r.Height = solutionDGV.Height / solutionDGV.RowCount;
            }

            // initialize the list of possible colors and guess history grid
            guessHistory = new List<Guess>();

            colorDataGridView.RowCount = 1;
            colorDataGridView.ColumnCount = numberOfColours;
            foreach(DataGridViewColumn c in colorDataGridView.Columns)
            {
                c.Width = colorDataGridView.Width / colorDataGridView.ColumnCount;
            }
            foreach (DataGridViewRow r in colorDataGridView.Rows)
            {
                r.Height = colorDataGridView.Height / colorDataGridView.RowCount;
            }

            guessInProgress = new System.Drawing.Color[numberOfSpaces];
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
            submit.Location = new Point(submit.Location.X, cluesDGV.Location.Y + cluesDGV.Height - rowHeight);
            submit.Show();
            solutionDGV.Show();
            showSolutions.Show();
            repeatsAllowedDisplayCheckbox.Show();
            panel3.Hide();
            checkGuessButton.Show();
            checkGuessResult.Show();
            cluesDGV.Show();
            guessHistoryDGV.Show();
            colorDataGridView.Show();
            selectCell(0, numberOfAllowedGuesses - 1);
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
            if (column < guessHistoryDGV.ColumnCount && row < guessHistoryDGV.RowCount )
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
            }
        }

        private void submitGuess()
        {
            checkGuessResult.Text = "";
            submit.Hide();
            cluesDGV.Invalidate();
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
                j++;
            }
            for (int k = 0; k < rightColorWrongPlace; k++)
            {
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
            if (rightColorRightPlace == numberOfSpaces || numberOfGuesses == numberOfAllowedGuesses - 1)
            {
                revealSolution = true;
                solutionDGV.Invalidate();
                cluesDGV.Invalidate();
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
                //submit.Hide();
            }
            else
            {
                numberOfGuesses++;
                selectCell(0, numberOfAllowedGuesses - numberOfGuesses - 1);
                submit.Location = new Point(submit.Location.X, submit.Location.Y - rowHeight);
                submit.Show();
            }
            cluesDGV.Invalidate();

        }

        private void showSolutions_Click(object sender, EventArgs e)
        {
            possibleSolutions.update(numberOfSpaces, allSolutions);
            possibleSolutions.Show();
            possibleSolutions.Location = new Point(this.Location.X + this.Width, this.Location.Y);
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
                System.Drawing.Color[] colorRepeatCheck = new System.Drawing.Color[numberOfSpaces];
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
                    checkGuessResult.Text = "No match: Right Color Wrong Place, guess " + m + ".";
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
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            int ellipseLocationX = e.CellBounds.X + 6;
            int ellipseLocationY = e.CellBounds.Y + 6;
            int ellipseWidth = Math.Min(e.CellBounds.Height, e.CellBounds.Width) - 10;
            int ellipseHeight = ellipseWidth;
            System.Drawing.Rectangle spotEllipseRectangle = new System.Drawing.Rectangle(ellipseLocationX, ellipseLocationY, ellipseWidth, ellipseHeight);
            System.Drawing.Rectangle gradientBigRectangle = new System.Drawing.Rectangle(ellipseLocationX, ellipseLocationY, ellipseWidth, ellipseHeight * 2);
            float filledSpotGradientAngle = (float)220.0;
            float emptySpotGradientAngle = (float)70.0;
            System.Drawing.Drawing2D.LinearGradientBrush highlightPenBrush = new LinearGradientBrush(gradientBigRectangle, Color.DarkGray, selectionBackgroundColor, emptySpotGradientAngle, false);
            System.Drawing.Drawing2D.LinearGradientBrush normalPenBrush = new LinearGradientBrush(spotEllipseRectangle, Color.LightGray, Color.Black, emptySpotGradientAngle, false);
            System.Drawing.Pen normalPen = new System.Drawing.Pen(normalPenBrush, 4.0f);
            System.Drawing.Pen highlightPen = new System.Drawing.Pen(highlightPenBrush, 4.0f);

            System.Drawing.Drawing2D.LinearGradientBrush br;
            
            // empty spots above the current guess
            if (e.RowIndex < numberOfAllowedGuesses - 1 - numberOfGuesses)
            {
                br = new System.Drawing.Drawing2D.LinearGradientBrush(spotEllipseRectangle, Color.Black, Color.LightGray, emptySpotGradientAngle, false);
                e.Graphics.FillEllipse(br, spotEllipseRectangle);
            }
            // current guess
            else if (e.RowIndex == numberOfAllowedGuesses - 1 - numberOfGuesses)
            {
                // player has already chosen a color in this spot of the current guess
                if (guessInProgress[e.ColumnIndex] != backgroundColor)
                {
                    Color c = guessInProgress[e.ColumnIndex];
                    br = new System.Drawing.Drawing2D.LinearGradientBrush(gradientBigRectangle, Color.Black, c, filledSpotGradientAngle, false);
                    e.Graphics.FillEllipse(br, spotEllipseRectangle);
                    //  hilite ellipse = based on http://www3.telus.net/ryanfransen/article_glassspheres.html
                    int r3w = Convert.ToInt16(spotEllipseRectangle.Width * 0.5);
                    int r3h = Convert.ToInt16(spotEllipseRectangle.Height * 0.3);
                    Rectangle r3 = new Rectangle(
                        new Point(spotEllipseRectangle.Location.X + (spotEllipseRectangle.Width / 4), spotEllipseRectangle.Location.Y + 2),
                        new Size(r3w, r3h));
                    LinearGradientBrush br2 = new LinearGradientBrush(r3, Color.White, Color.Transparent, 90);
                    br2.WrapMode = WrapMode.TileFlipX;
                    e.Graphics.FillEllipse(br2, r3);
                    br2.Dispose();
                }
                // player has not chosen a color, so this spot is the same as the empty rows above 
                else
                {
                    br = new System.Drawing.Drawing2D.LinearGradientBrush(spotEllipseRectangle, Color.Black, Color.LightGray, emptySpotGradientAngle, false);
                    e.Graphics.FillEllipse(br, spotEllipseRectangle);
                }
            }
            // previous guesses: fill color based on guess history
            else 
            {
                int guessHistoryIndex = numberOfAllowedGuesses - e.RowIndex -1 ;
                Guess guessAtRow = guessHistory.ElementAt(guessHistoryIndex);
                Color guessColor = guessAtRow.getColor(e.ColumnIndex);
                br = new System.Drawing.Drawing2D.LinearGradientBrush(gradientBigRectangle, Color.Black, guessColor, filledSpotGradientAngle, false);
                e.Graphics.FillEllipse(br, spotEllipseRectangle);

                //  hilite ellipse = based on http://www3.telus.net/ryanfransen/article_glassspheres.html
                int r3w = Convert.ToInt16(spotEllipseRectangle.Width * 0.5);
                int r3h = Convert.ToInt16(spotEllipseRectangle.Height * 0.3);
                Rectangle r3 = new Rectangle(
                    new Point(spotEllipseRectangle.Location.X + (spotEllipseRectangle.Width /4), spotEllipseRectangle.Location.Y+2),
                    new Size(r3w, r3h));
                LinearGradientBrush br2 = new LinearGradientBrush(r3, Color.White, Color.Transparent, 90);
                br2.WrapMode = WrapMode.TileFlipX;
                e.Graphics.FillEllipse(br2, r3);
                br2.Dispose();
            }
            // add the external ring
            e.Graphics.DrawEllipse(normalPen, spotEllipseRectangle);
            if (e.ColumnIndex == selectedCell.ColumnIndex && e.RowIndex == selectedCell.RowIndex) 
            {
                e.Graphics.DrawEllipse(highlightPen, spotEllipseRectangle);
            }
            e.PaintContent(e.ClipBounds);
            e.Handled = true;
            normalPen.Dispose();
            highlightPen.Dispose();
            br.Dispose();
        }

        private void colorDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (selectedCell != null)
            {
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
                guessInProgress[selectedCell.ColumnIndex] = colorArray[e.ColumnIndex];
                incrementSelection();
            }
        }

        private void solutionDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            int ellipseLocationX = e.CellBounds.X + 6;
            int ellipseLocationY = e.CellBounds.Y + 6;
            int ellipseWidth = Math.Min(e.CellBounds.Height, e.CellBounds.Width) - 10;
            int ellipseHeight = ellipseWidth;
            float emptySpotGradientAngle = (float)70.0;
            System.Drawing.Rectangle spotEllipseRectangle = new System.Drawing.Rectangle(ellipseLocationX, ellipseLocationY, ellipseWidth, ellipseHeight);
            System.Drawing.Drawing2D.LinearGradientBrush normalPenBrush = new LinearGradientBrush(spotEllipseRectangle, Color.PaleGoldenrod, Color.Black, emptySpotGradientAngle, false);
            System.Drawing.Pen normalPen = new System.Drawing.Pen(normalPenBrush, 4.0f);
            System.Drawing.Drawing2D.LinearGradientBrush br;

            if (revealSolution)
            {
                float filledSpotGradientAngle = (float)220.0;
                System.Drawing.Rectangle gradientBigRectangle = new System.Drawing.Rectangle(ellipseLocationX, ellipseLocationY, ellipseWidth, ellipseHeight * 2);
                Color c = solution.getColor(e.ColumnIndex);
                br = new System.Drawing.Drawing2D.LinearGradientBrush(gradientBigRectangle, Color.Black, c, filledSpotGradientAngle, false);
                e.Graphics.FillEllipse(br, spotEllipseRectangle);

                //  hilite ellipse = based on http://www3.telus.net/ryanfransen/article_glassspheres.html
                int r3w = Convert.ToInt16(spotEllipseRectangle.Width * 0.5);
                int r3h = Convert.ToInt16(spotEllipseRectangle.Height * 0.3);
                Rectangle r3 = new Rectangle(
                    new Point(spotEllipseRectangle.Location.X + (spotEllipseRectangle.Width / 4), spotEllipseRectangle.Location.Y + 2),
                    new Size(r3w, r3h));
                LinearGradientBrush br2 = new LinearGradientBrush(r3, Color.White, Color.Transparent, 90);
                br2.WrapMode = WrapMode.TileFlipX;
                e.Graphics.FillEllipse(br2, r3);
                br2.Dispose();
            }
            else
            {
                br = new System.Drawing.Drawing2D.LinearGradientBrush(spotEllipseRectangle, Color.Black, Color.PaleGoldenrod, emptySpotGradientAngle, false);
                e.Graphics.FillEllipse(br, spotEllipseRectangle);
            }
            e.Graphics.DrawEllipse(normalPen, spotEllipseRectangle);
            e.PaintContent(e.ClipBounds);
            e.Handled = true;
            br.Dispose();
            normalPen.Dispose();
            normalPenBrush.Dispose();
        }

        private void colorDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            int rectangleLocationX = e.CellBounds.X + 3;
            int rectangleLocationY = e.CellBounds.Y + 3;
            int rectangleWidth = e.CellBounds.Width - 6;
            int rectangleHeight = e.CellBounds.Height - 6;
            float emptySpotGradientAngle = (float)70.0;
            System.Drawing.Rectangle spotRectangle = new System.Drawing.Rectangle(rectangleLocationX, rectangleLocationY, rectangleWidth, rectangleHeight);
            System.Drawing.Rectangle gradientBigRectangle = new System.Drawing.Rectangle(rectangleLocationX, rectangleLocationY, rectangleWidth, rectangleHeight * 2);
            System.Drawing.Rectangle gradientBiggerRectangle = new System.Drawing.Rectangle(rectangleLocationX-10, rectangleLocationY-10, rectangleWidth+20, rectangleHeight *3);
            System.Drawing.Drawing2D.LinearGradientBrush normalPenBrush = new LinearGradientBrush(gradientBiggerRectangle, Color.Silver, Color.Black, emptySpotGradientAngle, true);
            System.Drawing.Pen normalPen = new System.Drawing.Pen(normalPenBrush, 3.0f);
            System.Drawing.Drawing2D.LinearGradientBrush br;
            float filledSpotGradientAngle = (float)270.0;
            Color c = colorArray[e.ColumnIndex];
            br = new System.Drawing.Drawing2D.LinearGradientBrush(gradientBigRectangle, Color.Black, c, filledSpotGradientAngle, false);
            e.Graphics.FillRectangle(br, spotRectangle);

            //  hilite ellipse = based on http://www3.telus.net/ryanfransen/article_glassspheres.html
            int r3w = Convert.ToInt16(spotRectangle.Width);
            int r3h = Convert.ToInt16(spotRectangle.Height * 0.4);
            Rectangle r3 = new Rectangle(
                new Point(spotRectangle.Location.X , spotRectangle.Location.Y + 1),
                new Size(r3w, r3h));
            LinearGradientBrush br2 = new LinearGradientBrush(r3, Color.White, Color.Transparent, 90);
            br2.WrapMode = WrapMode.TileFlipX;
            e.Graphics.FillRectangle(br2, r3);
            br2.Dispose();
            e.Graphics.DrawRectangle(normalPen, spotRectangle);
            e.PaintContent(e.ClipBounds);
            e.Handled = true;
            br.Dispose();
            normalPen.Dispose();
            normalPenBrush.Dispose();
        }

        // based on http://stackoverflow.com/questions/13537679/drawing-a-triangle-in-gdi-given-a-rectangle
        private Point[] DrawTriangle(Rectangle rect, String direction)
        {
            int halfWidth = rect.Width / 2;
            int halfHeight = rect.Height / 2;
            Point p0 = Point.Empty;
            Point p1 = Point.Empty;
            Point p2 = Point.Empty;
            switch (direction)
            {
                case "up":
                    p0 = new Point(rect.Left + halfWidth, rect.Top);
                    p1 = new Point(rect.Left, rect.Bottom);
                    p2 = new Point(rect.Right, rect.Bottom);
                    break;
                case "down":
                    p0 = new Point(rect.Left + halfWidth, rect.Bottom);
                    p1 = new Point(rect.Left, rect.Top);
                    p2 = new Point(rect.Right, rect.Top);
                    break;
                case "left":
                    p0 = new Point(rect.Left, rect.Top + halfHeight);
                    p1 = new Point(rect.Right, rect.Top);
                    p2 = new Point(rect.Right, rect.Bottom);
                    break;
                case "right":
                    p0 = new Point(rect.Right, rect.Top + halfHeight);
                    p1 = new Point(rect.Left, rect.Bottom);
                    p2 = new Point(rect.Left, rect.Top);
                    break;
            }
            return new Point[] { p0, p1, p2 };
        }

        private Point[][] DrawPyramid(Rectangle rect, String direction)
        {
            int halfWidth = rect.Width / 2;
            int halfHeight = rect.Height / 2;
            Point midpoint = new Point(rect.Left + halfWidth, rect.Top + halfHeight);
            Point top = new Point(rect.Left + halfWidth, rect.Top);
            Point bottomLeft = new Point(rect.Left, rect.Bottom);
            Point bottomRight = new Point(rect.Right, rect.Bottom);
            Point bottom = new Point(rect.Left + halfWidth, rect.Bottom);
            Point topLeft = new Point(rect.Left, rect.Top);
            Point topRight = new Point(rect.Right, rect.Top);
            Point left = new Point(rect.Left, rect.Top + halfHeight);
            Point right = new Point(rect.Right, rect.Top + halfHeight);

            switch (direction)
            {
                case "up":
                    return new Point[][] { new Point[] { top, midpoint, bottomLeft }, new Point[] { top, midpoint, bottomRight }, new Point[] { bottomLeft, midpoint, bottomRight } };
                case "down":
                    return new Point[][] { new Point[] { bottom, midpoint, topLeft }, new Point[] { bottom, midpoint, topRight }, new Point[] { topLeft, midpoint, topRight } };
                case "left":
                    return new Point[][] { new Point[] { left, midpoint, topRight }, new Point[] { left, midpoint, bottomRight }, new Point[] { topRight, midpoint, bottomRight } };
                case "right":
                    return new Point[][] { new Point[] { topLeft, midpoint, right }, new Point[] { bottomLeft, midpoint, right }, new Point[] { topLeft, midpoint, bottomLeft } };
            }
            return null; 
        }

        private void cluesDGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // first paint over the submit button
            if (e.RowIndex <= numberOfAllowedGuesses -1 - guessHistory.Count)
             {
                 Brush bg = new SolidBrush(backgroundColor);
                 e.Graphics.FillRectangle(bg, e.ClipBounds);
                 bg.Dispose();
                 e.PaintContent(e.ClipBounds);
                 e.Handled = true;
             }
            else if (e.RowIndex > numberOfAllowedGuesses - 1 - guessHistory.Count && guessHistory.Count>0)
            {
                int guessHistoryIndex = numberOfAllowedGuesses - e.RowIndex -1 ;
                Guess guessAtRow = guessHistory.ElementAt(guessHistoryIndex);
                int rightColorRightPlace = guessAtRow.getRightColorRightPlace();
                int rightColorWrongPlace = guessAtRow.getRightColorWrongPlace();
                Color c = backgroundColor;
                String direction = "";
                if (e.ColumnIndex < rightColorRightPlace)
                {
                    c = rightColorRightPlaceMarker;
                    direction = "up";
                }
                else if (numberOfSpaces - e.ColumnIndex <= rightColorWrongPlace)
                {
                    c = rightColorWrongPlaceMarker;
                    direction = "down";
                }
                else
                {
                    e.Handled = true;
                    return;
                }

                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                int rectangleLocationX = e.CellBounds.X + 3;
                int rectangleLocationY = e.CellBounds.Y + 3;
                int rectangleWidth = Math.Min(e.CellBounds.Height, e.CellBounds.Width) - 10;
                int rectangleHeight = rectangleWidth;
                System.Drawing.Rectangle spotRectangle = new System.Drawing.Rectangle(rectangleLocationX, rectangleLocationY, rectangleWidth, rectangleHeight);
                System.Drawing.Rectangle gradientBigRectangle = new System.Drawing.Rectangle(rectangleLocationX, rectangleLocationY, rectangleWidth, rectangleHeight * 3);
                System.Drawing.Rectangle gradientBiggerRectangle = new System.Drawing.Rectangle(rectangleLocationX - 10, rectangleLocationY - 10, rectangleWidth + 20, rectangleHeight * 3);
                float filledSpotGradientAngle = (float)220.0;
                float emptySpotGradientAngle = (float)180.0;
                float anotherGradientAngle = (float)90.0;
                System.Drawing.Drawing2D.LinearGradientBrush normalPenBrush = new LinearGradientBrush(gradientBiggerRectangle, Color.LightGray, Color.Black, emptySpotGradientAngle, false);
                System.Drawing.Pen normalPen = new System.Drawing.Pen(normalPenBrush, 1.0f);

                System.Drawing.Drawing2D.LinearGradientBrush br;
                br = new System.Drawing.Drawing2D.LinearGradientBrush(gradientBigRectangle, Color.Black, c, filledSpotGradientAngle, false);
                System.Drawing.Drawing2D.LinearGradientBrush br2;
                br2 = new System.Drawing.Drawing2D.LinearGradientBrush(gradientBigRectangle, Color.LightGray, c, emptySpotGradientAngle, false);
                System.Drawing.Drawing2D.LinearGradientBrush br3;
                br3 = new System.Drawing.Drawing2D.LinearGradientBrush(gradientBigRectangle, Color.White, c, anotherGradientAngle, false);

                Point[] triangle = DrawTriangle(spotRectangle, direction);
                Point[][] pyramid = DrawPyramid(spotRectangle, direction);
                e.Graphics.FillPolygon(br, pyramid[0]);
                e.Graphics.FillPolygon(br2, pyramid[1]);
                e.Graphics.FillPolygon(br3, pyramid[2]);
                e.Graphics.DrawPolygon(normalPen, triangle);
                e.PaintContent(e.ClipBounds);
                e.Handled = true;
                normalPen.Dispose();
                br.Dispose();

            }
        }
    }

    public class Guess
    {
        private System.Drawing.Color[] colors;
        private int numSpaces;
        private System.Drawing.Color default_color = System.Drawing.Color.WhiteSmoke;
        private int rightColorRightPlace;
        private int rightColorWrongPlace;

        Guess() 
        {
            numSpaces = 0;
        }

        public Guess(int num)
        {
            numSpaces = num;
            colors = new System.Drawing.Color[numSpaces];
        }

        public Guess(System.Drawing.Color[] color_array)
        {
            colors = color_array;
            numSpaces = colors.Length;
        }

        public System.Drawing.Color getColor(int n)
        {
            if (n < numSpaces) return colors[n];
            else return default_color;
        }

        public int getNumSpaces()
        {
            return numSpaces;
        }

        public void setColor(int n, System.Drawing.Color c)
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
            ILookup<System.Drawing.Color, System.Drawing.Color> lookup1 = colors.ToLookup(i => i);
            List<System.Drawing.Color> tempOther = new List<System.Drawing.Color>();
            for (int i = 0; i < numSpaces; i++)
            {
                tempOther.Add(g.getColor(i));
            }
            ILookup<System.Drawing.Color, System.Drawing.Color> lookup2 = tempOther.ToLookup(i => i);
            System.Drawing.Color[] intersection =  (
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
