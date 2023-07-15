namespace SudoSolver
{
    public partial class frmMain : Form
    {
        private const int CellWidth = 40; 
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DrawBoard();
            ShowFeedback("Ready..."); 
        }

        private void ShowFeedback(string message) 
        {
            lstOutput.Items.Add(message);
        }

        private void DrawBoard() 
        {
            int x = 20;
            int y = 20;
            int spacer = 10; 
            for (int row = 0; row < 9; row++) 
            {
                for (int col = 0; col < 9; col++) 
                {
                    grpBoard.Controls.Add(InitCell(x, y, $"txt{row}_{col}"));
                    x += CellWidth + spacer; 
                }
                y += CellWidth + spacer;
                x = 20; 
            }
             
        }

        private TextBox InitCell(int x, int y, string name)
        {
            Font font = new Font(FontFamily.GenericMonospace, 32, FontStyle.Bold);


            TextBox textBox = new TextBox()
            {
                Name = name, 
                Visible = true, 
                Text = "-", 
                ReadOnly = true, 
                Left = x, Top = y, 
                Height = 40, 
                Width = 40, 
                Font = font
            };
            return textBox;
        }
    }
}