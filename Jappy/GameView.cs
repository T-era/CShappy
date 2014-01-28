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

    public class GameView : Panel
    {
        private static Pen BORDER_PEN = Pens.Black;
        internal const int BLOCK_SIZE = 20;
        private Context context = new Context();
        internal Field Field
        {
            set
            {
                context.SetStage(value);
            }
        }

        public GameView() {
            context.OnChange += () =>
            {
                this.Invalidate();
            };
            this.DoubleBuffered = true;
            this.BackColor = Color.Black;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (context != null
                && context.Field != null)
            {
                    context.Field.ForEach((item) =>
                    {
                        item.Draw(e.Graphics, context.AnimationFlag);
                    });
            }
            this.Focus();
        }
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.Focus();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            context.PushKey(e.KeyCode);
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            context.ReleaseKey(e.KeyCode);
        }
    }
}
