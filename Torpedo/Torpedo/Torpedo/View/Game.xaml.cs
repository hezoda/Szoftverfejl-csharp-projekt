using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Torpedo.Model;
using Torpedo.Repositories;

namespace Torpedo.View
{
    public partial class Game : Window
    {
        private readonly int _rows = 10;
        private readonly int _columns = 10;
        private readonly char[,] _myPlayField = new char[10, 10];
        private readonly char[,] _enemyPlayField = new char[10, 10];
        private readonly bool _firstPlayerWindow;
        private readonly string _firstPlayerName;
        private readonly string _secondPlayerName;

        private int _roundCounter = 0;
        private bool _isFirstPlayerTurns;

        readonly Game secondPlayerWindowObject;
        readonly Random rnd = new Random();
      
        public delegate string Hit(int cell);
        public delegate void CloseWindow();

        public event CloseWindow OnCloseWindow;
        public event Hit OnHit;


        //KONSTRUKTOROK
        //__________________________________________________________________________________________________________________________________________________________________________
        public Game(string firstPlayerName, Grid firstPlayerFieldGrid, char[,] firstPlayerBattleField, string secondPlayerName, Grid secondPlayerFieldGrid, char[,] player2Playfield)
        {
            InitializeComponent();
            this.Title = firstPlayerName;
            this._myPlayField = firstPlayerBattleField;
            this._firstPlayerName = firstPlayerName;
            this._secondPlayerName = secondPlayerName;

            _firstPlayerWindow = true;
            string playerStart = WhichPlayerStart(firstPlayerName, secondPlayerName);

            secondPlayerWindowObject = new Game(firstPlayerName, secondPlayerName, secondPlayerFieldGrid, player2Playfield, _isFirstPlayerTurns);
            secondPlayerWindowObject.Title = secondPlayerName;
            secondPlayerWindowObject.Show();

            LoadLabels(firstPlayerName, secondPlayerName, playerStart);
            LoadShips(firstPlayerFieldGrid);

            secondPlayerWindowObject.OnHit += new Hit(this.OnShoot);
            this.OnHit += new Hit(secondPlayerWindowObject.OnShoot);

            secondPlayerWindowObject.OnCloseWindow += new CloseWindow(this.OnClose);
            this.OnCloseWindow += new CloseWindow(secondPlayerWindowObject.OnClose);
        }

        public Game(string firstPlayerName, string secondPlayerName, Grid secondPlayerFieldGrid, char[,] player2Playfield, bool isFirstPlayerTurns)
        {
            InitializeComponent();

            _firstPlayerWindow = false;

            this._myPlayField = player2Playfield;
            this._isFirstPlayerTurns = isFirstPlayerTurns;
            this._firstPlayerName = firstPlayerName;
            this._secondPlayerName = secondPlayerName;

            LoadShips(secondPlayerFieldGrid);
        }
        //__________________________________________________________________________________________________________________________________________________________________________

        //JÁTÉKOS LABELEKHEZ TARTOZÓ METÓDUSOK

        //__________________________________________________________________________________________________________________________________________________________________________
        private string WhichPlayerStart(string firstPlayerName, string secondPlayerName)
        {
            if (rnd.Next(0, 2) == 0)
            {
                _isFirstPlayerTurns = true;
                return firstPlayerName;
            }
            else
            {
                _isFirstPlayerTurns = false;
                return secondPlayerName;
            }
        }

        private void WhichPlayerTurnsLabelChange()
        {
            if (_isFirstPlayerTurns)
            {
                currentPlayersTurn.Content = _firstPlayerName + " következik";
            }
            else
            {
                currentPlayersTurn.Content = _secondPlayerName + " következik";
            }
        }

        private void LoadLabels(string firstPlayerName, string secondPlayerName, string playerStart)
        {
            currentPlayersTurn.Content = playerStart + " kezd!";
            secondPlayerWindowObject.currentPlayersTurn.Content = playerStart + " kezd";
            FirstPlayerPoints.Content = firstPlayerName + " találatai:";
            SecondPlayerPoints.Content = secondPlayerName + " találatai:";
            secondPlayerWindowObject.FirstPlayerPoints.Content = firstPlayerName + " találatai:";
            secondPlayerWindowObject.SecondPlayerPoints.Content = secondPlayerName + " találatai:";
        }
        private void RoundsLabelChange()
        {
            _roundCounter++;

            if (_roundCounter % 2 == 0)
            {
                roundNumber.Content = Convert.ToInt32(roundNumber.Content) + 1;
            }
        }

        private void HitsLabelChange()
        {
            if (_firstPlayerWindow && _isFirstPlayerTurns)
            {
                firstPlayerScoreNumber.Content = Convert.ToInt32(firstPlayerScoreNumber.Content) + 1;
            }
            else if (!_firstPlayerWindow && !_isFirstPlayerTurns)
            {
                secondPlayerScoreNumber.Content = Convert.ToInt32(secondPlayerScoreNumber.Content) + 1;
            }

            if (_firstPlayerWindow && !_isFirstPlayerTurns)
            {
                secondPlayerScoreNumber.Content = Convert.ToInt32(secondPlayerScoreNumber.Content) + 1;
            }
            else if (!_firstPlayerWindow && _isFirstPlayerTurns)
            {
                firstPlayerScoreNumber.Content = Convert.ToInt32(firstPlayerScoreNumber.Content) + 1;
            }
        }

        private void IsShipsDestroyed()
        {
            if (firstPlayerScoreNumber.Content.ToString() == "15")
            {
                MessageBox.Show(_firstPlayerName + " megnyerte a játékot!", "A játékak vége.", MessageBoxButton.OK);
                DbAdd(_firstPlayerName);
                EndGame();
            }
            else if (secondPlayerScoreNumber.Content.ToString() == "15")
            {
                MessageBox.Show(_secondPlayerName + " megnyerte a játékot!", "A játéknak vége.", MessageBoxButton.OK);
                DbAdd(_secondPlayerName);
                EndGame();
            }
        }
        public void DbAdd(string winner)
        {
            Result res = new Result();
            res.ElsoJatekosNeve = _firstPlayerName;
            res.MasodikJatekosNeve = _secondPlayerName;
            res.Nyertes = winner;
            res.ElsoJatekosTalalata = Convert.ToInt32(firstPlayerScoreNumber.Content);
            res.MasodikJatekosTalalata = Convert.ToInt32(secondPlayerScoreNumber.Content);
            res.KorokSzama = Convert.ToInt32(roundNumber.Content);
            ResultRepository.Eredmeny_Hozzaadas(res);
        }

        private void EndGame()
        {
            this.OnCloseWindow();

            MainWindow menu = new MainWindow();
            this.Close();
            menu.Show();
        }
        //__________________________________________________________________________________________________________________________________________________________________________

        //SHIP METÓDUSOK

        //__________________________________________________________________________________________________________________________________________________________________________

        private Rectangle DefineShips(bool isHit)
        {
            Rectangle unit = new Rectangle();

            if (isHit)
            {
                unit.Fill = Brushes.DarkRed;
            }
            else
            {
                unit.Fill = Brushes.LightGray;
            }

            var Y = unit.Width / _rows;
            var X = unit.Height / _columns;
            unit.Width = Y;
            unit.Height = X;

            return unit;
        }

        private void SetShip(int cell, bool isHit, bool setLeftTable)
        {
            Rectangle ship = DefineShips(isHit);

            Grid.SetRow(ship, cell / _rows);
            Grid.SetColumn(ship, cell % _columns);

            if (setLeftTable)
            {
                userTable.Children.Add(ship);
            }
            else
            {
                enemyTable.Children.Add(ship);
            }
        }

        private void LoadShips(Grid playfield)
        {
            for (int unit = playfield.Children.Count - 1; unit >= 0; unit--)
            {
                var child = playfield.Children[unit];
                playfield.Children.RemoveAt(unit);
                userTable.Children.Add(child);
            }
        }
        //__________________________________________________________________________________________________________________________________________________________________________

        //MEZŐKHÖZ TARTOZÓ METÓDUSOK

        //__________________________________________________________________________________________________________________________________________________________________________

        private int CalculateCell()
        {
            var point = Mouse.GetPosition(enemyTable);

            int row = 0;
            int col = 0;
            double accumulatedHeight = 0.0;
            double accumulatedWidth = 0.0;

            foreach (var rowDefinition in enemyTable.RowDefinitions)
            {
                accumulatedHeight += rowDefinition.ActualHeight;
                if (accumulatedHeight >= point.Y)
                    break;
                row++;
            }

            foreach (var columnDefinition in enemyTable.ColumnDefinitions)
            {
                accumulatedWidth += columnDefinition.ActualWidth;
                if (accumulatedWidth >= point.X)
                    break;
                col++;
            }

            return (row * 10) + col;
        }

        private bool IsHitCell(int cell)
        {
            if (_enemyPlayField[cell / _rows, cell % _columns] == 'T' || _enemyPlayField[cell / _rows, cell % _columns] == 'V')
            {
                return true;
            }

            return false;
        }

        private bool IsHitShipUnit(int cell)
        {
            if (char.IsDigit(_myPlayField[cell / _rows, cell % _columns]))
            {
                return true;
            }

            return false;
        }
        //__________________________________________________________________________________________________________________________________________________________________________

        //DELEGATE METÓDUSOK

        //__________________________________________________________________________________________________________________________________________________________________________

        public string OnShoot(int cell)
        {
            bool isHit = IsHitShipUnit(cell);

            SetShip(cell, isHit, true);

            if (isHit)
            {
                HitsLabelChange();
                return _myPlayField[cell / _rows, cell % _columns].ToString();
            }

            _isFirstPlayerTurns = !_isFirstPlayerTurns;
            RoundsLabelChange();
            WhichPlayerTurnsLabelChange();

            return "false";
        }

        public void OnClose()
        {
            this.Close();
        }
        //__________________________________________________________________________________________________________________________________________________________________________

        //BUTTON METÓDUSOK 

        //__________________________________________________________________________________________________________________________________________________________________________

        private void OnGridMouseClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                if (_isFirstPlayerTurns && _firstPlayerWindow || !_isFirstPlayerTurns && !_firstPlayerWindow)
                {

                    int cell = CalculateCell();

                    bool shooted = IsHitCell(cell);

                    if (!shooted)
                    {
                        string shipUnitName = this.OnHit(cell);

                        if (shipUnitName != "false")
                        {
                            SetShip(cell, true, false);
                            _enemyPlayField[cell / _rows, cell % _columns] = 'T';

                            HitsLabelChange();
                            IsShipsDestroyed();
                        }
                        else
                        {
                            SetShip(cell, false, false);
                            _enemyPlayField[cell / _rows, cell % _columns] = 'V';

                            _isFirstPlayerTurns = !_isFirstPlayerTurns;
                            RoundsLabelChange();
                            WhichPlayerTurnsLabelChange();
                        }
                    }
                }
            }
        }

        private void ExitFromGameButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        //__________________________________________________________________________________________________________________________________________________________________________
    }
}
