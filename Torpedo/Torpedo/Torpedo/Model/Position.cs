using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torpedo.Model
{
    public class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public bool Equals(Position other)
        {
            return this.X == other.X && this.Y == other.Y;
        }
    }
}
