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

namespace Torpedo.View
{
    public partial class Game : Window
    {
       

        public Game()
        {
            InitializeComponent();
            

        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void ExitFromGameButton_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
