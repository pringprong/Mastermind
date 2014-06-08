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
    public partial class possibleSolutionsForm : Form
    {
        private List<Guess> solutionList;
        private int numSpaces;
        private int maxSolutionsDisplayed = 200;
        private int rowHeight = 10;
        private int columnWidth = 40;

        public possibleSolutionsForm()
        {
            InitializeComponent();
//            possibleSolutionsDGV.Location = new Point(0, 0);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (solutionList.Count > 100)
                rowHeight = 5;
            else
                rowHeight = 10;
            this.Height = solutionList.Count * rowHeight + 30;
            this.Width = numSpaces * columnWidth + 10;

        }

        public void update(int newNumSpaces, List<Guess> newSolutionList)
        {
            numSpaces = newNumSpaces;
            solutionList = newSolutionList;
//            if (solutionList.Count > 100)
//                rowHeight = 5;
//            else
//                rowHeight = 10;
        }

        private void possibleSolutionsForm_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void possibleSolutionsForm_Activated(object sender, EventArgs e)
        {
//            possibleSolutionsDGV.Location = new Point(0, 0); 
            if (solutionList.Count() <= maxSolutionsDisplayed)
            {
                possibleSolutionsDGV.RowCount = solutionList.Count();
                if (solutionList.Count > 80)
                     rowHeight = 5;
                else
                     rowHeight = 10;
                possibleSolutionsDGV.ColumnCount = numSpaces;
                //int effectiveRowHeight = possibleSolutionsDGV.Height / possibleSolutionsDGV.RowCount;
                //int effectiveColumnWidth = possibleSolutionsDGV.Width / possibleSolutionsDGV.ColumnCount;
                //possibleSolutionsDGV.Height = effectiveRowHeight * possibleSolutionsDGV.RowCount;
                possibleSolutionsDGV.Height = rowHeight * possibleSolutionsDGV.RowCount;
                //possibleSolutionsDGV.Width = effectiveColumnWidth * possibleSolutionsDGV.ColumnCount;
                possibleSolutionsDGV.Width = columnWidth * possibleSolutionsDGV.ColumnCount;
                this.Height = rowHeight * possibleSolutionsDGV.RowCount + 40;
                this.Width = columnWidth * possibleSolutionsDGV.ColumnCount + 20;

                foreach (DataGridViewColumn c in possibleSolutionsDGV.Columns)
                {
                    c.Width = columnWidth;
                    int i = 0;
                    foreach (Guess g in solutionList)
                    {
                        possibleSolutionsDGV[c.Index, i].Style.BackColor = g.getColor(c.Index);
                        possibleSolutionsDGV[c.Index, i].Style.SelectionBackColor = g.getColor(c.Index);
                        i++;
                    }
                }
                foreach (DataGridViewRow r in possibleSolutionsDGV.Rows)
                {
                    //r.Height = effectiveRowHeight;
                    r.Height = rowHeight;
                }
                tooManySolutionsButton.Hide();
                possibleSolutionsDGV.Show();
            }
            else
            {
                possibleSolutionsDGV.Hide();
                this.Height = 200;
                this.Width = 200;
                tooManySolutionsButton.Text = "Can't display more than " + maxSolutionsDisplayed + " solutions.";
                tooManySolutionsButton.Show();
            }
        }
        public void publicUpdate(int newNumSpaces, List<Guess> newSolutionList)
        {
            update(newNumSpaces, newSolutionList);
 //           if (newSolutionList.Count > 100)
 //               rowHeight = 5;
 //           else
 //               rowHeight = 10;
 //           this.Height = newSolutionList.Count * rowHeight + 30;
 //           this.Width = newNumSpaces * columnWidth + 10;
        }

        private void tooManySolutionsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
