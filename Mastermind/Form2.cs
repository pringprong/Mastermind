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

    public partial class MastermindColorChooser : Form
    {
        private int numberOfColours;
        //private Collection buttons = new Collection();
        private MastermindMainWindow parent;
        private Color[] colorArray;

        public MastermindColorChooser()
        {
            InitializeComponent();
        }

        public void setNumColors(int numColors) 
        {
            numberOfColours = numColors;
        }

        public void setColorArray(Color[] newColorArray)
        {
            colorArray = newColorArray;
        }

        public void setParentWindow(MastermindMainWindow w)
        {
            parent = w;
        }

        private void MastermindColorChooser_Load(object sender, EventArgs e)
        {
            colorDataGridView.RowCount = 1;
            colorDataGridView.ColumnCount = numberOfColours;
            int i = 0;
            foreach (DataGridViewColumn c in colorDataGridView.Columns)
            {
                c.Width = colorDataGridView.Width / colorDataGridView.ColumnCount;
                c.DefaultCellStyle.BackColor = colorArray[i];
                c.DefaultCellStyle.SelectionBackColor = colorArray[i];
                i++;
            }
            foreach (DataGridViewRow r in colorDataGridView.Rows)
            {
                r.Height = colorDataGridView.Height / colorDataGridView.RowCount;
            }
        }

        private void colorDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Color selectedColor = Color.Black;

            DataGridViewColumnCollection coll = colorDataGridView.Columns;
            DataGridViewColumn c = coll[e.ColumnIndex];
            selectedColor = c.DefaultCellStyle.BackColor;
            //parent.setSelectedColor(selectedColor);
            this.Hide();
        }
    }
}
