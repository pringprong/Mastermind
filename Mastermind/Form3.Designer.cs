namespace Mastermind
{
    partial class possibleSolutionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.possibleSolutionsDGV = new System.Windows.Forms.DataGridView();
            this.tooManySolutionsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.possibleSolutionsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // possibleSolutionsDGV
            // 
            this.possibleSolutionsDGV.AllowUserToAddRows = false;
            this.possibleSolutionsDGV.AllowUserToDeleteRows = false;
            this.possibleSolutionsDGV.AllowUserToResizeColumns = false;
            this.possibleSolutionsDGV.AllowUserToResizeRows = false;
            this.possibleSolutionsDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.possibleSolutionsDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.possibleSolutionsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.possibleSolutionsDGV.ColumnHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.possibleSolutionsDGV.DefaultCellStyle = dataGridViewCellStyle3;
            this.possibleSolutionsDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.possibleSolutionsDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.possibleSolutionsDGV.Location = new System.Drawing.Point(0, 0);
            this.possibleSolutionsDGV.Name = "possibleSolutionsDGV";
            this.possibleSolutionsDGV.ReadOnly = true;
            this.possibleSolutionsDGV.RowHeadersVisible = false;
            this.possibleSolutionsDGV.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.possibleSolutionsDGV.Size = new System.Drawing.Size(311, 821);
            this.possibleSolutionsDGV.TabIndex = 0;
            // 
            // tooManySolutionsButton
            // 
            this.tooManySolutionsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tooManySolutionsButton.Location = new System.Drawing.Point(0, 0);
            this.tooManySolutionsButton.Name = "tooManySolutionsButton";
            this.tooManySolutionsButton.Size = new System.Drawing.Size(311, 821);
            this.tooManySolutionsButton.TabIndex = 1;
            this.tooManySolutionsButton.Text = "button1";
            this.tooManySolutionsButton.UseVisualStyleBackColor = true;
            this.tooManySolutionsButton.Click += new System.EventHandler(this.tooManySolutionsButton_Click);
            // 
            // possibleSolutionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(311, 821);
            this.ControlBox = false;
            this.Controls.Add(this.tooManySolutionsButton);
            this.Controls.Add(this.possibleSolutionsDGV);
            this.Name = "possibleSolutionsForm";
            this.ShowIcon = false;
            this.Text = "Solutions";
            this.Activated += new System.EventHandler(this.possibleSolutionsForm_Activated);
            this.Deactivate += new System.EventHandler(this.possibleSolutionsForm_Deactivate);
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.possibleSolutionsDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView possibleSolutionsDGV;
        private System.Windows.Forms.Button tooManySolutionsButton;
    }
}