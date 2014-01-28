using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Jappy.Items
{
    using Fields;

    class Mush : Item
    {
        internal Mush(Field field) : base(field) { }
        internal readonly static Image image = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Mushroom.bmp"));
        public override int Width { get { return 1; } }
        public override int Height { get { return 1; } }
        protected override void DrawAt(Graphics g, int x, int y, bool animMode)
        {
            g.DrawImage(image, x, y, GameView.BLOCK_SIZE, GameView.BLOCK_SIZE);
        }
    }
    class FlyingMush : Item
    {
        internal Direction Direction { private set; get; }

        public override int Width { get { return 1; } }
        public override int Height { get { return 1; } }
        private int remain;

        internal FlyingMush(Field field, Direction d, int x, int y) : base(field)
        {
            Direction = d;
            this.X = x;
            this.Y = y;
            remain = 10;
        }
        internal bool IsRand()
        {
            return remain-- == 0;
        }
        protected override void DrawAt(Graphics g, int x, int y, bool animMode)
        {
            g.DrawImage(Mush.image, x, y, GameView.BLOCK_SIZE, GameView.BLOCK_SIZE);
        }
    }
}
