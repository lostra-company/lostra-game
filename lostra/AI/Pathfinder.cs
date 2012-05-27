using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lostra.AI
{
    class Pathfinder
    {
        public Global global;

        public Pathfinder(Global global)
        {
            this.global = global;
        }

        //обработаем таким образом.
        //    сначала смотрим какой приорите, и где цель.
        //        потом, какой из юнитов ИИ ближе всего, и сильнее, его и двигаем.
        //            все просто.
    }
}
