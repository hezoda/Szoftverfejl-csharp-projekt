using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torpedo.Model.Ships
{
    public class Cruiser : Ship
    {
   
        public Cruiser()
        {
        }

        public Cruiser(Position position) : base(position)
        {
            this.Length = 3;
        }
    }
}
