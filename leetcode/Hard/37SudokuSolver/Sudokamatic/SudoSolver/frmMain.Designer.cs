namespace SudoSolver
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpBoard = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSolve = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lstOutput = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // grpBoard
            // 
            this.grpBoard.Location = new System.Drawing.Point(284, 12);
            this.grpBoard.Name = "grpBoard";
            this.grpBoard.Size = new System.Drawing.Size(504, 517);
            this.grpBoard.TabIndex = 0;
            this.grpBoard.TabStop = false;
            this.grpBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.grpBoard_Paint);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 21);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(248, 258);
            this.textBox1.TabIndex = 1;
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(185, 290);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(75, 23);
            this.btnSolve.TabIndex = 2;
            this.btnSolve.Text = "&Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(185, 506);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lstOutput
            // 
            this.lstOutput.FormattingEnabled = true;
            this.lstOutput.ItemHeight = 15;
            this.lstOutput.Location = new System.Drawing.Point(12, 290);
            this.lstOutput.Name = "lstOutput";
            this.lstOutput.Size = new System.Drawing.Size(120, 244);
            this.lstOutput.TabIndex = 4;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 541);
            this.Controls.Add(this.lstOutput);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.grpBoard);
            this.Name = "frmMain";
            this.Text = "Sudoku Solver";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox grpBoard;
        private TextBox textBox1;
        private Button btnSolve;
        private Button btnExit;
        private ListBox lstOutput;
    }
}