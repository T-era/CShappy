using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Jappy.Items
{
    using Fields;

    class Me : Item
    {
        private readonly static Image image_u1 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Jappy_U1.bmp"));
        private readonly static Image image_u2 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Jappy_U2.bmp"));
        private readonly static Image image_d1 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Jappy_D1.bmp"));
        private readonly static Image image_d2 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Jappy_D2.bmp"));
        private readonly static Image image_l1 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Jappy_L1.bmp"));
        private readonly static Image image_l2 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Jappy_L2.bmp"));
        private readonly static Image image_r1 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Jappy_R1.bmp"));
        private readonly static Image image_r2 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Jappy_R2.bmp"));
        private Direction direction = Direction.Down;
        internal Direction Direction { get { return direction; } }
        public override int Width { get { return 2; } }
        public override int Height { get { return 2; } }

        internal Me(Field field) : base(field) { }
        protected override void DrawAt(Graphics g, int x, int y, bool animMode)
        {
            Image image = null;
            if (direction == Direction.Down)
            {
                image = animMode ? image_d1 : image_d2;
            }
            else if (direction == Direction.Up)
            {
                image = animMode ? image_u1 : image_u2;
            }
            else if (direction == Direction.Left)
            {
                image = animMode ? image_l1 : image_l2;
            }
            else if (direction == Direction.Right)
            {
                image = animMode ? image_r1 : image_r2;
            }
            g.DrawImage(image, x, y, GameView.BLOCK_SIZE * 2, GameView.BLOCK_SIZE * 2);
        }
        public void setDirection(Direction d) {
            this.direction = d;
        }
    }
}
