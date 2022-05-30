using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torpedo.Model.Markers
{
    public abstract class Marker
    {
       
        public Marker(Position position)
        {
            this.Position = position ?? throw new ArgumentNullException(nameof(position), "The value must not be null.");
        }

        public Position Position
        {
            get;
            private set;
        }
    }
}
