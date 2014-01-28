using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jappy.MoveMotion
{
    using Items;
    using Fields;

    public abstract class Move
    {
        internal static readonly Move Left = new MoveLeft();
        internal static readonly Move Right = new MoveRight();
        internal static readonly Move Up = new MoveUp();
        internal static readonly Move Down = new MoveDown();
        private readonly Direction direction;
        internal Direction Direction { get { return direction; } }

        internal Move(Direction direction)
        {
            this.direction = direction;
        }
        internal abstract Position NewCome1(Position arg);
        internal abstract Position NewCome2(Position arg);
        protected abstract Position Push(Position arg);
        protected abstract Position PushDest1(Position arg);
        protected abstract Position PushDest2(Position arg);
        public bool Go(Field field, Position current)
        {
            field.Me.setDirection(direction);
            // 動けないケースを検知(壁)
            if (CanNotEnter(field,
                NewCome1(current),
                NewCome2(current))) return true;
            // 押し込み検知
            Position pushAt = Push(current);
            Item pushed = field[pushAt];
            Item newCome1 = field[NewCome1(current)];
            Item newCome2 = field[NewCome2(current)];
            if (pushed is Stone
                && pushed.Position == pushAt)
            {
                Item push1Item = field[PushDest1(current)];
                Item push2Item = field[PushDest2(current)];
                if ((push1Item == null || push1Item is Mush)
                    && (push2Item == null || push2Item is Mush))
                {
                    // 押し込み
                    direction.Move(pushed);
                    if (push1Item is Mush) field.Remove(push1Item);
                    if (push2Item is Mush) field.Remove(push2Item);
                }
                else
                {
                    if (pushed is NormalStone)
                    {
                        ((NormalStone)pushed).Break();
                    }
                    return true;
                }
            }
            else
            {
                if (newCome1 is Stone
                    || newCome2 is Stone)
                {
                    return true;
                }
            }
            // 自爆検知
            if (newCome1 is Enemy
                || newCome2 is Enemy)
                return false;
            // キノコ取得
            if (newCome1 is Mush)
            {
                field.MushInPocket++;
                field.Remove(newCome1);
            }
            if (newCome2 is Mush)
            {
                field.MushInPocket++;
                field.Remove(newCome2);
            }
            direction.Move(field.Me);
            return true;
        }

        /// <summary>
        /// 動けないケースを検知(ズレ石、壁)
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private bool CanNotEnter(Field field, Position p1, Position p2)
        {
            Item i1 = field[p1];
            Item i2 = field[p2];
            return i1 is Block
                || i2 is Block;
        }
    }
}
