using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lostra
{
    // Щитамем пиксельные координаты по координатом гексельным
    class mapCalc
    {
        public Global global;

        public mapCalc(Global global)
        {
            this.global = global;
        }

        // Центр гекселя
        public int getRealXbyGecsCenter(int x, int y)
        {
            if (y % 2 == 1)
                return (x) * 48;
            else
                return (x+1)*48 - 24;
        }

        public int getRealYbyGecsCenter(int x, int y)
        {
            return y*40+15;
        }





        // верхий левый угол


        public int getRealXbyGecs(int x, int y)
        {
            if (y % 2 == 1)
                return (x) * 48 - 24;
            else
                return (x) * 48;
        }

        public int getRealYbyGecs(int x, int y)
        {
            return y * 40;
        }
    }
}
