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
    //  щитаем какой гексель щас выделен
    class mapHover
    {
        Global global;

      
        // Перемеенные для расчета выделеной ячейки
        public int CellPart0 = 11; // Высота треугольника гекселя
        public int CellPart1 = 30; // Высота туловища гекселя
        public int CellPart2 = 42; // Все вместе
        public int CellPart3 = 24; // Ширина половинки гекселя разрез по вертикали

        public mapHover(Global global)
        {
            this.global = global;
        }

        public void Update()
        {
            int x = Mouse.GetState().X - global.gameHandler.shiftMapX;
            int y = Mouse.GetState().Y - global.gameHandler.shiftMapY;

            int bufferYpart = (int)(Math.Floor((double)(y / 40)));

            if ((y % 40) < 2)
            {
                global.gameHandler.HoverCellIdY = bufferYpart - 1;
            }
            else if ((y % 40) > 10 && (y % 40) < 12)
            {
                global.gameHandler.HoverCellIdY = -1;
            }
            else
            {
                global.gameHandler.HoverCellIdY = bufferYpart;
            }

            ////////////////////////////

            if (global.gameHandler.HoverCellIdY != -1)
            {
                if (bufferYpart % 2 == 0)
                {
                    global.gameHandler.HoverCellIdX = calculateHoverX(x);
                }
                else
                {
                    global.gameHandler.HoverCellIdX = calculateHoverX(x + 24);
                }
            }

            this.cheackForBorders();





            foreach (Building b in global.gameHandler.GameData.dataBuildings.Values)
            {
                b.Check();

             
            }
            string bufferTexture = "hover";

        




        }
        public int calculateHoverX(int x)
        {
            return (int)(Math.Floor((double)(x / global.gameHandler.GameUpdate.MapShift.mapCellWidth)));
        }


        public void cheackForBorders()
        {
            // Рамка 1 пк в игре не участвует
            if (global.gameHandler.HoverCellIdX == 0) global.gameHandler.HoverCellIdX = -1;
            if (global.gameHandler.HoverCellIdY == 0) global.gameHandler.HoverCellIdY = -1;

            if (global.gameHandler.HoverCellIdX == global.resources.listLevels[global.gameHandler.levelKey].matrix.GetLength(1) - 1) global.gameHandler.HoverCellIdX = -1;
            if (global.gameHandler.HoverCellIdY == global.resources.listLevels[global.gameHandler.levelKey].matrix.GetLength(0) - 1) global.gameHandler.HoverCellIdY = -1;
        }
    }
}
