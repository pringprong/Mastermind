namespace Mastermind
{
    partial class MastermindColorChooser
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
            this.colorDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.colorDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // colorDataGridView
            // 
            this.colorDataGridView.AllowUserToAddRows = false;
            this.colorDataGridView.AllowUserToDeleteRows = false;
            this.colorDataGridView.AllowUserToResizeColumns = false;
            this.colorDataGridView.AllowUserToResizeRows = false;
            this.colorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.colorDataGridView.ColumnHeadersVisible = false;
            this.colorDataGridView.Location = new System.Drawing.Point(12, 12);
            this.colorDataGridView.MultiSelect = false;
            this.colorDataGridView.Name = "colorDataGridView";
            this.colorDataGridView.ReadOnly = true;
            this.colorDataGridView.RowHeadersVisible = false;
            this.colorDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.colorDataGridView.ShowCellErrors = false;
            this.colorDataGridView.ShowCellToolTips = false;
            this.colorDataGridView.ShowEditingIcon = false;
            this.colorDataGridView.ShowRowErrors = false;
            this.colorDataGridView.Size = new System.Drawing.Size(242, 39);
            this.colorDataGridView.TabIndex = 0;
            this.colorDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.colorDataGridView_CellClick);
            // 
            // MastermindColorChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 59);
            this.ControlBox = false;
            this.Controls.Add(this.colorDataGridView);
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MastermindColorChooser";
            this.ShowIcon = false;
            this.Text = "Choose a colour";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MastermindColorChooser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.colorDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView colorDataGridView;

    }
}