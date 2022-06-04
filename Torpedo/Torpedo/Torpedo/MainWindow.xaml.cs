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
using Torpedo.View;

namespace Torpedo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void PlayerVsPlayer_Click(object sender, RoutedEventArgs e)
        {
            PlayerVsPlayerNameInput pvp = new();
            pvp.Show();
            this.Close();
        }

        private void ExitGame_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void GameHistory_Click(object sender, RoutedEventArgs e)
        {
            Scoreboard sc = new Scoreboard();
            sc.Show();
            this.Close();
        }
    }
}
