using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torpedo.ViewModel.BattleField
{
    public class BattleFieldArea
    {/*
        /// <summary>
        /// The command to highlight squares on mouse over.
        /// </summary>
        private HighlightSquaresCommand highlightSquaresCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="BattleFieldAreaViewModel"/> class.
        /// </summary>
        /// <param name="width">The width of the battle field.</param>
        /// <param name="height">The height of the battle field.</param>
        /// <param name="squareCommand">The command which should be executed when a square is clicked.</param>
        public BattleFieldAreaViewModel(int width, int height, BaseCommand squareCommand = null)
        {
            this.Squares = new ObservableCollection<BFSquareViewModel>();
            this.Ships = new ObservableCollection<Ship>();
            this.Width = width;
            this.Height = height;

            for (int h = 0; h < width; h++)
            {
                for (int w = 0; w < height; w++)
                {
                    this.Squares.Add(new BFSquareViewModel(false, new Position(w, h), squareCommand));
                }
            }
        }

        /// <summary>
        /// Gets the width of the battle field.
        /// </summary>
        /// <value>An integer value.</value>
        public int Width
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the height of the battle field.
        /// </summary>
        /// <value>An integer value.</value>
        public int Height
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the squares of the battle field.
        /// </summary>
        /// <value>The squares of the battle field.</value>
        public ObservableCollection<BFSquareViewModel> Squares
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the ships of the battle field.
        /// </summary>
        /// <value>The ships of the battle field.</value>
        public ObservableCollection<Ship> Ships
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the command to highlight squares.
        /// </summary>
        /// <value>A command.</value>
        public HighlightSquaresCommand HighlightSquaresCommand
        {
            get
            {
                return this.highlightSquaresCommand;
            }

            set
            {
                this.highlightSquaresCommand = value;
                this.Notify();
            }
        }

        /// <summary>
        /// Removes the highlighted state from the squares.
        /// </summary>
        public void ClearHighlighted()
        {
            for (int i = 0; i < this.Squares.Count; i++)
            {
                this.Squares[i].HighlightedState = HighlightedState.NotHighlighted;
            }
        }

        /// <summary>
        /// Highlights the squares to indicate the ship position.
        /// </summary>
        /// <param name="shipToPlace">The ship to place.</param>
        /// <returns>A boolean value indicating whether the position is valid.</returns>
        public bool HighlightSquares(Ship shipToPlace)
        {
            Position controlPos;
            bool validShipPosition = true;
            List<BFSquareViewModel> squares = new List<BFSquareViewModel>();
            HighlightedState state = HighlightedState.Highlighted;

            for (int l = 0; l < shipToPlace.Length; l++)
            {
                if (shipToPlace.Orientation == Orientation.Horizontal)
                {
                    controlPos = new Position(shipToPlace.Position.X + l, shipToPlace.Position.Y);
                }
                else
                {
                    controlPos = new Position(shipToPlace.Position.X, shipToPlace.Position.Y + l);
                }

                try
                {
                    BFSquareViewModel square = this.Squares.First(s => s.Position.Equals(controlPos));
                    if (square.RealShipUnit)
                    {
                        validShipPosition = false;
                    }

                    squares.Add(square);
                }
                catch
                {
                    return false;
                }
            }

            if (!validShipPosition)
            {
                state = HighlightedState.HighlightedAsWrong;
            }

            for (int i = 0; i < squares.Count; i++)
            {
                squares[i].HighlightedState = state;
            }

            if (state == HighlightedState.HighlightedAsWrong)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Adds a ship to the battle field.
        /// </summary>
        /// <param name="ship">The ship to add.</param>
        public void AddShip(Ship ship)
        {
            this.Ships.Add(ship);
            ShipMoverViewModel shipMover = new ShipMoverViewModel(ship, this.Squares, this.Height);
            shipMover.Start();
        }

        /// <summary>
        /// Sets the command of the squares.
        /// </summary>
        /// <param name="squareCommand">A command.</param>
        public void SetSquareCommands(BaseCommand squareCommand)
        {
            for (int i = 0; i < this.Squares.Count; i++)
            {
                this.Squares[i].SquareCommand = squareCommand;
            }
        }

        /// <summary>
        /// Enables the squares of the battle field. Makes them clickable.
        /// </summary>
        public void EnableSquares()
        {
            for (int i = 0; i < this.Squares.Count; i++)
            {
                this.Squares[i].Enabled = true;
            }
        }

        /// <summary>
        /// Disables the squares of the battle field.
        /// </summary>
        public void DisableSquares()
        {
            for (int i = 0; i < this.Squares.Count; i++)
            {
                this.Squares[i].Enabled = false;
            }
        }

        /// <summary>
        /// Adds a marker to the battle field.
        /// </summary>
        /// <param name="marker">The marker.</param>
        public void AddMarker(Marker marker)
        {
            BFSquareViewModel square = this.Squares.Where(s => s.Position.Equals(marker.Position)).First();
            if (marker is HitMarker)
            {
                square.State = SquareState.Hit;
            }
            else
            {
                square.State = SquareState.Missed;
            }
        }
         */
    }
       
}


