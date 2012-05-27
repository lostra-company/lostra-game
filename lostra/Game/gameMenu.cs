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
    // Игровые менюшечки
    class gameMenu
    {
        public Global global;

        // 0 - Главное меню, 1 - Создание юнита, 2 - меню юнита
        // Открыто ли какоенить меню
        public bool isMenuOpen = false;
        // Какое именно
        public int MenuId = 0;
        public int MenuSubId = 0; // Конкретика, например MenuId=7 (Инфа о юните) а MenuSubId = 98 (Номер этого юнита в словаре)


        // Меню создания новго бойца
        public menuCreateUnit menuCreateUnit;
        //Меню комманд для юнита
        public unitsActionMenu unitsActionMenu;

        public gameMenu(Global global)
        {
            this.global = global;
            this.menuCreateUnit = new menuCreateUnit(global);
            unitsActionMenu = new unitsActionMenu(global);
        }


        public void Update()
        {
            if (this.isMenuOpen)
            {
                // Меню создания юнита
                if (this.MenuId == 1)
                {
                    menuCreateUnit.Update();
                }

                if(this.MenuId == 2)
                {
                   unitsActionMenu.Update();
                }
            }
        }

    }
}
