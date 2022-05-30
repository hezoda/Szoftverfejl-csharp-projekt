using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torpedo.Model.Ships
{
    public class Submarine : Ship
    {
        public Submarine()
        {

        }

        public Submarine(Position position) : base(position)
        {
            this.Length = 1;
        }
    }
}
