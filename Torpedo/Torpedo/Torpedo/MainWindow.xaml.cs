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

        private void PlayerVsAI_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            View.PlayerVsAINameInput win2 = new View.PlayerVsAINameInput();
            win2.Show();
            this.Close();

        }
        private void PlayerVsPlayer_Click(object sender, RoutedEventArgs e)
        {
            View.PlayerVsPlayerNameInput pvp = new View.PlayerVsPlayerNameInput();
            pvp.Show();
            this.Close();
        }

        private void ExitGame_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
