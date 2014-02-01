using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;

using Test_Bitmap.Compilers;

namespace Test_Bitmap
{
    /// <summary>
    /// Use like this...
    /// <code>BitmapCompiler bc = new BitmapCompiler(FILE_NAME, new Compilers.PointColorCompiler() {
    ///     c => Color.FromArgb(c.A, c.B, c.G, c.R)
    /// });
    /// bc.SaveTo(FILE_NAME2);</code>
    /// </summary>
    class BitmapCompiler
    {
        private readonly Bitmap bmp;
        private readonly BitmapData bmpData;
        private readonly IntPtr originalBmp;
        private readonly byte[] buffer;

        private readonly IBufferArrayCompiler[] compilers;

        public BitmapCompiler(string bmpFileName, params IBufferArrayCompiler[] compilers)
        {
            this.compilers = compilers;
            this.bmp = (Bitmap)Bitmap.FromFile(bmpFileName);
            this.bmpData = bmp.LockBits(new Rectangle(Point.Empty, bmp.Size), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            this.buffer = new byte[bmp.Width * bmp.Height * 4];
            this.originalBmp = this.bmpData.Scan0;
            Marshal.Copy(this.originalBmp, this.buffer, 0, buffer.Length);
        }
        private void compileBuffer()
        {
            foreach (var compiler in compilers)
            {
                compiler.compileBuffer(bmp.Width, this.buffer);
            }
        }

        public void SaveTo(string fileName)
        {
            compileBuffer();
            Marshal.Copy(buffer, 0, originalBmp, buffer.Length);
            bmp.UnlockBits(bmpData);
            bmp.Save(fileName);
        }
    }
}
