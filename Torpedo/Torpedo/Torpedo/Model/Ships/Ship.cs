using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torpedo.Model.Ships
{
    [Serializable]
    public abstract class Ship
    {

        public Ship()
        {
        }

        public Ship(Position position)
        {
            this.Position = position ?? throw new ArgumentNullException(nameof(position), "The value must not be null.");
        }

        public int Length
        {
            get;
            protected set;
        }

        public int DamageCounter
        {
            get;
            set;
        }

        public Position Position
        {
            get;
            set;
        }

        public Orientation Orientation
        {
            get;
            set;
        }
    }
}
