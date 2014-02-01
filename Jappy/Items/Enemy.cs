using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jappy.Items
{
    using Fields;
    using MoveMotion;
    using State;

    abstract class Enemy : Item
    {
        internal static readonly Random Rnd = new Random();
        public abstract int Score { get; }

        protected int height = 2;
        protected int sleeping = 0;
        protected Direction direction = Direction.Down;
        protected EnemyDying dying = EnemyDying.Fine;

        protected Enemy(Field field) : base(field) { }

        public void Crush(Field field)
        {
            if (dying == EnemyDying.Fine)
                dying = EnemyDying.Dying;
            else if (dying == EnemyDying.Dying)
            {
                dying = EnemyDying.Die;
                height = 1;
                Y++;
            }
            else if (dying == EnemyDying.Die)
            {
                field.Score += this.Score;
                field.Remove(this);
            }
        }
        public void Sleep()
        {
            sleeping = 20;
        }
        public bool Move(Field field)
        {
            if (dying != EnemyDying.Fine)
            {
                return true;
            }
            if (sleeping > 0)
            {
                sleeping--;
                return true;
            }
            Move move = DecideNextMove(field);

            this.direction = move.Direction;
            Item aten1 = field[move.NewCome1(this.Position)];
            Item aten2 = field[move.NewCome2(this.Position)];

            if (aten1 is Stone || aten1 is Block
                || aten2 is Stone || aten2 is Block)
            {
                return true;
            }
            else if (aten1 is Me
                || aten2 is Me)
            {
                move.Direction.Move(this);
                return false;
            }
            else if (aten1 is Enemy
              || aten2 is Enemy)
            {
                return true;
            }
            else if (aten1 is Mush
                || aten2 is Mush)
            {
                if (aten1 != null) field.Remove(aten1);
                if (aten2 != null) field.Remove(aten2);
            }
            move.Direction.Move(this);
            return true;
        }

        protected abstract Move DecideNextMove(Field field);
    }
}
