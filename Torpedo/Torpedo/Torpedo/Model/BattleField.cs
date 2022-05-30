using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torpedo.Model.Ships;

namespace Torpedo.Model
{
    using System;
    using Torpedo.Model.Markers;

    public class BattleField
    {
        private const int MinWidth = 10;
        private const int MinHeight = 10;

        public BattleField(int width = MinWidth, int height = MinHeight)
        {
            this.Width = width;
            this.Height = height;
            this.Ships = new List<Ship>();
            this.Markers = new List<Marker>();
        }

        public int Height
        {
            get;
            private set;
        }

        public int Width
        {
            get;
            private set;
        }

        public List<Ship> Ships
        {
            get;
            set;
        }

        public List<Marker> Markers
        {
            get;
            set;
        }

        public bool AddMarker(Position position, out Marker marker)
        {
            if (this.Markers.Exists(m => m.Position.Equals(position))
                || position.X >= this.Width || position.Y >= this.Height)
            {
                marker = null;
                return false;
            }

            marker = new MissedMarker(position);

            for (int j = 0; j < this.Ships.Count; j++)
            {
                Ship ship = this.Ships[j];
                Position controlPosition;
                for (int i = 0; i < ship.Length; i++)
                {
                    if (ship.Orientation == Orientation.Horizontal)
                    {
                        controlPosition = new Position(ship.Position.X + i, ship.Position.Y);
                    }
                    else
                    {
                        controlPosition = new Position(ship.Position.X, ship.Position.Y + i);
                    }

                    if (position.Equals(controlPosition))
                    {
                        marker = new HitMarker(position);
                        this.Markers.Add(marker);
                        ship.DamageCounter += 1;

                        if (ship.DamageCounter == ship.Length)
                        {
                            this.Ships.Remove(ship);
                        }

                        break;
                    }
                }
            }

            return true;
        }
    }

}
