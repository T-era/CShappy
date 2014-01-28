using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Jappy.Items
{
    using Fields;

    class NormalStone : Stone
    {
        private readonly static Image image = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Stone.bmp"));
        private readonly static Image image_b0 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.StoneBroken0.bmp"));
        private readonly static Image image_b1 = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.StoneBroken1.bmp"));
        public override int Width { get { return 2; } }
        private int height = 2;
        public override int Height { get { return height; } }
        private bool isBroken = false;
        private int brokenStep = -1;

        public NormalStone(Field field) : base(field) { }
        protected override void DrawAt(Graphics g, int x, int y, bool animMode)
        {
            if (isBroken)
            {
                brokenStep++;
                switch (brokenStep)
                {
                    case 0:
                        g.DrawImage(image_b0, x, y, GameView.BLOCK_SIZE * 2, GameView.BLOCK_SIZE * Height);
                        height = 1;
                        Position.Y++;
                        break;
                    case 1:
                        g.DrawImage(image_b1, x, y, GameView.BLOCK_SIZE * 2, GameView.BLOCK_SIZE * Height);
                        break;
                    case 2:
                        field.Remove(this);
                        break;
                }
            }
            else
            {
                g.DrawImage(image, x, y, GameView.BLOCK_SIZE * 2, GameView.BLOCK_SIZE * Height);
            }
        }
        internal void Break()
        {
            isBroken = true;
        }
    }
}
