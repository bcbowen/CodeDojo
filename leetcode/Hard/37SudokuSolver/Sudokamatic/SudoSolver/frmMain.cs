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
            int height = CellWidth; 
            for (int row = 0; row < 9; row++) 
            {
                for (int col = 0; col < 9; col++) 
                {
                    TextBox textBox = InitCell(x, y, $"txt{row}_{col}");
                    grpBoard.Controls.Add(textBox);
                    x += CellWidth + spacer;
                    height = textBox.Height;
                }
                y += height + spacer;
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

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void grpBoard_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);
            TextBox textBox = (TextBox)grpBoard.Controls["txt0_2"];
            int startY = textBox.Top;

            textBox = (TextBox)grpBoard.Controls["txt8_2"];
            int endY = textBox.Top + textBox.Height;
            int x = textBox.Left + textBox.Width + 5;
            graphics.DrawLine(pen, x, startY, x, endY);

            textBox = (TextBox)grpBoard.Controls["txt0_5"];
            x = textBox.Left + textBox.Width + 5;
            graphics.DrawLine(pen, x, startY, x, endY);

            textBox = (TextBox)grpBoard.Controls["txt0_0"];
            x = textBox.Left;
            graphics.DrawLine(pen, x, startY, x, endY);

            textBox = (TextBox)grpBoard.Controls["txt0_8"];
            x = textBox.Left + textBox.Width;
            graphics.DrawLine(pen, x, startY, x, endY);

            textBox = (TextBox)grpBoard.Controls["txt0_0"];
            int startX = textBox.Left;
            textBox = (TextBox)grpBoard.Controls["txt0_8"];
            int endX = textBox.Left + textBox.Width;
            int y = textBox.Top;
            graphics.DrawLine(pen, startX, y, endX, y);

            textBox = (TextBox)grpBoard.Controls["txt2_0"];
            y = textBox.Top + textBox.Height;
            graphics.DrawLine(pen, startX, y, endX, y);

            textBox = (TextBox)grpBoard.Controls["txt5_0"];
            y = textBox.Top + textBox.Height + 5;
            graphics.DrawLine(pen, startX, y, endX, y);

            textBox = (TextBox)grpBoard.Controls["txt8_0"];
            y = textBox.Top + textBox.Height + 5;
            graphics.DrawLine(pen, startX, y, endX, y);

        }
    }
}