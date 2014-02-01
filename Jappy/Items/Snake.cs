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
    using MoveMotion;

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

        internal Snake(Field field) : base(field) { }

        protected override Move DecideNextMove(Field field)
        {
            if (Math.Abs(field.Me.Y - this.Y) <= 1
                && field.Me.X != this.X
                && Rnd.Next(10) < 8)
            {
                if (this.X > field.Me.X)
                {
                    return MoveMotion.Move.Left;
                }
                else
                {
                    return MoveMotion.Move.Right;
                }
            }
            else
            {
                if (Rnd.Next(2) == 0)
                {
                    return MoveMotion.Move.Left;
                }
                else
                {
                    return MoveMotion.Move.Right;
                }
            }
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
            else if (direction == Direction.Left)
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
