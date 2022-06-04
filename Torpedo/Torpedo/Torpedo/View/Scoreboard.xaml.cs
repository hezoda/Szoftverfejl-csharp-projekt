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
using System.Windows.Shapes;
using Torpedo.Model;
using Torpedo.Repositories;

namespace Torpedo.View
{
    /// <summary>
    /// Interaction logic for Scoreboard.xaml
    /// </summary>
    public class DataItem
    {
        public long Id { get; set; }
        public string ElsoJatekosNeve { get; set; }
        public string MasodikJatekosNeve { get; set; }
        public string Nyertes { get; set; }
        public int ElsoJatekosTalalata { get; set; }
        public int MasodikJatekosTalalata { get; set; }
        public int KorokSzama { get; set; } 
    }
    public partial class Scoreboard : Window
    {
        public Scoreboard()
        {
            InitializeComponent();
            table.ItemsSource = ResultRepository.Eredmeny_Lekeres();
        }

        private void BacKButtonScoreboard_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
