using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jappy.Items
{
    using Fields;

    abstract class Enemy : Item
    {
        internal static readonly Random Rnd = new Random();
        public abstract void Sleep();
        public abstract void Crush(Field field);
        public abstract int Score { get; }
        public abstract bool Move(Field field);

        protected Enemy(Field field) : base(field) { }
    }
}
