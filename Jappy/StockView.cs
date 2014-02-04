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

    public class StockView : Panel
    {
        private int stock = 5;
        private int animeMode = 0;
        private const int MAX = 5;

        public StockView() 
        {
            this.BackColor = Color.Black;
            this.DoubleBuffered = true;
        }

        internal void OnStockChange(int newVal)
        {
            stock = newVal;
            Invalidate();
        }
        internal void Animation()
        {
            animeMode = (animeMode + 1) % 16;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Image image = Me.GetThumbnail(animeMode / 2);
            for (var x = 0; x < stock && x < MAX; x++)
            {
                e.Graphics.DrawImage(image,
                    x * GameView.BLOCK_SIZE * 2,
                    0,
                    GameView.BLOCK_SIZE * 2,
                    GameView.BLOCK_SIZE * 2);
            }
        }
    }
}
