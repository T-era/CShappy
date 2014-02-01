using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Test_Bitmap.Compilers
{
    public class PointColorCompiler : IBufferArrayCompiler, IEnumerable<Func<Color, Color>>
    {
        private readonly IList<Func<Color, Color>> compilers = new List<Func<Color, Color>>();

        public void Add(Func<Color, Color> newFunc)
        {
            compilers.Add(newFunc);
        }

        public void compileBuffer(int width, byte[] buffer)
        {
            for (var index = 0; index < buffer.Length; index += 4)
            {
                byte a = buffer[index + 3];
                byte r = buffer[index + 2];
                byte g = buffer[index + 1];
                byte b = buffer[index + 0];
                Color c = Color.FromArgb(a, r, g, b);
                foreach (var f in compilers)
                {
                    c = f(c);
                }
                buffer[index + 3] = c.A;
                buffer[index + 2] = c.R;
                buffer[index + 1] = c.G;
                buffer[index + 0] = c.B;
            }
        }

        public IEnumerator<Func<Color, Color>> GetEnumerator()
        {
            return compilers.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return compilers.GetEnumerator();
        }
    }
}
