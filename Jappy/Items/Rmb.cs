﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jappy.Items
{
    using System.Drawing;
    using Fields;
    using State;
    using MoveMotion;

    class Rmb : Enemy
    {
        private const int SCORE = 30;
        private readonly static Image image_l1 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Rmb_L1.bmp"));
        private readonly static Image image_l2 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Rmb_L2.bmp"));
        private readonly static Image image_r1 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Rmb_R1.bmp"));
        private readonly static Image image_r2 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Rmb_R2.bmp"));
        private readonly static Image image_u1 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Rmb_U1.bmp"));
        private readonly static Image image_u2 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Rmb_U2.bmp"));
        private readonly static Image image_d1 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Rmb_D1.bmp"));
        private readonly static Image image_d2 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Rmb_D2.bmp"));
        private readonly static Image image_s1 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Rmb_S1.bmp"));

        private readonly static Image image_dying1 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Rmb_Dying1.bmp"));
        private readonly static Image image_dying2 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Rmb_Dying2.bmp"));

        private int height = 2;
        private int sleeping = 0;
        private Direction direction = Direction.Down;
        private EnemyDying dying = EnemyDying.Fine;

        internal Rmb(Field field) : base(field) { }

        public override void Sleep()
        {
            sleeping = 20;
        }
        public override bool Move(Field field)
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
            Move move;
            if (Distance2(this.Position, field.Me.Position) < 100
                && Rnd.Next(10) < 8)
            {
                move = FromTo(this.Position, field.Me.Position);
            }
            else
            {
                switch (Rnd.Next(4)) {
                    case 0:
                        move = MoveMotion.Move.Up;
                        break;
                    case 1:
                        move = MoveMotion.Move.Down;
                        break;
                    case 2:
                        move = MoveMotion.Move.Left;
                        break;
                    case 3:
                        move = MoveMotion.Move.Right;
                        break;
                    default:
                        throw new Exception("アリエン");
                }
            }
            this.direction = move.Direction;
//            Tuple<Position, Position, Position> next = FromHere(direction);
            Item aten1 = field[move.NewCome1(this.Position)];
            Item aten2 = field[move.NewCome2(this.Position)];
//            Item aten1 = field.At(next.Item2.X, next.Item2.Y);
//            Item aten2 = field.At(next.Item3.X, next.Item3.Y);

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
            } else if (aten1 is Enemy
                || aten2 is Enemy) {
                return true;
            }
            else if (aten1 is Mush
                || aten2 is Mush)
            {
                // TODO どうしよう
            }
            move.Direction.Move(this);
            return true;
        }
        private int Distance2(Position p1, Position p2)
        {
            int dx = p1.X - p2.X;
            int dy = p1.Y - p2.Y;
            return dx * dx + dy * dy;
        }
        private Tuple<Position, Position, Position> FromHere(Direction direction)
        {
            if (direction == Direction.Up)
                return new Tuple<Position, Position, Position>(
                    new Position() { X = this.X, Y = this.Y - 1 },
                    new Position() { X = this.X, Y = this.Y - 1 },
                    new Position() { X = this.X + 1, Y = this.Y - 1 });
            else if (direction == Direction.Down)
                return new Tuple<Position, Position, Position>(
                    new Position() { X = this.X, Y = this.Y + 1 },
                    new Position() { X = this.X, Y = this.Y + 2 },
                    new Position() { X = this.X + 1, Y = this.Y + 2 });
            else if (direction == Direction.Left)
                return new Tuple<Position, Position, Position>(
                    new Position() { X = this.X - 1, Y = this.Y },
                    new Position() { X = this.X - 1, Y = this.Y },
                    new Position() { X = this.X - 1, Y = this.Y + 1 });
            else if (direction == Direction.Right)
                return new Tuple<Position, Position, Position>(
                    new Position() { X = this.X + 1, Y = this.Y },
                    new Position() { X = this.X + 2, Y = this.Y },
                    new Position() { X = this.X + 2, Y = this.Y + 1 });
            else
                throw new Exception("アリエヌ");
        }
        private Move FromTo(Position from, Position to)
        {
            var adx = Math.Abs(from.X - to.X);
            var ady = Math.Abs(from.Y - to.Y);
            if (adx == ady)
            {
                if (Rnd.Next(2) == 0)
                {
                    return FromToHorizontial(from, to);
                }
                else
                {
                    return FromToVertical(from, to);
                }
            }
            else if (adx > ady)
            {
                return FromToHorizontial(from, to);
            }
            else
            {
                return FromToVertical(from, to);
            }
        }
        private Move FromToHorizontial(Position from, Position to)
        {
            if (from.X > to.X)
            {
                return MoveMotion.Move.Left;
            }
            else
            {
                return MoveMotion.Move.Right;
            }
        }
        private Move FromToVertical(Position from, Position to)
        {
            if (from.Y > to.Y)
            {
                return MoveMotion.Move.Up;
            }
            else
            {
                return MoveMotion.Move.Down;
            }
        }
        public override void Crush(Field field)
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
                field.Remove(this);
        }

        protected override void DrawAt(Graphics g, int x, int y, bool animMode)
        {
            Image image = null;
            if (dying == EnemyDying.Dying)
            {
                image = image_dying1;
            }
            else if (dying == EnemyDying.Die)
            {
                image = image_dying2;
            }
            else if (sleeping > 0)
            {
                image = image_s1;
            }
            else if (direction == Direction.Up)
            {
                image = animMode ? image_u1 : image_u2;
            }
            else if (direction == Direction.Down)
            {
                image = animMode ? image_d1 : image_d2;
            }
            else if (direction == Direction.Left)
            {
                image = animMode ? image_l1 : image_l2;
            }
            else if (direction == Direction.Right)
            {
                image = animMode ? image_r1 : image_r2;
            }

            g.DrawImage(image, x, y, GameView.BLOCK_SIZE * 2, GameView.BLOCK_SIZE * height);
        }
        
        public override int Score { get { return SCORE; } }
        public override int Width { get { return 2; } }
        public override int Height { get { return height; } }
    }
}
