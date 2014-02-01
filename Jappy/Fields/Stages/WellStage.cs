using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jappy.Fields.Stages
{
    class WellStage : IStage
    {
        public IList<Item> GetItems(Field that)
        {
            return
                new List<Item>() {
                new Jappy.Items.Me(that) { X = 0, Y = 0 },
                new Jappy.Items.BlueStone(that) { X = 2, Y = 0 },
                new Jappy.Items.Block(that) { X = 2, Y = 2 },
                new Jappy.Items.Block(that) { X = 2, Y = 3 },
                new Jappy.Items.Block(that) { X = 2, Y = 4 },
                new Jappy.Items.Block(that) { X = 2, Y = 5 },
                new Jappy.Items.Block(that) { X = 5, Y = 0 },
                new Jappy.Items.Block(that) { X = 5, Y = 1 },
                new Jappy.Items.Block(that) { X = 7, Y = 2 },
                new Jappy.Items.Block(that) { X = 7, Y = 3 },
                new Jappy.Items.Block(that) { X = 5, Y = 4 },
                new Jappy.Items.Block(that) { X = 5, Y = 5 },
                new Jappy.Items.Block(that) { X = 2, Y = 8 },
                new Jappy.Items.Block(that) { X = 3, Y = 9 },
                new Jappy.Items.Snake(that) { X = 3, Y = 2 },
                new Jappy.Items.Snake(that) { X = 3, Y = 4 },
                new Jappy.Items.Snake(that) { X =  5, Y = 2 },
                new Jappy.Items.Snake(that) { X = 4, Y = 9 },
                new Jappy.Items.Snake(that) { X = 4, Y = 11 },
                new Jappy.Items.Snake(that) { X = 4, Y = 13 },
                new Jappy.Items.Snake(that) { X = 4, Y = 15 },
                new Jappy.Items.Block(that) { X = 3, Y = 10 },
                new Jappy.Items.Block(that) { X = 3, Y = 11 },
                new Jappy.Items.Block(that) { X = 3, Y = 12 },
                new Jappy.Items.Block(that) { X = 3, Y = 13 },
                new Jappy.Items.Block(that) { X = 3, Y = 14 },
                new Jappy.Items.Block(that) { X = 3, Y = 15 },
                new Jappy.Items.Block(that) { X = 3, Y = 16 },
                new Jappy.Items.Block(that) { X = 6, Y = 9 },
                new Jappy.Items.Block(that) { X = 6, Y = 10 },
                new Jappy.Items.Block(that) { X = 6, Y = 11 },
                new Jappy.Items.Block(that) { X = 6, Y = 12 },
                new Jappy.Items.Block(that) { X = 6, Y = 13 },
                new Jappy.Items.Block(that) { X = 6, Y = 14 },
                new Jappy.Items.Block(that) { X = 6, Y = 15 },
                new Jappy.Items.Block(that) { X = 6, Y = 16 },
                new Jappy.Items.BlueBlock(that) { X = 6, Y = 19 },
                };
        }
    }
}
