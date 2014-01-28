using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jappy.Items
{
    using System.Drawing;
    using Fields;
    using State;

    class Snake : Enemy
    {
        private const int SCORE = 20;
        private readonly static Image image_l1 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Snake_L1.bmp"));
        private readonly static Image image_l2 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Snake_L2.bmp"));
        private readonly static Image image_r1 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Snake_R1.bmp"));
        private readonly static Image image_r2 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Snake_R2.bmp"));
        private readonly static Image image_s1 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Snake_Sleeping1.bmp"));
        private readonly static Image image_s2 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Snake_Sleeping2.bmp"));

        private readonly static Image image_d1 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Snake_Dying1.bmp"));
        private readonly static Image image_d2 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Snake_Dying2.bmp"));
        private int height = 2;
        private int sleeping = 0;
        private bool toLeft;
        private EnemyDying dying = EnemyDying.Fine;

        internal Snake(Field field) : base(field) { }

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
            if (Math.Abs(field.Me.Y - this.Y) <= 1
                && field.Me.X != this.X
                && Rnd.Next(10) < 8)
            {
                if (this.X > field.Me.X)
                {
                    toLeft = true;
                }
                else
                {
                    toLeft = false;
                }
            }
            else
            {
                if (Rnd.Next(2) == 0)
                {
                    toLeft = true;
                }
                else
                {
                    toLeft = false;
                }
            }
            int newX = this.X + (toLeft ? -1 : 1);
            Item aten1;
            Item aten2;
            if (toLeft)
            {
                aten1 = field.At(newX, this.Y);
                aten2 = field.At(newX, this.Y + 1);
            }
            else
            {
                aten1 = field.At(newX + 1, this.Y);
                aten2 = field.At(newX + 1, this.Y + 1);
            }

            if (aten1 is Stone || aten1 is Block
                || aten2 is Stone || aten2 is Block)
            {
                return true;
            }
            else if (aten1 is Enemy
                || aten2 is Enemy)
            {
                return true;
            }
            else if (aten1 is Me
                || aten2 is Me)
            {
                this.X = newX;
                return false;
            }
            else if (aten1 is Mush
                || aten2 is Mush)
            {
                // TODO どうしよう
            }
            this.X = newX;
            return true;
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
                image = image_d1;
            }
            else if (dying == EnemyDying.Die)
            {
                image = image_d2;
            }
            else if (sleeping > 0)
            {
                image = animMode ? image_s1 : image_s2;
            }
            else if (toLeft)
            {
                image = animMode ? image_l1 : image_l2;
            }
            else
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
