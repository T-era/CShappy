using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jappy.Items
{
    using System.Drawing;
    using Fields;

    abstract class ColoredStone : Stone
    {
        public abstract Color Color { get; }
        protected ColoredStone(Field field) : base(field) { }
    }
}
