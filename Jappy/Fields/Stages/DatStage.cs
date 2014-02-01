using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jappy.Fields.Stages
{
    using IO;
    using Items;

    class DatStage : IStage
    {
        private readonly string path;
        public DatStage(string path)
        {
            this.path = path;
        }
        public IList<Item> GetItems(Field field)
        {
            IList<Item> list = new List<Item>();
            new DatFileReader(this.GetType().Assembly.GetManifestResourceStream(path))
                .ReadStream_ByHexa(DatFileReader.ByPosition(Field.WIDTH, (x, y, dat) => {
                    Item item = null;
                    switch (dat)
                    {
                        case 0:
                            break;
                        case 1:
                            item = new Me(field);
                            break;
                        case 2:
                            item = new Snake(field);
                            break;
                        case 3:
                            item = new Rmb(field);
                            break;
                        case 4:
                            item = new Mush(field);
                            break;
                        case 5:
                            item = new NormalStone(field);
                            break;
                        case 6:
                            item = new Block(field);
                            break;
                        case 7:
                            item = new BlueStone(field);
                            break;
                        case 8:
                            item = new BlueBlock(field);
                            break;
                        case 9:
                            item = new RedStone(field);
                            break;
                        case 10:
                            item = new RedBlock(field);
                            break;
                        case 11:
                            item = new GreenStone(field);
                            break;
                        case 12:
                            item = new GreenBlock(field);
                            break;
                        case 13:
                            item = new YellowStone(field);
                            break;
                        case 14:
                            item = new YellowBlock(field);
                            break;
                        default:
                            throw new Exception("データファイルが!!");
                    }
                    if (item != null)
                    {
                        item.X = x;
                        item.Y = y;
                        list.Add(item);
                    }
                }));
            return list;
        }
    }
}
