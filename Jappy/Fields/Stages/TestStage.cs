using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jappy.Fields.Stages
{
    class TestStage : IStage
    {
        public IList<Item> GetItems(Field that)
        {
            return
                new List<Item>() {
                new Jappy.Items.Me(that) { X = 27, Y = 5 },
                new Jappy.Items.BlueStone(that) { X = 2, Y = 4 },
                new Jappy.Items.Block(that) { X = 2, Y = 6 },
                new Jappy.Items.Block(that) { X = 2, Y = 7 },
                new Jappy.Items.Block(that) { X = 3, Y = 6 },
                new Jappy.Items.Block(that) { X = 3, Y = 7 },
                new Jappy.Items.Block(that) { X = 4, Y = 6 },
                new Jappy.Items.Block(that) { X = 4, Y = 7 },
                new Jappy.Items.Block(that) { X = 5, Y = 6 },
                new Jappy.Items.Block(that) { X = 5, Y = 7 },
                new Jappy.Items.Block(that) { X = 6, Y = 6 },
                new Jappy.Items.Block(that) { X = 6, Y = 7 },
                new Jappy.Items.Block(that) { X = 6, Y = 8 },
                new Jappy.Items.Block(that) { X = 6, Y = 9 },
                new Jappy.Items.Block(that) { X = 7, Y = 6 },
                new Jappy.Items.Block(that) { X = 7, Y = 7 },
                new Jappy.Items.Block(that) { X = 7, Y = 8 },
                new Jappy.Items.Block(that) { X = 7, Y = 9 },
                new Jappy.Items.NormalStone(that) { X = 8, Y = 0 },
                new Jappy.Items.Block(that) { X = 8, Y = 2 },
                new Jappy.Items.Block(that) { X = 8, Y = 3 },
                new Jappy.Items.Block(that) { X = 9, Y = 2 },
                new Jappy.Items.Block(that) { X = 9, Y = 3 },
                new Jappy.Items.Block(that) { X = 8, Y = 10 },
                new Jappy.Items.Block(that) { X = 8, Y = 11 },
                new Jappy.Items.Mush(that) { X = 8, Y = 6 },
                new Jappy.Items.Mush(that) { X = 9, Y = 6 },
                new Jappy.Items.Block(that) { X = 9, Y = 10 },
                new Jappy.Items.Block(that) { X = 9, Y = 11 },
                new Jappy.Items.Block(that) { X = 10, Y = 8 },
                new Jappy.Items.Block(that) { X = 10, Y = 9 },
                new Jappy.Items.Block(that) { X = 11, Y = 8 },
                new Jappy.Items.Block(that) { X = 11, Y = 9 },
                new Jappy.Items.NormalStone(that) { X = 12, Y = 0 },
                new Jappy.Items.Block(that) { X = 12, Y = 2 },
                new Jappy.Items.Block(that) { X = 12, Y = 3 },
                new Jappy.Items.Block(that) { X = 13, Y = 2 },
                new Jappy.Items.Block(that) { X = 13, Y = 3 },
                new Jappy.Items.Block(that) { X = 12, Y = 15 },
                new Jappy.Items.Block(that) { X = 12, Y = 16 },
                new Jappy.Items.Block(that) { X = 13, Y = 15 },
                new Jappy.Items.Block(that) { X = 13, Y = 16 },
                new Jappy.Items.BlueBlock(that) { X = 14, Y = 12 },
                new Jappy.Items.Snake(that) { X = 0, Y = 16 },

                new Jappy.Items.NormalStone(that) { X = 30, Y = 0 },
                new Jappy.Items.Block(that) { X = 29, Y = 4 },
                new Jappy.Items.Snake(that) { X = 30, Y = 4 },
                new Jappy.Items.Block(that) { X = 29, Y = 7 },
                new Jappy.Items.Snake(that) { X = 30, Y = 7 },
                new Jappy.Items.Rmb(that) { X = 30, Y = 16 },
                //new Jappy.Items.Me(this) { X = 1, Y = 1  },
                //new Jappy.Items.Block(this) { X = 3, Y = 3 },
                //new Jappy.Items.Mush(this) { X = 5, Y = 1 },
                //new Jappy.Items.Mush(this) { X = 6, Y = 1 },
                //new Jappy.Items.Block(this) { X = 5, Y = 7 },
                //new Jappy.Items.Block(this) { X = 6, Y = 7 },
                //new Jappy.Items.Block(this) { X = 7, Y = 7 },
                //new Jappy.Items.Block(this) { X = 8, Y = 8 },
                //new Jappy.Items.Block(this) { X = 9, Y = 9 },
                //new Jappy.Items.Block(this) { X = 5, Y = 19 },
                //new Jappy.Items.BlueStone(this) { X = 7, Y = 3 },
                //new Jappy.Items.NormalStone(this) { X = 7, Y = 1 },
                //new Jappy.Items.Block(this) { X = 7, Y = 19 },
                //new Jappy.Items.Block(this) { X = 8, Y = 19 },
                //new Jappy.Items.BlueBlock(this) { X = 9, Y = 19 },
                //new Jappy.Items.Block(this) { X = 11, Y = 19 },
            };
        }
    }
}
