using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torpedo.Model.Ships
{
    public class Destroyer : Ship
    {
        public Destroyer()
        {
        }

        public Destroyer(Position position) : base(position)
        {
            this.Length = 2;
        }
    }
}
