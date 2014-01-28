using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jappy.MoveMotion
{
    internal class MoveLeft : Move
    {
        internal override Position NewCome1(Position p)
        {
            return new Position() { X = p.X - 1, Y = p.Y };
        }
        internal override Position NewCome2(Position p)
        {
            return new Position() { X = p.X - 1, Y = p.Y + 1 };
        }
        protected override Position Push(Position p)
        {
            return new Position() { X = p.X - 2, Y = p.Y };
        }
        protected override Position PushDest1(Position p)
        {
            return new Position() { X = p.X - 3, Y = p.Y };
        }
        protected override Position PushDest2(Position p)
        {
            return new Position() { X = p.X - 3, Y = p.Y + 1 };
        }
        internal MoveLeft() : base(Direction.Left) { }
    }
    internal class MoveRight : Move
    {
        internal override Position NewCome1(Position p)
        {
            return new Position() { X = p.X + 2, Y = p.Y };
        }
        internal override Position NewCome2(Position p)
        {
            return new Position() { X = p.X + 2, Y = p.Y + 1 };
        }
        protected override Position Push(Position p)
        {
            return new Position() { X = p.X + 2, Y = p.Y };
        }
        protected override Position PushDest1(Position p)
        {
            return new Position() { X = p.X + 4, Y = p.Y };
        }
        protected override Position PushDest2(Position p)
        {
            return new Position() { X = p.X + 4, Y = p.Y + 1 };
        }
        internal MoveRight() : base(Direction.Right) { }
    }
    internal class MoveUp : Move
    {
        internal override Position NewCome1(Position p)
        {
            return  new Position() { X = p.X, Y = p.Y - 1 };
        }
        internal override Position NewCome2(Position p)
        {
            return  new Position() { X = p.X + 1, Y = p.Y - 1 };
        }
        protected override Position Push(Position p)
        {
            return  new Position() { X = p.X, Y = p.Y - 2 };
        }
        protected override Position PushDest1(Position p)
        {
            return  new Position() { X = p.X, Y = p.Y - 4 };
        }
        protected override Position PushDest2(Position p)
        {
            return  new Position() { X = p.X + 1, Y = p.Y - 4 };
        }
        internal MoveUp() : base(Direction.Up) { }
    }
    internal class MoveDown : Move
    {
        internal override Position NewCome1(Position p)
        {
            return  new Position() { X = p.X, Y = p.Y + 2 };
        }
        internal override Position NewCome2(Position p)
        {
            return  new Position() { X = p.X + 1, Y = p.Y + 2 };
        }
        protected override Position Push(Position p)
        {
            return  new Position() { X = p.X, Y = p.Y + 2 };
        }
        protected override Position PushDest1(Position p)
        {
            return  new Position() { X = p.X, Y = p.Y + 4 };
        }
        protected override Position PushDest2(Position p)
        {
            return  new Position() { X = p.X + 1, Y = p.Y + 4 };
        }
        internal MoveDown() : base(Direction.Down) { }
    }
}
