using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torpedo.Model.Ships
{
    public class BattleShip : Ship
    {
        public BattleShip()
        {

        }

        public BattleShip(Position position) : base(position)
        {
            this.Length = 4;
        }
    }
}
