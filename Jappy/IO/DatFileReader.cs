using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Jappy.IO
{

    public class DatFileReader
    {
        private const int BUFFER_SIZE = 1024;
        private readonly Stream forRead;
        public DatFileReader(Stream stream)
        {
            if (!stream.CanRead) throw new ArgumentException("よめない");
            this.forRead = stream;
        }
        public void ReadStream_ByBytes(Action<long, byte> callBack) {
            byte[] buffer = new byte[BUFFER_SIZE];
            int read;
            long position = 0;
            while ((read = forRead.Read(buffer, 0, BUFFER_SIZE)) != 0)
            {
                for (int i = 0; i < read; i ++) {
                    callBack(position++, buffer[i]);
                }
            }
        }
        public void ReadStream_ByHexa(Action<long, byte> callBack)
        {
            byte[] buffer = new byte[BUFFER_SIZE];
            int read;
            long position = 0;
            while ((read = forRead.Read(buffer, 0, BUFFER_SIZE)) != 0)
            {
                for (int i = 0; i < read; i++)
                {
                    callBack(position++, (byte)(buffer[i] / 16));
                    callBack(position++, (byte)(buffer[i] % 16));
                }
            }
        }

        public static Action<long, byte> ByPosition(int width, Action<int, int, byte> dest)
        {
            return (index, dat) =>
            {
                int x = (int)(index % width);
                int y = (int)(index / width);
                dest(x, y, dat);
            };
        }
    }
}