using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Drawing;

namespace GraphConverter
{
    using Test_Bitmap;
    using Test_Bitmap.Compilers;

    class Program
    {
        const string IMAGE_DIR = @"D:\Bk_Yoshi\Vs\Jappy\Jappy\Images";
        static readonly ColorConverter[] CONVERTERS = new[] {
            new ColorConverter() { ColorName = "Red", Conv = c => Color.FromArgb(c.A, c.B, c.R, c.R) },
            new ColorConverter() { ColorName = "Green", Conv = c => Color.FromArgb(c.A, c.R, c.B, c.R) },
            new ColorConverter() { ColorName = "Yellow", Conv = c => Color.FromArgb(c.A, c.B, c.B, c.R) },
        };

        static void Main(string[] args)
        {
            var imageDir = new DirectoryInfo(IMAGE_DIR);
            foreach (FileInfo blueFile in imageDir.EnumerateFiles("Blue*", SearchOption.TopDirectoryOnly))
            {
                foreach (ColorConverter conv in CONVERTERS)
                {
                    Convert(blueFile, conv);
                }
            }
        }
        static void Convert(FileInfo origin, ColorConverter conv) {
            string destName = origin.Name.Replace("Blue", conv.ColorName);
            FileInfo destFile = new FileInfo(Path.Combine(origin.DirectoryName, destName));
            Console.WriteLine(destFile.FullName);

            new BitmapCompiler(origin.FullName, new PointColorCompiler() { conv.Conv })
                .SaveTo(destFile.FullName);
        }
    }
    class ColorConverter {
        public string ColorName { set; get; }
        public Func<Color, Color> Conv { set; get; }
    }
}
