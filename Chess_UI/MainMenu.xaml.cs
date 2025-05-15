using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Chess_UI
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public event Action<Option> OptionSelected;
        public event Action<string> TextEnteredForBlack;
        public event Action<string> TextEnteredForWhite;
        public MainMenu()
        {
            InitializeComponent();
        }

        private void NoneBorder_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.TimeNone);
        }

        private void BulletBorder10_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.TimeBullet10);
        }

        private void BulletBorder11_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.TimeBullet11);
        }

        private void BlitzBorder30_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.TimeBlitz30);
        }

        private void BlitzBorder32_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.TimeBlitz32);
        }

        private void RapidBorder10_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.TimeRapid10);
        }

        private void RapidBorder30_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.TimeRapid30);
        }

        private void FlipBorder_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.FlipBoard);
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Start);
        }

        private void ExitGame1B_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Exit);
        }


        private void BlackNameTextBox_KeyDwn(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextEnteredForBlack?.Invoke(BlackNameTextBox.Text);
               // e.Handled = true;
            }
        }

        private void WhiteNameTextBox_KeyDwn(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextEnteredForWhite?.Invoke(WhiteNameTextBox.Text);
               // e.Handled = true;
            }
        }
    }
}
