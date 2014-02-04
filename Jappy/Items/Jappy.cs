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
        private readonly static Image image_dying = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Jappy_Dying.bmp"));
        private bool dying = false;
        private Direction direction = Direction.Down;
        internal Direction Direction { get { return direction; } }
        public override int Width { get { return 2; } }
        public override int Height { get { return 2; } }

        internal Me(Field field) : base(field) { }
        protected override void DrawAt(Graphics g, int x, int y, bool animMode)
        {
            Image image = null;
            if (dying)
            {
                image = image_dying;
            }
            else if (direction == Direction.Down)
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
        public void Crush()
        {
            dying = true;
        }
        public static Image GetThumbnail(int mode)
        {
            switch (mode)
            {
                case 0:
                    return image_d1;
                case 1:
                    return image_d2;
                case 2:
                    return image_d1;
                case 3:
                    return image_d2;
                case 4:
                    return image_d1;
                case 5:
                    return image_u1;
                case 6:
                    return image_u2;
                case 7:
                    return image_dying;
            }
            return null;
        }
    }
}
