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
    //  Все просто, рисум выделенную ячейку, если не выделено ни здание ни юнит или не ведомо чего еще
    class drawCellHover
    {
        public Global global;
        //тест
        private UnitAction unit;


        public drawCellHover(Global global)
        {
            this.global = global;
            //тест
            unit = new UnitAction(global);
        }

        public void Draw()
        {
            Texture2D texture = !unit.Unit.isHover
                                    ? global.resources.getTexture("hover")
                                    : global.resources.getTexture("game.map.cHY1");

            if (global.gameHandler.isCellHovered)
            {
                if (global.gameHandler.HoverCellIdY%2 == 0)
                    global.spriteBatch.Draw(texture,
                                            new Vector2(
                                                global.gameHandler.HoverCellIdX*48 + global.gameHandler.shiftMapX,
                                                global.gameHandler.HoverCellIdY*40 + global.gameHandler.shiftMapY),
                                            Color.White);
                if (global.gameHandler.HoverCellIdY%2 == 1)
                    global.spriteBatch.Draw(texture,
                                            new Vector2(
                                                global.gameHandler.HoverCellIdX*48 - 24 + global.gameHandler.shiftMapX,
                                                global.gameHandler.HoverCellIdY*40 + global.gameHandler.shiftMapY),
                                            Color.White);
            }
        }
    }
}
