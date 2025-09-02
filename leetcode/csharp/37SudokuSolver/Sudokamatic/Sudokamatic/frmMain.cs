using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using SudokuSolver;

namespace Sudokamatic
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox60_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            foreach (var control in gbSudokuForm.Controls) 
            {
                TextBox t = control as TextBox;
                if (t != null) 
                {
                    t.Text = "-"; 
                    t.Enabled= false;
                }
                ShowFeedback("Ready...");
            }
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            try 
            {
               
            }
            catch(Exception ex) 
            {
                ShowFeedback($"Error: {ex.Message}"); 
            }
        }

        private void ShowFeedback(string message) 
        {
            txtOutput.Text = message;
        }
    }
}
