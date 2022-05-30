using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torpedo.Model;

namespace Torpedo.ViewModel.BattleField
{
    public class BattleFieldViewModel : BindableBase
    {

        private int _rows = 10;
        private int _cols = 10;

        private List<Position> _positions;

        public BattleFieldViewModel()
        {
            InitialiseGameTiles();
        }
        public List<Position> Positions {
            get { return _positions; }
            set { SetProperty(ref _positions, value); }
        }

        public int Rows
        {
            get { return _rows; }
            set
            {
                SetProperty(ref _rows, value);
            }
        }

        public int Columns
        {
            get { return _cols; }
            set
            {
                SetProperty(ref _cols, value);
            }
        }

        private void InitialiseGameTiles()
        {
            var positions = new List<Position>();
            

            for (var r = 0; r < Rows; r++)
            {
                for (var c = 0; c < Columns; c++)
                {
                    var position = new Position(r, c);
                    positions.Add(position);
                }
            }
            Positions = positions;
        }
    }
}
