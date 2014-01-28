using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Jappy
{
    using Fields;

    public abstract class Item
    {
        protected readonly Field field;
        internal Position Position { get; set; }
        public int X { get { return Position.X; } set { Position.X = value; } }
        public int Y { get { return Position.Y; } set { Position.Y = value; } }
        public abstract int Width { get; }
        public abstract int Height { get; }

        protected Item(Field field)
        {
            this.field = field;
            this.Position = new Position();
        }
        public void Draw(Graphics g, bool anotherway)
        {
            DrawAt(g, X * GameView.BLOCK_SIZE, Y * GameView.BLOCK_SIZE, anotherway);
        }
        protected abstract void DrawAt(Graphics g, int x, int y, bool anotherway); 
    }
}
