using System.Text;

namespace EightPuzzleAStarSolution
{
    public partial class EightPuzzle : Form
    {
        private int[,] board = new int[3, 3];
        private int[,] goalState = new int[3, 3];
        private Button[,] buttons;
        private int emptyRow, emptyCol;
        private System.Windows.Forms.Timer timer;
        private int secondsElapsed;
        private bool isSettingInitialState = false;
        private List<PuzzleNode> solutionPath;
        private int currentMoveIndex = 0;
        private System.Windows.Forms.Timer moveTimer;

        public EightPuzzle()
        {
            InitializeComponent();
            buttons = new Button[,] { { btn1, btn2, btn3 }, { btn4, btn5, btn6 }, { btn7, btn8, btn0 } };
            InitializeGoalState();
            BindEvents();
            InitializeTimer();
            InitializeMoveTimer();
        }

        private void InitializeGoalState()
        {
            int count = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    goalState[i, j] = count % 9;
                    count++;
                }
            }
        }

        private void InitializeMoveTimer()
        {
            moveTimer = new System.Windows.Forms.Timer();
            moveTimer.Interval = 1000; 
            moveTimer.Tick += MoveTimer_Tick;
        }

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            if (solutionPath != null && currentMoveIndex < solutionPath.Count)
            {
                var currentNode = solutionPath[currentMoveIndex];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        board[i, j] = currentNode.State[i, j];
                        buttons[i, j].Text = board[i, j] == 0 ? "" : board[i, j].ToString();
                        if (board[i, j] == 0)
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
                
                if (currentMoveIndex > 0)
                {
                    lblTimer.Text = $"Hamle {currentMoveIndex}: Boş hücreyi {currentNode.Move} kaydır";
                }
                
                currentMoveIndex++;
            }
            else
            {
                moveTimer.Stop();
                timer.Stop(); 
                if (solutionPath != null)
                {
                    StringBuilder steps = new StringBuilder();
                    steps.AppendLine($"Toplam {solutionPath.Count - 1} adımda çözüm bulundu:");
                    for (int i = 1; i < solutionPath.Count; i++)
                    {
                        steps.AppendLine($"Adım {i}: Boş hücreyi {solutionPath[i].Move} kaydır");
                    }
                    MessageBox.Show(steps.ToString(), "Çözüm Yolu");
                    lblTimer.Text = "TAMAMLANDI!";
                }
            }
        }

        private List<PuzzleNode> SolveAStar()
        {
            try
            {
                var openList = new List<PuzzleNode>();
                var closedList = new HashSet<string>();
                var startNode = new PuzzleNode(board);
                startNode.CalculateHeuristic(goalState);
                openList.Add(startNode);

                int maxIterations = 100000;
                int currentIteration = 0;

                while (openList.Count > 0 && currentIteration < maxIterations)
                {
                    currentIteration++;

                    var current = openList[0];
                    var minF = current.F;
                    var minIndex = 0;

                    for (int i = 1; i < openList.Count; i++)
                    {
                        if (openList[i].F < minF)
                        {
                            current = openList[i];
                            minF = current.F;
                            minIndex = i;
                        }
                    }

                    openList.RemoveAt(minIndex);

                    string currentStateStr = StateToString(current.State);

                    if (currentStateStr == StateToString(goalState))
                    {
                        return ReconstructPath(current);
                    }

                    closedList.Add(currentStateStr);

                    foreach (var successor in GetSuccessors(current))
                    {
                        string successorStateStr = StateToString(successor.State);

                        if (closedList.Contains(successorStateStr))
                            continue;

                        successor.CalculateHeuristic(goalState);

                        bool found = false;
                        for (int i = 0; i < openList.Count; i++)
                        {
                            if (StateToString(openList[i].State) == successorStateStr)
                            {
                                found = true;
                                if (successor.G < openList[i].G)
                                {
                                    openList[i] = successor;
                                }
                                break;
                            }
                        }

                        if (!found)
                        {
                            openList.Add(successor);
                        }
                    }

                    if (currentIteration % 1000 == 0)
                    {
                        GC.Collect();
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A* algoritması çalışırken hata oluştu: {ex.Message}");
                return null;
            }
        }

        private string StateToString(int[,] state)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    sb.Append(state[i, j]);
            return sb.ToString();
        }

        private List<PuzzleNode> GetSuccessors(PuzzleNode node)
        {
            var successors = new List<PuzzleNode>();
            int emptyI = -1, emptyJ = -1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (node.State[i, j] == 0)
                    {
                        emptyI = i;
                        emptyJ = j;
                        break;
                    }
                }
                if (emptyI != -1) break;
            }

            int[][] moves = new int[][]
            {
                new int[] { -1, 0, 0 }, 
                new int[] { 1, 0, 1 },  
                new int[] { 0, -1, 2 },
                new int[] { 0, 1, 3 }   
            };

            string[] moveNames = { "yukarı", "aşağı", "sola", "sağa" };

            foreach (var move in moves)
            {
                int newI = emptyI + move[0];
                int newJ = emptyJ + move[1];

                if (newI >= 0 && newI < 3 && newJ >= 0 && newJ < 3)
                {
                    var newState = new int[3, 3];
                    Array.Copy(node.State, newState, node.State.Length);

                    newState[emptyI, emptyJ] = newState[newI, newJ];
                    newState[newI, newJ] = 0;

                    successors.Add(new PuzzleNode(newState, node, moveNames[move[2]]));
                }
            }

            return successors;
        }

        private List<PuzzleNode> ReconstructPath(PuzzleNode node)
        {
            var path = new List<PuzzleNode>();
            while (node != null)
            {
                path.Insert(0, node);
                node = node.Parent;
            }
            return path;
        }

        private async void StartSolving()
        {
            try
            {
                timer.Stop(); 
                secondsElapsed = 0; 
                lblTimer.Text = "Çözüm aranıyor...";
                
                if (!IsValidInitialState())
                {
                    MessageBox.Show("Geçersiz başlangıç durumu! Lütfen 1'den 8'e kadar olan tüm sayıların ve bir boş hücrenin olduğundan emin olun.");
                    return;
                }

                btnStart.Enabled = false;
                btnRestart.Enabled = false;

                var result = await Task.Run(() => SolveAStar());


                //solutionPath = SolveAStar();
                //if (solutionPath != null && solutionPath.Count > 0)
                //{
                //    currentMoveIndex = 0;
                //    lblTimer.Text = "Çözüm başlıyor...";
                //    moveTimer.Start();
                //    timer.Start(); // Süre sayacını tekrar başlat
                //}
                //else
                //{
                //    MessageBox.Show("Bu durum için çözüm bulunamadı!");
                //    lblTimer.Text = "Çözüm bulunamadı!";
                //}

                if (result != null && result.Count > 0)
                {
                    solutionPath = result;
                    currentMoveIndex = 0;
                    lblTimer.Text = "Çözüm başlıyor...";
                    moveTimer.Start();
                    timer.Start();
                }
                else
                {
                    MessageBox.Show("Bu durum için çözüm bulunamadı!");
                    lblTimer.Text = "Çözüm bulunamadı!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
                lblTimer.Text = "Hata oluştu!";
            }
            finally
            {
                btnStart.Enabled = true;
                btnRestart.Enabled = true;
            }
        }

        private bool IsValidInitialState()
        {
            bool[] numbers = new bool[9]; 
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int num = board[i, j];
                    if (num < 0 || num > 8) return false; 
                    if (numbers[num]) return false; 
                    numbers[num] = true;
                }
            }
            
            for (int i = 0; i < 9; i++)
            {
                if (!numbers[i]) return false;
            }
            
            return true;
        }

        private void GameControlButton_Click(object sender, EventArgs e)
        {
            if (sender == btnClose)
            {
                Application.Exit();
            }
            else if (sender == btnStart)
            {
                if (!isSettingInitialState)
                {
                    isSettingInitialState = true;
                    ClearBoard();
                    lblTimer.Text = "Sıradaki: 1";
                    MessageBox.Show("Başlangıç durumunu ayarlayın.\n" +
                                  "1. Tahtadaki boş hücrelere tıklayarak 1'den 8'e kadar olan taşları yerleştirin.\n" +
                                  "2. Taşları istediğiniz sırayla yerleştirebilirsiniz.\n" +
                                  "3. Son taş (8) yerleştirildiğinde boş hücre otomatik olarak son konuma yerleştirilecektir.");
                }
            }
            else if (sender == btnRestart)
            {
                if (!isSettingInitialState)
                {
                    StartSolving();
                }
                else
                {
                    MessageBox.Show("Lütfen önce başlangıç durumunu tamamlayın!\nTüm taşları (1-8) yerleştirmelisiniz.");
                }
            }
        }

        private void ClearBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = 0;
                    buttons[i, j].Text = "";
                    buttons[i, j].BackColor = Color.FloralWhite;
                }
            }
            emptyRow = 2;
            emptyCol = 2;
            buttons[emptyRow, emptyCol].BackColor = Color.Black;
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null) return;

            if (isSettingInitialState)
            {
                int nextNumber = GetNextNumber();
                if (nextNumber <= 8)
                {
                    if (clickedButton.Text != "") 
                    {
                        MessageBox.Show("Bu hücre zaten dolu! Lütfen boş bir hücre seçin.");
                        return;
                    }

                    clickedButton.Text = nextNumber.ToString();
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (buttons[i, j] == clickedButton)
                            {
                                board[i, j] = nextNumber;
                                buttons[i, j].BackColor = Color.FloralWhite;
                                
                                if (nextNumber == 8)
                                {
                                    isSettingInitialState = false;
                                    for (int x = 0; x < 3; x++)
                                    {
                                        for (int y = 0; y < 3; y++)
                                        {
                                            if (board[x, y] == 0)
                                            {
                                                buttons[x, y].Text = "";
                                                buttons[x, y].BackColor = Color.Black;
                                                emptyRow = x;
                                                emptyCol = y;
                                            }
                                        }
                                    }
                                    MessageBox.Show($"Başlangıç durumu ayarlandı:\n\n{GetBoardState()}\n\nÇözümü başlatmak için RESTART butonuna tıklayın.");
                                }
                                else
                                {
                                    lblTimer.Text = $"Sıradaki: {nextNumber + 1}";
                                }
                                return;
                            }
                        }
                    }
                }
            }
            else
            {
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
        }

        private int GetNextNumber()
        {
            for (int num = 1; num <= 8; num++)
            {
                bool found = false;
                for (int i = 0; i < 3 && !found; i++)
                {
                    for (int j = 0; j < 3 && !found; j++)
                    {
                        if (board[i, j] == num)
                        {
                            found = true;
                        }
                    }
                }
                if (!found)
                {
                    return num;
                }
            }
            return 9; 
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
            btnStart.Click += GameControlButton_Click;
            btnRestart.Click += GameControlButton_Click;
            btnClose.Click += GameControlButton_Click;
            
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

        private string GetBoardState()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sb.Append(board[i, j] == 0 ? " " : board[i, j].ToString());
                    sb.Append(" ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

    }
}
