using Chess_Logic;
using System.Windows;
using System.Windows.Controls;

namespace Chess_UI
{
    /// <summary>
    /// Interaction logic for GameOverMenu.xaml
    /// </summary>
    public partial class GameOverMenu : UserControl
    {
        public event Action<Option> OptionSelected;
        public GameOverMenu(GameState gameState)
        {
            InitializeComponent();
            Result result = gameState.Result;
            WinnerText.Text = GetWinnerText(result.Winner);
            ReasonText.Text = GetReasonText(result.Reason);
        }

        private static string GetWinnerText(Player winner)
        {
            return winner switch
            {
                Player.White => "White won",
                Player.Black => "Black won",
                _ => "Draw"
            };
        }

        private static string PlayerString(Player player)
        {
            return player switch
            {
                Player.White => "White",
                Player.Black => "Black",
                _ => ""
            };
        }

        private static string GetReasonText(EndReason reason)
        {
            return reason switch
            {
                EndReason.Checkmate => "By checkmate",
                EndReason.Stalemate => "Stalemate",
                EndReason.OnTime => "On time",
                EndReason.FiftyMoveRule => "Fifty-Move rule",
                EndReason.InsufficientMaterial => "Insufficient Material",
                EndReason.ThreefoldRepetition => "Threefold repetition",
                _ => ""
            };
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Restart);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Exit);
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.MainMenu);
        }
    }
}
