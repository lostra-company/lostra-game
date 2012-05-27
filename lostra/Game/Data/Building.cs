using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lostra
{
    class Building
    {
        public Global global;

        public bool isHover = false;

        // 0 - База, 1 - золотодобыча
        
        public int bType = 0;

        //0 - наша, 1 - противник
        public int team;

        // Cords
        public int bX = -1;
        public int bY = -1;
      
        // pID owner ( 0 - we, 1 - bot or mult, 2 netral)
        public int bOwn = 2;

        //жизнь здания
        public int HitPoint;

        // Все клетки здания
        int[] cellsArrayX = new int[7];
        int[] cellsArrayY = new int[7];

        public Building(Global global,int bType,int bX,int bY,int bOwn,int HitPoint)
        {
            this.global = global;
            this.bType = bType;
            this.bX = bX;
            this.bY = bY;
            this.bOwn = bOwn;
            this.HitPoint = HitPoint;
            // Получем маску занятых гекселей
            this.getGecs();
        }

        public void getGecs()
        {
            cellsArrayX[0] = bX;
            cellsArrayY[0] = bY;

            cellsArrayX[1] = bX+1;
            cellsArrayY[1] = bY;

            cellsArrayX[2] = bX-1;
            cellsArrayY[2] = bY;
            //
            if(bY % 2 == 0)
            {
                cellsArrayX[3] = bX;
                cellsArrayY[3] = bY - 1;

                cellsArrayX[4] = bX + 1;
                cellsArrayY[4] = bY - 1;

                cellsArrayX[5] = bX;
                cellsArrayY[5] = bY + 1;

                cellsArrayX[6] = bX + 1;
                cellsArrayY[6] = bY + 1;
            }
            else
            {
                cellsArrayX[3] = bX - 1;
                cellsArrayY[3] = bY - 1;

                cellsArrayX[4] = bX;
                cellsArrayY[4] = bY - 1;

                cellsArrayX[5] = bX - 1;
                cellsArrayY[5] = bY + 1;

                cellsArrayX[6] = bX;
                cellsArrayY[6] = bY + 1;
            }

        }

        public bool Check()
        {
            // Проверяем попадание мышки
            for(int i = 0; i < 7; i ++)
            {
                if(this.cellsArrayX[i] == global.gameHandler.HoverCellIdX && this.cellsArrayY[i] == global.gameHandler.HoverCellIdY)
                {
                    // И сразу щелчок мыши если был
                    if (global.mouseHandler.Check())
                    {
                        // Сначала перевеодим триггер, потом цикл
                        global.gameHandler.gameMenu.MenuId = 1;
                        global.gameHandler.gameMenu.isMenuOpen = true;
                    }

                    this.isHover = true;
                    return true;
                }
                else
                {
                    this.isHover = false;
                }
            }
            return false;
        }


    }
}
