using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jappy.Items
{
    using Fields;

    abstract class Stone : Item
    {
        protected Stone(Field field) : base(field) { }
    }
}
