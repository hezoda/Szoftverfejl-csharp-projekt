using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Torpedo.Model;
using Torpedo.View;

namespace Torpedo
{
    public partial class PlaceShip : Window
    {
        private readonly string _firstPlayerName;
        private readonly string _secondPlayerName;
        private string _selectedShip = null;
        
        private int _calculatedCell;
        private readonly int _rows = 10;
        private readonly int _columns = 10;

        private bool _shipHorizontal = false;
        private readonly bool _IsSecondPlayerPlacedShips;

        private char _selectedShipUnit;
        private readonly char[,] _battleShipPlayField = new char[10, 10];
        private readonly char[,] _firstPlayerBattleField = new char[10, 10];

        private readonly Grid _firstPlayerGridField;

        //KONSTRUKTOROK

        //_____________________________________________________________________________________________________________________________________________________
        public PlaceShip(string firstPlayerName, string secondPlayerName)
        {
            InitializeComponent();
            this._firstPlayerName = firstPlayerName;
            this._secondPlayerName = secondPlayerName;

            this.Title = firstPlayerName;
            welcomeLabel.Content = firstPlayerName + " éppen hajókat helyez el";
        }
        public PlaceShip(string firstPlayerName, string secondPlayerName, Grid playfield, char[,] battleshipPlayfield)
        {
            InitializeComponent();

            _IsSecondPlayerPlacedShips = true;
            this._firstPlayerName = firstPlayerName;
            this._secondPlayerName = secondPlayerName;
            this._firstPlayerBattleField = battleshipPlayfield;
            this._firstPlayerGridField = playfield;

            this.Title = secondPlayerName;
            welcomeLabel.Content = secondPlayerName + " éppen hajókat helyez el";

        }
        //_____________________________________________________________________________________________________________________________________________________

        //HAJÓ METÓDUSOK

        //_____________________________________________________________________________________________________________________________________________________

        private Rectangle DefineShips()
        {
            Rectangle ship = new Rectangle()
            {
                Fill = Brushes.BlueViolet
            };
            Position position = new Position(userBattleField.Width / _rows, userBattleField.Height / _columns);
            ship.Width = position.X;
            ship.Height = position.Y;
            ship.Name = _selectedShip;
            return ship;

        }

        private int CalculateShipLength()
        {
            int length = _selectedShip switch
            {
                "Carrier" => 5,
                "Battleship" => 4,
                "Cruiser" => 3,
                "Submarine" => 2,
                "Destroyer" => 1,
                _ => 0,
            };
            return length;
        }

        private bool ShipCollision(int i, int cell, int shipLength, bool _shipHorizontal)
        {
            for (int unit = 0 + i; unit < shipLength; unit++)
            {
                if (_shipHorizontal)
                {
                    if (char.IsDigit(_battleShipPlayField[cell / _rows, cell % _columns + unit]))
                    {
                        return true;
                    }
                }
                else if (!_shipHorizontal)
                {
                    if (char.IsDigit(_battleShipPlayField[cell / _rows + unit, cell % _columns]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool ShipExtendsBeyond(int cell, int shipLength, bool _shipHorizontal)
        {
            if (_shipHorizontal)
            {
                if (cell / _rows < _rows && cell % _columns + shipLength - 1 < _columns)
                {
                    return false;
                }
            }
            else if (!_shipHorizontal)
            {
                if (cell / _rows + shipLength - 1 < _rows && cell % _columns < _columns)
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsEveryShipPlaced()
        {
            if (!carrierBtn.IsEnabled && !battleShipGroupButton.IsEnabled && !cruiserBtn.IsEnabled && !submarineBtn.IsEnabled && !destroyerBtn.IsEnabled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void PlaceShipToPlayField(Rectangle ship, int i, int cell, bool _shipHorizontal)
        {
            if (_shipHorizontal)
            {
                Grid.SetRow(ship, cell / _rows);
                Grid.SetColumn(ship, cell % _columns + i);

                //save the ship position
                _battleShipPlayField[cell / _rows, cell % _columns + i] = _selectedShipUnit;
            }
            else if (!_shipHorizontal)
            {
                Grid.SetRow(ship, cell / _rows + i);
                Grid.SetColumn(ship, cell % _columns);

                //save the ship position
                _battleShipPlayField[cell / _rows + i, cell % _columns] = _selectedShipUnit;
            }

            userBattleField.Children.Add(ship);
        }

        private void RotateShip()
        {
            _shipHorizontal = !_shipHorizontal;
        }

        private int CalculateCell() //which cell the cursor is on
        {
            var point = Mouse.GetPosition(userBattleField);

            int row = 0;
            int col = 0;
            double accumulatedHeight = 0.0;
            double accumulatedWidth = 0.0;

            foreach (var rowDefinition in userBattleField.RowDefinitions)
            {
                accumulatedHeight += rowDefinition.ActualHeight;
                if (accumulatedHeight >= point.Y)
                    break;
                row++;
            }

            foreach (var columnDefinition in userBattleField.ColumnDefinitions)
            {
                accumulatedWidth += columnDefinition.ActualWidth;
                if (accumulatedWidth >= point.X)
                    break;
                col++;
            }

            return (row * 10) + col;
        }
        //_____________________________________________________________________________________________________________________________________________________

        //BUTTON METÓDUSOK

        //_____________________________________________________________________________________________________________________________________________________

        private void OnGridMouseClick(object sender, MouseButtonEventArgs e) //ship placement in the playfield
        {
            if (e.ClickCount == 1)
            {
                int shipLength = CalculateShipLength();
                bool shipPlacementEnoughSpace = true;

                for (int i = 0; i < shipLength; i++)
                {
                    int cell = CalculateCell();

                    Rectangle ship = DefineShips();

                    //enough space for the selected ship or not
                    shipPlacementEnoughSpace = !ShipExtendsBeyond(cell, shipLength, _shipHorizontal);

                    //collision with another ship
                    if (shipPlacementEnoughSpace)
                    {
                        shipPlacementEnoughSpace = !ShipCollision(i, cell, shipLength, _shipHorizontal);
                    }

                    if (shipPlacementEnoughSpace)
                    {
                        PlaceShipToPlayField(ship, i, cell, _shipHorizontal);
                    }
                    else
                    {
                        break;
                    }
                }

                if (shipPlacementEnoughSpace)
                {
                    DisableSelectedShipButton();
                }
            }
        }

        private void ShipGroupButton(object sender, RoutedEventArgs e) //select ship type
        {
            var ShipButton = (Button)sender;
            _selectedShip = ShipButton.Content.ToString();

            switch (_selectedShip)
            {
                case "Carrier":
                    _selectedShipUnit = '5';
                    break;
                case "Battleship":
                    _selectedShipUnit = '4';
                    break;
                case "Cruiser":
                    _selectedShipUnit = '3';
                    break;
                case "Submarine":
                    _selectedShipUnit = '2';
                    break;
                case "Destroyer":
                    _selectedShipUnit = '1';
                    break;
            }
        }

        private void DisableSelectedShipButton()
        {
            switch (_selectedShip) //placed ship button set disabled
            {
                case "Carrier":
                    carrierBtn.IsEnabled = false;
                    break;
                case "Battleship":
                    battleShipGroupButton.IsEnabled = false;
                    break;
                case "Cruiser":
                    cruiserBtn.IsEnabled = false;
                    break;
                case "Submarine":
                    submarineBtn.IsEnabled = false;
                    break;
                case "Destroyer":
                    destroyerBtn.IsEnabled = false;
                    break;
            }

            _selectedShip = null;
        }

        private void ResetButtonClick(object sender, RoutedEventArgs e)
        {
            _selectedShip = null;
            _calculatedCell = -1;

            carrierBtn.IsEnabled = true;
            battleShipGroupButton.IsEnabled = true;
            cruiserBtn.IsEnabled = true;
            submarineBtn.IsEnabled = true;
            destroyerBtn.IsEnabled = true;

            userBattleField.Children.Clear();

            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _columns; col++)
                {
                    _battleShipPlayField[row, col] = '\0';
                }
            }
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            if (IsEveryShipPlaced())
            {
                if (_IsSecondPlayerPlacedShips)
                {
                    Game firstPlayerBattleFieldWindow = new(_firstPlayerName, _firstPlayerGridField, _firstPlayerBattleField, _secondPlayerName, userBattleField, _battleShipPlayField);
                    App.Current.MainWindow = firstPlayerBattleFieldWindow;
                    this.Close();
                    firstPlayerBattleFieldWindow.Show();
                }
                else
                {
                    PlaceShip secondPlayerPlaceShipWindow = new(_firstPlayerName, _secondPlayerName, userBattleField, _battleShipPlayField);
                    App.Current.MainWindow = secondPlayerPlaceShipWindow;
                    this.Close();
                    secondPlayerPlaceShipWindow.Show();
                }
            }
            else
            {
                MessageBox.Show("Rakj le minden hajót a kezdéshez","Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void ExitFromGameButton_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);

        }
        //_____________________________________________________________________________________________________________________________________________________

        //KEY_DOWN METÓDUSOK

        private void ApplyInputKey(Key pressedKey)
        {
            if (pressedKey == Key.Space)
            {
                RotateShip();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            ApplyInputKey(e.Key);
        }
        //_____________________________________________________________________________________________________________________________________________________
        
    }
}
