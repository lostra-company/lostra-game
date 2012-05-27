using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lostra
{
    // Игровой цикл
    class gameUpdate
    { 
        public Global global;
        public mapShift MapShift;
        public mapHover MapHover;
        public updateGameMouse updateGameMouse;
        public unitsUpdate unitsUpdate;
        
        public gameUpdate(Global global)
        {
            this.global = global;
            this.MapShift = new mapShift(global);
            this.MapHover = new mapHover(global);
            this.updateGameMouse = new updateGameMouse(global);
            this.unitsUpdate = new unitsUpdate(global);
        }


        public void Update()
        {
            // Если ни какие менюшки не открыты то обрабатываем игру
            if (!global.gameHandler.gameMenu.isMenuOpen)
            {
                this.MapShift.Update();
                this.MapHover.Update();
                this.updateGameMouse.Update();
                this.unitsUpdate.Update();
               
            }



        }







    }
}
