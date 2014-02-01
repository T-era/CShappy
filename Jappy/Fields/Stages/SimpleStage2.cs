using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jappy.Fields.Stages
{
    using Items;

    class SimpleStage2 : IStage
    {
        public IList<Item> GetItems(Field that)
        {
            IList<Item> filled = new List<Item>();
            FillBlock(filled, that, new Dictionary<int, int[]>() {
                { 8, new [] { 8, 9, 10, 11, 12, 13, 14, 15, 18, 19, 20, 21, 22, 23, 24, 25 } },
                { 9, new [] { 8, 9, 10, 11, 12, 13, 14, 15, 18, 19, 20, 21, 22, 23, 24, 25 } },
                { 10, new [] { 10, 11, 14, 15, 18, 19, 22, 23, 24, 25 } },
                { 11, new [] { 10, 11, 14, 15, 16, 17, 18, 19, 24, 25 } },
                { 12, new [] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 } },
                { 13, new [] { 10, 11, 12, 13, 14, 15, 18, 19, 20, 21, 22, 23, 24, 25 } },
                { 14, new [] { 14, 15 } },
            });
            filled.Add(new Me(that) { X = 8, Y = 8 });
            filled.Add(new BlueStone(that) { X = 12, Y = 8 });
            filled.Add(new RedStone(that) { X = 20, Y = 8 });
            filled.Add(new BlueBlock(that) { X = 14, Y = 14 });
            filled.Add(new RedBlock(that) { X = 22, Y = 10 });
            return filled;
        }
        private void FillBlock(IList<Item> list, Field that, IDictionary<int, int[]> ignore)
        {
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    if (! ignore.ContainsKey(y)
                        || ! ignore[y].Contains(x)) 
                        list.Add(new Block(that) { X = x, Y = y });
                }
            }
        }
    }
}
