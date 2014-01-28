using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jappy
{
    public class Position
    {
        public int X { set; get; }
        public int Y { set; get; }

        public override int GetHashCode()
        {
            return X * 17 + Y * 7;
        }
        public override bool Equals(Object arg)
        {
            if (arg is Position)
            {
                Position p2 = (Position)arg;
                return this.X == p2.X
                    && this.Y == p2.Y;
            }
            else
            {
                return false;
            }
        }
        public static bool operator ==(Position p1, Position p2)
        {
            return p1.X == p2.X
                && p1.Y == p2.Y;
        }
        public static bool operator !=(Position p1, Position p2)
        {
            return p1.X != p2.X
                || p1.Y != p2.Y;
        }
    }
}
