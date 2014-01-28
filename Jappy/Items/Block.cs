using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Jappy.Items
{
    using Fields;

    class Block : Item
    {
        internal readonly static Image image = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.Block.bmp"));

        public override int Width { get { return 1; } }
        public override int Height { get { return 1; } }

        internal Block(Field field) : base(field) { }
        protected override void DrawAt(Graphics g, int x, int y, bool anotherway)
        {
            g.DrawImage(image, x, y, GameView.BLOCK_SIZE, GameView.BLOCK_SIZE);
        }
    }
}
