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
        private const int MAX = 10;

        public MushroomView() 
        {
            this.BackColor = Color.Black;
        }
        internal void OnInPocketChange(int newVal)
        {
            inPocket = newVal;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            for (var x = 0; x < inPocket && x < MAX; x++)
            {
                e.Graphics.DrawImage(Mush.image, x * GameView.BLOCK_SIZE, 0, GameView.BLOCK_SIZE, GameView.BLOCK_SIZE);
            }
        }
    }
}
