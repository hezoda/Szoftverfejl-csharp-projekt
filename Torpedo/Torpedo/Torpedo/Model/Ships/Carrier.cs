using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torpedo.Model.Ships
{
    public class Carrier : Ship
    {
        public Carrier()
        {
        }

        public Carrier(Position position) : base(position)
        {
            this.Length = 5;
        }
    }
}
