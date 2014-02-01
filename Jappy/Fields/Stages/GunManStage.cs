using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jappy.Fields.Stages
{
    class GunManStage : IStage
    {
        public IList<Item> GetItems(Field that)
        {
            return
                new List<Item>() {
                new Jappy.Items.Me(that) { X = 0, Y = 18 },
                new Jappy.Items.BlueStone(that) { X = 1, Y = 0 },
                new Jappy.Items.BlueBlock(that) { X = 0, Y = 2 },
                new Jappy.Items.Block(that) { X = 1, Y = 17 },
                new Jappy.Items.Block(that) { X = 3, Y = 16 },
                new Jappy.Items.Block(that) { X = 5, Y = 17 },
                new Jappy.Items.Block(that) { X = 7, Y = 16 },
                new Jappy.Items.Block(that) { X = 9, Y = 17 },
                new Jappy.Items.Block(that) { X = 11, Y = 16 },
                new Jappy.Items.Block(that) { X = 13, Y = 17 },
                new Jappy.Items.Block(that) { X = 15, Y = 16 },
                new Jappy.Items.Block(that) { X = 17, Y = 17 },
                new Jappy.Items.Block(that) { X = 19, Y = 16 },
                new Jappy.Items.Block(that) { X = 21, Y = 17 },
                new Jappy.Items.Block(that) { X = 23, Y = 16 },
                new Jappy.Items.Block(that) { X = 25, Y = 17 },
                new Jappy.Items.Block(that) { X = 27, Y = 16 },
                new Jappy.Items.Block(that) { X = 29, Y = 16 },
                new Jappy.Items.Rmb(that) { X = 0, Y = 13 },
                new Jappy.Items.Rmb(that) { X = 2, Y = 13 },
                new Jappy.Items.Rmb(that) { X = 4, Y = 13 },
                new Jappy.Items.Rmb(that) { X = 8, Y = 13 },
                new Jappy.Items.Rmb(that) { X = 10, Y = 13 },
                new Jappy.Items.Mush(that) { X = 10, Y = 19 },
                new Jappy.Items.Mush(that) { X = 14, Y = 19 },
                new Jappy.Items.Mush(that) { X = 12, Y = 19 },
                new Jappy.Items.Mush(that) { X = 16, Y = 19 },
                };
        }
    }
}
