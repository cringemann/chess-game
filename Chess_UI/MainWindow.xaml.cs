using System.Diagnostics.Eventing.Reader;
using System.Security.Permissions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Chess_Logic;

namespace Chess_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Image[,] PieceImages = new Image[8, 8];
        private readonly Rectangle[,] highlights = new Rectangle[8, 8];
        private readonly Rectangle[,] highlightsMoves = new Rectangle[8, 8];
        private readonly Dictionary<Position, Move> moveCache = new Dictionary<Position, Move>();
        private readonly Dictionary<Position, Move> enPassantCache = new Dictionary<Position, Move>();
        private Move previousMove;
        private bool IsGameRestarted = false;
        private bool NeedToRotate = false;
        private bool isFlipped = false;
        private bool IsPromMenuOn = false;
        private bool IsGameStarted = false;

        private int initialTime = 10000;
        private int initialAdditionTime = 0;
        private int whitePlayerTime;
        private int blackPlayerTime;
        private DispatcherTimer gameTimer;

        private GameState gameState;
        private Position selectedPos = null;


        public MainWindow()
        {
            InitializeComponent();
            ShowMainMenu();
            InitializeBoard();
            gameState = new GameState(Player.White, Board.Initial());
            DrawBoard(gameState.Board);

            gameTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1) 
            };
            whitePlayerTime = initialTime;
            blackPlayerTime = initialTime;
            gameTimer.Tick += OnTimerTick;
            gameTimer.Start();
            
        }
        private void OnTimerTick(object sender, EventArgs e)
        {
            if (gameState.CurrentPlayer == Player.White && whitePlayerTime > 0 && (MenuContainer.Content == null || (MenuContainer.Content != null && IsPromMenuOn)))
            {
                whitePlayerTime--;
                Timer1.Text = FormatTime(whitePlayerTime);
            }
            else if (gameState.CurrentPlayer == Player.Black && blackPlayerTime > 0 && MenuContainer.Content == null)
            {
                blackPlayerTime--;
                Timer2.Text = FormatTime(blackPlayerTime);
            }

            if (whitePlayerTime <= 0)
            {
                gameState.Result = new Result(Player.Black, EndReason.OnTime);
                ShowMenu();
                gameTimer.Stop();
            }
            else if (blackPlayerTime <= 0)
            {
                gameState.Result = new Result(Player.White, EndReason.OnTime);
                ShowMenu();
                gameTimer.Stop();
            }
        }

        private string FormatTime(int totalSeconds)
        {
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            return $"{minutes:D2}:{seconds:D2}";
        }


        private void InitializeBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Image image = new Image();
                    PieceImages[i, j] = image;
                    PieceGrid.Children.Add(image);

                    Rectangle highlight = new Rectangle
                    {
                        Width = 32, 
                        Height = 32, 
                        RadiusX = 16,    
                        RadiusY = 16
                    };

                    Rectangle highlightMove = new Rectangle
                    {
                        Width = 100,
                        Height = 100,
                    };

                    highlights[i, j] = highlight;
                    highlightsMoves[i, j] = highlightMove;  
                    MoveHighLightGrid.Children.Add(highlightMove);
                    HighLightGrid.Children.Add(highlight);
                }
            }
        }

        private void DrawBoard(Board board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j=0; j < 8; j++)
                {
                    Piece piece = board[i, j];
                    PieceImages[i, j].Source = Images.GetImage(piece);
                    if (NeedToRotate)
                    {
                        if (PieceImages[i, j].RenderTransform is RotateTransform rotateTransform)
                        {
                            rotateTransform.Angle = isFlipped ? 180 : 0;
                        }
                        else
                        {
                            PieceImages[i, j].RenderTransform = new RotateTransform(isFlipped ? 180 : 0);
                            PieceImages[i, j].RenderTransformOrigin = new Point(0.5, 0.5);
                        }
                    }
                }    
            }
        }

        private void BoardGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(BoardGrid);
            Position pos = ToSquarePosition(point);
            if (whitePlayerTime > 0 && blackPlayerTime > 0)
            {
                if (selectedPos == null)
                {
                    OnFromPositionSelected(pos);
                }
                else
                {
                    OnTwoPositionSelected(pos);
                }
            }
        }

        private Position ToSquarePosition(Point point)
        {
            double squareSize = BoardGrid.ActualWidth / 8;
            int row = (int)(point.Y / squareSize);
            int col = (int)(point.X / squareSize);
            return new Position(row, col);
        }

        private void OnFromPositionSelected(Position pos)
        {
            IEnumerable<Move> moves = gameState.LegalMovesForPiece(pos);
            if (moves.Any())
            {
                selectedPos = pos;
                CacheMoves(moves);
                ShowHighLights();
            }
        }

        private void OnTwoPositionSelected(Position pos)
        {
            selectedPos = null;
            HideHighLights();

            if (moveCache.TryGetValue(pos, out Move move))
            {
                if (move.Type == MoveType.PawnPromotion)
                {
                    HandlePromotion(move.FromPos, move.ToPos);
                }
                else
                {
                    HandleMove(move);
                }
            }
        }

        private void HandlePromotion(Position from, Position to) 
        {
            PieceImages[to.Row, to.Column].Source = Images.GetImage(gameState.CurrentPlayer, PieceType.Pawn);
            PieceImages[from.Row, from.Column].Source = null;

            if (!isFlipped)
            {
                PromotionMenu PromMenu = new PromotionMenu(gameState.CurrentPlayer, to.Column);

                IsPromMenuOn = true;

                MenuContainer.Content = PromMenu;

                PromMenu.PieceSelected += type =>
                {
                    MenuContainer.Content = null;
                    Move promMove = new PawnPromotion(from, to, type);
                    HandleMove(promMove);
                    IsPromMenuOn = false;
                };
            }
            else
            {
                PromotionMenu PromMenu = new PromotionMenu(gameState.CurrentPlayer.Opponent(), 7 - to.Column);

                IsPromMenuOn = true;

                MenuContainer.Content = PromMenu;

                PromMenu.PieceSelected += type =>
                {
                    MenuContainer.Content = null;
                    Move promMove = new PawnPromotion(from, to, type);
                    HandleMove(promMove);
                    IsPromMenuOn = false;
                };
            }
        }


        private void HandleMove(Move move)
        {
            if (!IsGameStarted)
                IsGameStarted = true;

            if (previousMove != null && previousMove.Type != MoveType.CastleKS && previousMove.Type!= MoveType.CastleQS)
            {
                highlightsMoves[previousMove.FromPos.Row, previousMove.FromPos.Column].Fill = Brushes.Transparent;
                highlightsMoves[previousMove.ToPos.Row, previousMove.ToPos.Column].Fill = Brushes.Transparent;
            }
            else if (previousMove != null && previousMove.Type == MoveType.CastleKS)
            {
                highlightsMoves[previousMove.FromPos.Row, previousMove.FromPos.Column].Fill = Brushes.Transparent;
                highlightsMoves[previousMove.FromPos.Row, previousMove.FromPos.Column+3].Fill = Brushes.Transparent;
            }
            else if (previousMove != null && previousMove.Type == MoveType.CastleQS)
            {
                highlightsMoves[previousMove.FromPos.Row, previousMove.FromPos.Column].Fill = Brushes.Transparent;
                highlightsMoves[previousMove.FromPos.Row, previousMove.FromPos.Column-4].Fill = Brushes.Transparent;
            }
            gameState.MakeMove(move);
            DrawBoard(gameState.Board);
            Color color = Color.FromArgb(95, 247, 255, 0);
            if (move.Type == MoveType.CastleKS)
            {
                highlightsMoves[move.FromPos.Row, move.FromPos.Column].Fill = new SolidColorBrush(color);
                highlightsMoves[move.FromPos.Row, move.ToPos.Column+1].Fill = new SolidColorBrush(color);
            }
            else if (move.Type == MoveType.CastleQS)
            {
                highlightsMoves[move.FromPos.Row, move.FromPos.Column].Fill = new SolidColorBrush(color);
                highlightsMoves[move.FromPos.Row, move.ToPos.Column - 2].Fill = new SolidColorBrush(color);
            }
            else
            {
                highlightsMoves[move.FromPos.Row, move.FromPos.Column].Fill = new SolidColorBrush(color);
                highlightsMoves[move.ToPos.Row, move.ToPos.Column].Fill = new SolidColorBrush(color);
            }

            if (gameState.CurrentPlayer == Player.White && initialTime != 1000000000)
            {
                Timer2.Text = FormatTime(blackPlayerTime);

                Timer2Border.Background = new SolidColorBrush(Color.FromRgb(32, 32, 32));
                Timer1Border.Background = new SolidColorBrush(Colors.LightGray);
                Timer1.Foreground = new SolidColorBrush(Colors.Black);
                Timer2.Foreground = new SolidColorBrush(Colors.White);
            }
            else if (gameState.CurrentPlayer == Player.Black && initialTime != 1000000000)
            {
                Timer1.Text = FormatTime(whitePlayerTime);
                Timer1Border.Background = new SolidColorBrush(Color.FromRgb(32, 32, 32));
                Timer2Border.Background = new SolidColorBrush(Colors.LightGray);
                Timer2.Foreground = new SolidColorBrush(Colors.Black);
                Timer1.Foreground = new SolidColorBrush(Colors.White);

            }
            if (initialAdditionTime > 0)
            {
                if (gameState.CurrentPlayer == Player.Black)
                {
                    whitePlayerTime += initialAdditionTime;
                    Timer1.Text = FormatTime(whitePlayerTime);
                }
                else if (gameState.CurrentPlayer == Player.White)
                {
                    blackPlayerTime += initialAdditionTime;
                    Timer2.Text = FormatTime(blackPlayerTime);
                }
            }
            if (NeedToRotate)
                FlipBoard();

            previousMove = move;
            if (gameState.Result != null)
            {
                gameTimer.Stop();
                ShowMenu();
            }

        }

        private void FlipBoard()
        {
            isFlipped = !isFlipped;
            BoardTransform.ScaleY = isFlipped ? -1 : 1;
            BoardTransform.ScaleX = isFlipped ? -1 : 1;
            double flipAngle = isFlipped ? 180 : 0;

            BoardTransform.ScaleY = isFlipped ? -1 : 1;


            foreach (var piece in PieceGrid.Children)
            {
                if (piece is Image img && img.RenderTransform is RotateTransform rotateTransform)
                {
                    rotateTransform.Angle = flipAngle;
                }
            }
        }
    

        private void CacheMoves(IEnumerable<Move> moves)
        {
            moveCache.Clear();
            enPassantCache.Clear();

            foreach (Move move in moves)
            {
                moveCache[move.ToPos] = move;
                if (move.Type == MoveType.EnPassant)
                    enPassantCache[move.ToPos] = move;
            }
        }

        private void ShowHighLights()
        {
            Color color = Color.FromArgb(85, 0, 0, 0);
            foreach (Position to in moveCache.Keys)
            {
                Position pos = new Position(to.Row, to.Column);
                if (!gameState.Board.IsEmpty(pos))
                {
                    highlights[to.Row, to.Column].Width = 72;
                    highlights[to.Row, to.Column].Height = 72;
                    highlights[to.Row, to.Column].RadiusX = 36;
                    highlights[to.Row, to.Column].RadiusY = 36;
                    highlights[to.Row, to.Column].Stroke = new SolidColorBrush(color);
                    highlights[to.Row, to.Column].StrokeThickness = 10;
                }
                else 
                    highlights[to.Row, to.Column].Fill = new SolidColorBrush(color);
            }
            foreach (Position to in enPassantCache.Keys)
            {
                highlights[to.Row, to.Column].Width = 72;
                highlights[to.Row, to.Column].Height = 72;
                highlights[to.Row, to.Column].RadiusX = 36;
                highlights[to.Row, to.Column].RadiusY = 36;
                highlights[to.Row, to.Column].Stroke = new SolidColorBrush(color);
                highlights[to.Row, to.Column].StrokeThickness = 10;
                highlights[to.Row, to.Column].Fill = null;
            }
                BoardGrid.Cursor = Cursors.Hand;
        }

        private void HideHighLights()
        {
            foreach (Position to in moveCache.Keys)
            {
                highlights[to.Row, to.Column].Width = 32;
                highlights[to.Row, to.Column].Height = 32;
                highlights[to.Row, to.Column].RadiusX = 16;
                highlights[to.Row, to.Column].RadiusY = 16;
                highlights[to.Row, to.Column].Fill = Brushes.Transparent;
                highlights[to.Row, to.Column].StrokeThickness = 0;
                highlights[to.Row, to.Column].Stroke = Brushes.Transparent;
                BoardGrid.Cursor = Cursors.Arrow;
            }
            if (IsGameRestarted == true && IsGameStarted)
            {
                highlightsMoves[previousMove.FromPos.Row, previousMove.FromPos.Column].Fill = Brushes.Transparent;
                highlightsMoves[previousMove.ToPos.Row, previousMove.ToPos.Column].Fill = Brushes.Transparent;
            }
        }

        private void ShowMenu()
        {
            GameOverMenu gameOverMenu = new GameOverMenu(gameState);
            MenuContainer.Content = gameOverMenu;

            gameOverMenu.OptionSelected += option =>
            {
                if (option == Option.Restart)
                {
                    MenuContainer.Content = null;
                    RestartGame();
                }
                else if (option == Option.MainMenu)
                {
                    RestartGame();
                    ShowMainMenu();
                }
                else
                {
                    Application.Current.Shutdown();
                }
            };
        }

        private void RestartGame()
        {
            IsPromMenuOn = false;
            NeedToRotate = false;
            IsGameRestarted = true;
            selectedPos = null;
            HideHighLights();
            moveCache.Clear();
            gameState = new GameState(Player.White, Board.Initial());
            DrawBoard(gameState.Board);
            if (isFlipped)
            {
                FlipBoard();
            }
            gameTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            whitePlayerTime = initialTime;
            blackPlayerTime = initialTime;
            if (initialTime != 1000000000)
            {
                Timer1.Text = FormatTime(whitePlayerTime);
                Timer2.Text = FormatTime(blackPlayerTime);
                Timer1Border.Background = Brushes.LightGray;
                Timer1.Foreground = new SolidColorBrush(Color.FromRgb(32, 32, 32));
                Timer2Border.Background = new SolidColorBrush(Color.FromRgb(32, 32, 32));
                Timer2.Foreground = Brushes.LightGray;
            }

            gameTimer.Start();
            IsGameRestarted = false;
            IsGameStarted = false;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (MenuContainer.Content == null  && gameState.Result == null && e.Key == Key.Escape)
            {
                ShowPauseMenu();
            }
            else if (MenuContainer.Content != null && gameState.Result == null && e.Key == Key.Escape)
            {
                MenuContainer.Content = null;
            }
        }

        private void ShowPauseMenu()
        {
            PauseMenu pauseMenu = new PauseMenu();
            MenuContainer.Content = pauseMenu;

            pauseMenu.OptionSelected += option =>
            {
                MenuContainer.Content = null;
                if (option == Option.Restart)
                    RestartGame();
                else if (option == Option.Exit)
                    Application.Current.Shutdown();
                else if (option == Option.MainMenu)
                {
                    RestartGame();
                    ShowMainMenu();
                }
            };
        }

        private void NewTextForBlack(string enteredText)
        {
                BlackNameBox.Text = enteredText;
        }

        private void NewTextForWhite(string enteredText)
        {
                WhiteNameBox.Text = enteredText;
        }
        private void ShowMainMenu()
        {
            MainMenu mainMenu = new MainMenu();
            MenuContainer.Content = mainMenu;
            mainMenu.TextEnteredForBlack += NewTextForBlack;
            mainMenu.TextEnteredForWhite += NewTextForWhite;
            mainMenu.OptionSelected += option =>
            {
                if (option == Option.TimeNone)
                {
                    DeleteTimer();
                    ResetTimeButtons(mainMenu, mainMenu.NoneBorder);
                    mainMenu.NoneBorder.IsChecked = true;
                }
                else if (option == Option.TimeBullet10)
                {
                    ResetTimeButtons(mainMenu, mainMenu.BulletBorder10);
                    SetTimer(mainMenu, 60, 0);
                    mainMenu.BulletBorder10.IsChecked = true;
                }
                else if (option == Option.TimeBullet11)
                {
                    ResetTimeButtons(mainMenu, mainMenu.BulletBorder11);
                    SetTimer(mainMenu, 60, 1);
                    mainMenu.BulletBorder11.IsChecked = true;
                }
                else if (option == Option.TimeBlitz30)
                {
                    ResetTimeButtons(mainMenu, mainMenu.BlitzBorder30);
                    SetTimer(mainMenu, 180, 0);
                    mainMenu.BlitzBorder30.IsChecked = true;
                }
                else if (option == Option.TimeBlitz32)
                {
                    ResetTimeButtons(mainMenu, mainMenu.BlitzBorder32);
                    SetTimer(mainMenu, 180, 2);
                    mainMenu.BlitzBorder32.IsChecked = true;
                }
                else if (option == Option.TimeRapid10)
                {
                    ResetTimeButtons(mainMenu, mainMenu.RapidBorder10);
                    SetTimer(mainMenu, 600, 0);
                    mainMenu.RapidBorder10.IsChecked = true;
                }
                else if (option == Option.TimeRapid30)
                {
                    ResetTimeButtons(mainMenu, mainMenu.RapidBorder30);
                    SetTimer(mainMenu, 1800, 0);
                    mainMenu.RapidBorder30.IsChecked = true;
                }

                if (option == Option.FlipBoard && mainMenu.FlipBorderBorder1.IsChecked == true)
                {
                    NeedToRotate = true;
                }
                else if (option == Option.FlipBoard && mainMenu.FlipBorderBorder1.IsChecked == false)
                {
                    NeedToRotate = false;
                }
                if (option == Option.Start && initialTime != 10000)
                {
                    MenuContainer.Content = null;
                }
                else if (option == Option.Start && initialTime == 10000)
                {
                    mainMenu.Error1.Foreground = Brushes.Red;
                }
                if (option == Option.Exit)
                {
                    Application.Current.Shutdown();
                }
            };
        }

        private void SetTimer(MainMenu mainMenu, int time, int addition)
        {
            mainMenu.Error1.Foreground = Brushes.Transparent;
            Timer2Border.Background = new SolidColorBrush(Color.FromRgb(32, 32, 32));
            Timer2.Foreground = Brushes.LightGray;
            Timer1Border.Background = new SolidColorBrush(Color.FromRgb(32, 32, 32));
            Timer1.Foreground = Brushes.LightGray;
            initialTime = time;
            whitePlayerTime = initialTime;
            blackPlayerTime = initialTime;
            Timer1Border.Background = Brushes.LightGray;
            Timer1.Foreground = new SolidColorBrush(Color.FromRgb(32, 32, 32));
            Timer1.Text = FormatTime(whitePlayerTime);
            Timer2.Text = FormatTime(blackPlayerTime);
            if (addition != 0)
                initialAdditionTime = addition;
        }
        private void ResetTimeButtons(MainMenu mainMenu, ToggleButton selectedButton)
        {
            List<ToggleButton> timeButtons = new List<ToggleButton>
            {
                mainMenu.NoneBorder,
                mainMenu.BulletBorder10,
                mainMenu.BulletBorder11,
                mainMenu.BlitzBorder30,
                mainMenu.BlitzBorder32,
                mainMenu.RapidBorder10,
                mainMenu.RapidBorder30
            };

            foreach (var button in timeButtons)
            {
                if (button != selectedButton)
                {
                    button.IsChecked = false;
                }
            }
        }



        private void DeleteTimer()
        {
            initialTime = 1000000000;
            whitePlayerTime = initialTime;
            blackPlayerTime = initialTime;
            Timer2Border.Background = Brushes.Transparent;
            Timer2.Foreground = Brushes.Transparent;
            Timer1Border.Background = Brushes.Transparent;
            Timer1.Foreground = Brushes.Transparent;
        }
    }
}