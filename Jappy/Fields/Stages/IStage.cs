using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jappy.Fields.Stages
{
    public interface IStage
    {
        IList<Item> GetItems(Field that);
    }
}
