using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torpedo.Model
{
    public class Position
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Position(double x, double y)
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
