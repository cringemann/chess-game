using System.Drawing;
using System.Windows.Controls;
using System.Windows.Input;
using Chess_Logic;

namespace Chess_UI
{
    /// <summary>
    /// Interaction logic for PromotionMenu.xaml
    /// </summary>
    public partial class PromotionMenu : UserControl
    {

        public event Action<PieceType> PieceSelected;
        public PromotionMenu(Player player, int pos)
        {
            InitializeComponent();

            QueenImg.Source = Images.GetImage(player, PieceType.Queen);
            KnightImg.Source = Images.GetImage(player, PieceType.Knight);
            RookImg.Source = Images.GetImage(player, PieceType.Rook);
            BishopImg.Source = Images.GetImage(player, PieceType.Bishop);
            Grid.SetColumn(PromMenuPos, pos);
            if (player == Player.Black)
                PromMenuPos.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
        }

        private void QueenImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PieceSelected?.Invoke(PieceType.Queen);
        }

        private void KnightImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PieceSelected?.Invoke(PieceType.Knight);
        }

        private void RookImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PieceSelected?.Invoke(PieceType.Rook);
        }

        private void BishopImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PieceSelected?.Invoke(PieceType.Bishop);
        }
    }
}
