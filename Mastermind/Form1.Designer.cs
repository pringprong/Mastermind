namespace Mastermind
{
    partial class MastermindMainWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.guessHistoryDGV = new System.Windows.Forms.DataGridView();
            this.submit = new System.Windows.Forms.Button();
            this.newGameButton = new System.Windows.Forms.Button();
            this.solutionDGV = new System.Windows.Forms.DataGridView();
            this.showSolutions = new System.Windows.Forms.Button();
            this.cluesDGV = new System.Windows.Forms.DataGridView();
            this.numSpacesLabel = new System.Windows.Forms.Label();
            this.repeatsAllowedCheckbox = new System.Windows.Forms.CheckBox();
            this.numberOfSpacesUpDown = new System.Windows.Forms.NumericUpDown();
            this.numberOfColorsLabel = new System.Windows.Forms.Label();
            this.numberOfColorsUpDown = new System.Windows.Forms.NumericUpDown();
            this.quitButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkGuessButton = new System.Windows.Forms.Button();
            this.checkGuessResult = new System.Windows.Forms.Label();
            this.repeatsAllowedDisplayCheckbox = new System.Windows.Forms.CheckBox();
            this.colorDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.guessHistoryDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solutionDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cluesDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfSpacesUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfColorsUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 726);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total possible solutions:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 726);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 726);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Solutions that match all conditions:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(353, 726);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "label4";
            // 
            // guessHistoryDGV
            // 
            this.guessHistoryDGV.AllowUserToAddRows = false;
            this.guessHistoryDGV.AllowUserToDeleteRows = false;
            this.guessHistoryDGV.AllowUserToResizeColumns = false;
            this.guessHistoryDGV.AllowUserToResizeRows = false;
            this.guessHistoryDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.guessHistoryDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.guessHistoryDGV.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.guessHistoryDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.guessHistoryDGV.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guessHistoryDGV.DefaultCellStyle = dataGridViewCellStyle1;
            this.guessHistoryDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.guessHistoryDGV.Location = new System.Drawing.Point(10, 87);
            this.guessHistoryDGV.MultiSelect = false;
            this.guessHistoryDGV.Name = "guessHistoryDGV";
            this.guessHistoryDGV.RowHeadersVisible = false;
            this.guessHistoryDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.guessHistoryDGV.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.guessHistoryDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.guessHistoryDGV.ShowCellErrors = false;
            this.guessHistoryDGV.ShowCellToolTips = false;
            this.guessHistoryDGV.ShowEditingIcon = false;
            this.guessHistoryDGV.ShowRowErrors = false;
            this.guessHistoryDGV.Size = new System.Drawing.Size(329, 536);
            this.guessHistoryDGV.TabIndex = 5;
            this.guessHistoryDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.guessHistoryDGV_CellClick);
            this.guessHistoryDGV.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.guessHistoryDGV_CellPainting);
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(345, 585);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(116, 29);
            this.submit.TabIndex = 7;
            this.submit.Text = "Submit Guess";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(30, 103);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(110, 26);
            this.newGameButton.TabIndex = 8;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // solutionDGV
            // 
            this.solutionDGV.AllowUserToAddRows = false;
            this.solutionDGV.AllowUserToDeleteRows = false;
            this.solutionDGV.AllowUserToResizeColumns = false;
            this.solutionDGV.AllowUserToResizeRows = false;
            this.solutionDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.solutionDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.solutionDGV.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.solutionDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.solutionDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.solutionDGV.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.solutionDGV.DefaultCellStyle = dataGridViewCellStyle2;
            this.solutionDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.solutionDGV.Enabled = false;
            this.solutionDGV.Location = new System.Drawing.Point(10, 8);
            this.solutionDGV.MultiSelect = false;
            this.solutionDGV.Name = "solutionDGV";
            this.solutionDGV.RowHeadersVisible = false;
            this.solutionDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.solutionDGV.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            this.solutionDGV.RowTemplate.ReadOnly = true;
            this.solutionDGV.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.solutionDGV.ShowCellErrors = false;
            this.solutionDGV.ShowCellToolTips = false;
            this.solutionDGV.ShowEditingIcon = false;
            this.solutionDGV.ShowRowErrors = false;
            this.solutionDGV.Size = new System.Drawing.Size(329, 67);
            this.solutionDGV.TabIndex = 9;
            this.solutionDGV.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.solutionDataGridView_CellPainting);
            // 
            // showSolutions
            // 
            this.showSolutions.Location = new System.Drawing.Point(368, 691);
            this.showSolutions.Name = "showSolutions";
            this.showSolutions.Size = new System.Drawing.Size(93, 32);
            this.showSolutions.TabIndex = 10;
            this.showSolutions.Text = "Show solutions";
            this.showSolutions.UseVisualStyleBackColor = true;
            this.showSolutions.Click += new System.EventHandler(this.showSolutions_Click);
            // 
            // cluesDGV
            // 
            this.cluesDGV.AllowUserToAddRows = false;
            this.cluesDGV.AllowUserToDeleteRows = false;
            this.cluesDGV.AllowUserToResizeColumns = false;
            this.cluesDGV.AllowUserToResizeRows = false;
            this.cluesDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cluesDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.cluesDGV.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.cluesDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.cluesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cluesDGV.ColumnHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.cluesDGV.DefaultCellStyle = dataGridViewCellStyle3;
            this.cluesDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.cluesDGV.Enabled = false;
            this.cluesDGV.Location = new System.Drawing.Point(345, 87);
            this.cluesDGV.MultiSelect = false;
            this.cluesDGV.Name = "cluesDGV";
            this.cluesDGV.RowHeadersVisible = false;
            this.cluesDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.cluesDGV.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.cluesDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.cluesDGV.ShowCellErrors = false;
            this.cluesDGV.ShowCellToolTips = false;
            this.cluesDGV.ShowEditingIcon = false;
            this.cluesDGV.ShowRowErrors = false;
            this.cluesDGV.Size = new System.Drawing.Size(116, 536);
            this.cluesDGV.TabIndex = 11;
            this.cluesDGV.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.cluesDGV_CellPainting);
            // 
            // numSpacesLabel
            // 
            this.numSpacesLabel.AutoSize = true;
            this.numSpacesLabel.Location = new System.Drawing.Point(7, 19);
            this.numSpacesLabel.Name = "numSpacesLabel";
            this.numSpacesLabel.Size = new System.Drawing.Size(93, 13);
            this.numSpacesLabel.TabIndex = 9;
            this.numSpacesLabel.Text = "Number of spaces";
            // 
            // repeatsAllowedCheckbox
            // 
            this.repeatsAllowedCheckbox.AutoSize = true;
            this.repeatsAllowedCheckbox.Checked = true;
            this.repeatsAllowedCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.repeatsAllowedCheckbox.Location = new System.Drawing.Point(33, 83);
            this.repeatsAllowedCheckbox.Name = "repeatsAllowedCheckbox";
            this.repeatsAllowedCheckbox.Size = new System.Drawing.Size(105, 17);
            this.repeatsAllowedCheckbox.TabIndex = 10;
            this.repeatsAllowedCheckbox.Text = "Repeats allowed";
            this.repeatsAllowedCheckbox.UseVisualStyleBackColor = true;
            this.repeatsAllowedCheckbox.CheckedChanged += new System.EventHandler(this.repeatsAllowedCheckbox_CheckedChanged);
            // 
            // numberOfSpacesUpDown
            // 
            this.numberOfSpacesUpDown.Location = new System.Drawing.Point(106, 15);
            this.numberOfSpacesUpDown.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numberOfSpacesUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numberOfSpacesUpDown.Name = "numberOfSpacesUpDown";
            this.numberOfSpacesUpDown.Size = new System.Drawing.Size(33, 20);
            this.numberOfSpacesUpDown.TabIndex = 11;
            this.numberOfSpacesUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numberOfSpacesUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numberOfSpacesUpDown.ValueChanged += new System.EventHandler(this.numberOfSpacesUpDown_ValueChanged);
            // 
            // numberOfColorsLabel
            // 
            this.numberOfColorsLabel.AutoSize = true;
            this.numberOfColorsLabel.Location = new System.Drawing.Point(7, 14);
            this.numberOfColorsLabel.Name = "numberOfColorsLabel";
            this.numberOfColorsLabel.Size = new System.Drawing.Size(90, 13);
            this.numberOfColorsLabel.TabIndex = 12;
            this.numberOfColorsLabel.Text = "Number of colors:";
            // 
            // numberOfColorsUpDown
            // 
            this.numberOfColorsUpDown.Location = new System.Drawing.Point(103, 10);
            this.numberOfColorsUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numberOfColorsUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numberOfColorsUpDown.Name = "numberOfColorsUpDown";
            this.numberOfColorsUpDown.Size = new System.Drawing.Size(42, 20);
            this.numberOfColorsUpDown.TabIndex = 13;
            this.numberOfColorsUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numberOfColorsUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numberOfColorsUpDown.ValueChanged += new System.EventHandler(this.numberOfColorsUpDown_ValueChanged);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(30, 135);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(110, 23);
            this.quitButton.TabIndex = 14;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numberOfSpacesUpDown);
            this.panel1.Controls.Add(this.numSpacesLabel);
            this.panel1.Location = new System.Drawing.Point(11, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(148, 39);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.numberOfColorsLabel);
            this.panel2.Controls.Add(this.numberOfColorsUpDown);
            this.panel2.Location = new System.Drawing.Point(11, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(148, 36);
            this.panel2.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.newGameButton);
            this.panel3.Controls.Add(this.repeatsAllowedCheckbox);
            this.panel3.Controls.Add(this.quitButton);
            this.panel3.Location = new System.Drawing.Point(128, 223);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(173, 166);
            this.panel3.TabIndex = 13;
            // 
            // checkGuessButton
            // 
            this.checkGuessButton.Location = new System.Drawing.Point(8, 691);
            this.checkGuessButton.Name = "checkGuessButton";
            this.checkGuessButton.Size = new System.Drawing.Size(83, 32);
            this.checkGuessButton.TabIndex = 14;
            this.checkGuessButton.Text = "Check guess";
            this.checkGuessButton.UseVisualStyleBackColor = true;
            this.checkGuessButton.Click += new System.EventHandler(this.checkGuessButton_Click);
            // 
            // checkGuessResult
            // 
            this.checkGuessResult.AutoSize = true;
            this.checkGuessResult.Location = new System.Drawing.Point(96, 701);
            this.checkGuessResult.Name = "checkGuessResult";
            this.checkGuessResult.Size = new System.Drawing.Size(37, 13);
            this.checkGuessResult.TabIndex = 15;
            this.checkGuessResult.Text = "Result";
            // 
            // repeatsAllowedDisplayCheckbox
            // 
            this.repeatsAllowedDisplayCheckbox.AutoSize = true;
            this.repeatsAllowedDisplayCheckbox.Checked = true;
            this.repeatsAllowedDisplayCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.repeatsAllowedDisplayCheckbox.Enabled = false;
            this.repeatsAllowedDisplayCheckbox.Location = new System.Drawing.Point(356, 12);
            this.repeatsAllowedDisplayCheckbox.Name = "repeatsAllowedDisplayCheckbox";
            this.repeatsAllowedDisplayCheckbox.Size = new System.Drawing.Size(105, 17);
            this.repeatsAllowedDisplayCheckbox.TabIndex = 16;
            this.repeatsAllowedDisplayCheckbox.Text = "Repeats allowed";
            this.repeatsAllowedDisplayCheckbox.UseVisualStyleBackColor = true;
            // 
            // colorDataGridView
            // 
            this.colorDataGridView.AllowUserToAddRows = false;
            this.colorDataGridView.AllowUserToDeleteRows = false;
            this.colorDataGridView.AllowUserToResizeColumns = false;
            this.colorDataGridView.AllowUserToResizeRows = false;
            this.colorDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.colorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.colorDataGridView.ColumnHeadersVisible = false;
            this.colorDataGridView.Location = new System.Drawing.Point(8, 632);
            this.colorDataGridView.MultiSelect = false;
            this.colorDataGridView.Name = "colorDataGridView";
            this.colorDataGridView.ReadOnly = true;
            this.colorDataGridView.RowHeadersVisible = false;
            this.colorDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.colorDataGridView.ShowCellErrors = false;
            this.colorDataGridView.ShowCellToolTips = false;
            this.colorDataGridView.ShowEditingIcon = false;
            this.colorDataGridView.ShowRowErrors = false;
            this.colorDataGridView.Size = new System.Drawing.Size(453, 53);
            this.colorDataGridView.TabIndex = 17;
            this.colorDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.colorDataGridView_CellClick);
            this.colorDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.colorDataGridView_CellDoubleClick);
            this.colorDataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.colorDataGridView_CellPainting);
            // 
            // MastermindMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(468, 751);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.colorDataGridView);
            this.Controls.Add(this.repeatsAllowedDisplayCheckbox);
            this.Controls.Add(this.checkGuessResult);
            this.Controls.Add(this.checkGuessButton);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.cluesDGV);
            this.Controls.Add(this.showSolutions);
            this.Controls.Add(this.solutionDGV);
            this.Controls.Add(this.guessHistoryDGV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MastermindMainWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mastermind by Monica";
            ((System.ComponentModel.ISupportInitialize)(this.guessHistoryDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solutionDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cluesDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfSpacesUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfColorsUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView guessHistoryDGV;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.DataGridView solutionDGV;
        private System.Windows.Forms.Button showSolutions;
        private System.Windows.Forms.DataGridView cluesDGV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numberOfSpacesUpDown;
        private System.Windows.Forms.Label numSpacesLabel;
        private System.Windows.Forms.NumericUpDown numberOfColorsUpDown;
        private System.Windows.Forms.CheckBox repeatsAllowedCheckbox;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label numberOfColorsLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button checkGuessButton;
        private System.Windows.Forms.Label checkGuessResult;
        private System.Windows.Forms.CheckBox repeatsAllowedDisplayCheckbox;
        private System.Windows.Forms.DataGridView colorDataGridView;
    }
}

