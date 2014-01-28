using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace Jappy
{
    using Fields;
    using Items;

    public class MushroomView : Panel
    {
        private int inPocket = 0;
        private const int MAX = 20;

        public MushroomView() 
        {
            this.BackColor = Color.Black;
            this.Size = new Size(GameView.BLOCK_SIZE * MAX, GameView.BLOCK_SIZE * 3);
        }
        internal void OnInPocketChange(int newVal)
        {
            inPocket = newVal;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            for (var x = 0; x < MAX; x++)
            {
                e.Graphics.DrawImage(Block.image, x * GameView.BLOCK_SIZE, 0);
                if (x < inPocket)
                {
                    e.Graphics.DrawImage(Mush.image, (x+1) * GameView.BLOCK_SIZE, GameView.BLOCK_SIZE);
                }
                e.Graphics.DrawImage(Block.image, x * GameView.BLOCK_SIZE, GameView.BLOCK_SIZE * 2);
            }
            e.Graphics.DrawImage(Block.image, 0, GameView.BLOCK_SIZE);
            e.Graphics.DrawImage(Block.image, GameView.BLOCK_SIZE * (MAX - 1), GameView.BLOCK_SIZE);
        }
    }
}
