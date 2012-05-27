using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace lostra
{
    // Юнит
    class Unit
    {
        public Global global;
        // Хозяин 0 - мы, 1 не мы)
        public int owner;
        // кординаты
        public int uX;
        public int uY;
        // маска из buyUnit, 
        public buyUnit mask;
        // выделен или нет, из апдейта в главном классе
        public bool isHover = false;

        public Unit(Global global,int owner,int uX,int uY,buyUnit mask)
        {
            this.global = global;
            this.owner = owner;
            this.uX = uX;
            this.uY = uY;
            this.mask = mask;
        }

        public Unit(Global global)
        {
            this.global = global;
        }

        // вызываеца в апдете - маус хандлер 
        public bool Check()
        {
            // Проверяем попадание мышки
            // 
            if (uX != global.gameHandler.HoverCellIdX || uY != global.gameHandler.HoverCellIdY)
            {
                // не попали
                isHover = false;
            }
            else
            {
                // И сразу щелчок мыши если был
                if (global.mouseHandler.Check())
                {
                    // Сначала переводим триггер, потом цикл
                    global.gameHandler.gameMenu.MenuId = 2;
                    //global.gameHandler.gameMenu.isMenuOpen = true;
                }
                // попали
                isHover = true;
                // валим
                return true;
            }

            return false;
        }

    }
}
