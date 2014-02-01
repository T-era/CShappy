using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Bitmap.Compilers
{
    public interface IBufferArrayCompiler
    {
        void compileBuffer(int width, byte[] buffer);
    }
}