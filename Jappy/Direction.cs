using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jappy
{
    internal class Direction
    {
        internal static Direction Up = new Direction(p => { p.Y--; });
        internal static Direction Down = new Direction(p => { p.Y++; });
        internal static Direction Left = new Direction(p => { p.X--; });
        internal static Direction Right = new Direction(p => { p.X++; });

        private readonly Action<Position> motion;

        private Direction(Action<Position> motion)
        {
            this.motion = motion;
        }
        internal void Move(Item i)
        {
            motion(i.Position);
        }
        internal void Move(Position p)
        {
            motion(p);
        }
        internal Position Beyond(Position p)
        {
            Position temp = new Position() { X = p.X, Y = p.Y };
            return BeyondIn(temp, 1);
        }
        internal Position Beyond(Position p, int time)
        {
            Position temp = new Position() { X = p.X, Y = p.Y };
            return BeyondIn(temp, time);
        }
        private Position BeyondIn(Position p, int time)
        {
            if (time == 0)
            {
                return p;
            } else {
                motion(p);
                motion(p);
                return BeyondIn(p, time - 1);
            }
        }
    }
}
