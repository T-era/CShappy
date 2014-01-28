using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Jappy.Items
{
    using Fields;

    class BlueBlock : Block
    {
        private readonly static new Image image = Image.FromStream(
            typeof(Me).Assembly.GetManifestResourceStream("Jappy.Images.BlueBlock.bmp"));

        public override int Width { get { return 2; } }
        public override int Height { get { return 1; } }

        internal BlueBlock(Field field) : base(field) { }

        protected override void DrawAt(Graphics g, int x, int y, bool animMode)
        {
            g.DrawImage(image, x, y, GameView.BLOCK_SIZE * 2, GameView.BLOCK_SIZE);
        }
    }
}
