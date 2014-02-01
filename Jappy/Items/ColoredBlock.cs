using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jappy.Items
{
    using System.Drawing;
    using Fields;

    abstract class ColoredBlock : Block
    {
        public abstract Color Color { get; }
        protected ColoredBlock(Field field) : base(field) { }
    }
}
