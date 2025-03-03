namespace EightPuzzleProblem
{
    public partial class Game : Form
    {
        private int[,] board = new int[3, 3];
        private Button[,] buttons;
        private int emptyRow, emptyCol;
        private Random rand = new Random();
        private System.Windows.Forms.Timer timer;
        private int secondsElapsed;

        public Game()
        {
            InitializeComponent();
            buttons = new Button[,] { { btn1, btn2, btn3 }, { btn4, btn5, btn6 }, { btn7, btn8, btn0 } };
            BindEvents();
            InitializeTimer();
            StartGame();
        }

        private void StartGame()
        {
            List<int> numbers = Enumerable.Range(0, 9).OrderBy(x => rand.Next()).ToList();
            for (int i = 0, k = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++, k++)
                {
                    board[i, j] = numbers[k];
                    buttons[i, j].Text = numbers[k] == 0 ? "" : numbers[k].ToString();
                    if (numbers[k] == 0)
                    {
                        emptyRow = i;
                        emptyCol = j;
                        buttons[i, j].BackColor = Color.Black;
                    }
                    else
                    {
                        buttons[i, j].BackColor = Color.FloralWhite;
                    }
                }
            }
            secondsElapsed = 0;
            timer.Start();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null) return;

            int clickedRow = -1, clickedCol = -1;
            bool found = false;
            for (int i = 0; i < 3 && !found; i++)
            {
                for (int j = 0; j < 3 && !found; j++)
                {
                    if (buttons[i, j] == clickedButton)
                    {
                        clickedRow = i;
                        clickedCol = j;
                        found = true;
                    }
                }
            }

            bool isAdjacent = (Math.Abs(clickedRow - emptyRow) + Math.Abs(clickedCol - emptyCol)) == 1;

            if (isAdjacent)
            {
                string tempText = buttons[clickedRow, clickedCol].Text;
                int tempValue = board[clickedRow, clickedCol];

                buttons[clickedRow, clickedCol].Text = "";
                buttons[emptyRow, emptyCol].Text = tempText;

                board[emptyRow, emptyCol] = tempValue;
                board[clickedRow, clickedCol] = 0;

                buttons[clickedRow, clickedCol].BackColor = Color.Black;
                buttons[emptyRow, emptyCol].BackColor = Color.FloralWhite;

                emptyRow = clickedRow;
                emptyCol = clickedCol;

                if (CheckWin())
                {
                    timer.Stop();
                    MessageBox.Show($"Tebrikler! Kazandınız! Süre: {secondsElapsed / 60:D2}:{secondsElapsed % 60:D2}");
                }
            }
        }

        private bool CheckWin()
        {
            int count = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] != count % 9) return false;
                    count++;
                }
            }
            return true;
        }

        private void BindEvents()
        {
            foreach (Button btn in buttons)
            {
                btn.Click += ButtonClick;
            }
        }

        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) => 
            { 
                secondsElapsed++; 
                int minutes = secondsElapsed / 60;
                int seconds = secondsElapsed % 60;
                lblTimer.Text = $"{minutes:D2}:{seconds:D2}";
            };
        }

        private void GameControlButton_Click(object sender, EventArgs e)
        {
            if (sender == btnClose)
            {
                Application.Exit();
            }
            else 
            {
                StartGame();
            }
        }

    }
}
