using System;
using System.Windows;

namespace Torpedo.View
{
    /// <summary>
    /// Interaction logic for PlayerVsPlayerNameInput.xaml
    /// </summary>
    public partial class PlayerVsPlayerNameInput : Window
    {
        public PlayerVsPlayerNameInput()
        {
            InitializeComponent();
        }

        private void BackButtonPvAInput_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void GameStart_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(FirstPlayerNameTextBox.Text) && !String.IsNullOrEmpty(SecondPlayerNameTextBox.Text))
            {
                PlaceShip ng = new PlaceShip(FirstPlayerNameTextBox.Text, SecondPlayerNameTextBox.Text);
                ng.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Hiba! A név megadása kötelező!","" ,MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
