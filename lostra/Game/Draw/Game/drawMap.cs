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
    // Рисуем карту
    class drawMap
    {
        public Global global;

        public dataGecs r;

        public drawMap(Global global)
        {
            this.global = global;
          
        }


        public void Draw()
        {
             
            global.spriteBatch.Draw(global.resources.listLevels[global.gameHandler.levelKey].map,
               new Rectangle(global.gameHandler.shiftMapX, global.gameHandler.shiftMapY, 2375, 1239), 
                Color.White);

            for (int j = 0; j < global.resources.listLevels[global.gameHandler.levelKey].matrix.GetLength(0); j++)
            {
                for (int i = 0; i < global.resources.listLevels[global.gameHandler.levelKey].matrix.GetLength(1); i++)
                {

                    //обрисовка сетки
                    if (j % 2 == 0)
                        global.spriteBatch.Draw(global.resources.getTexture("game.map.net"), new Vector2(i * 48 + global.gameHandler.shiftMapX, j * 40 + global.gameHandler.shiftMapY), Color.White);
                    if (j % 2 == 1)
                        global.spriteBatch.Draw(global.resources.getTexture("game.map.net"), new Vector2(i * 48 - 24 + global.gameHandler.shiftMapX, j * 40 + global.gameHandler.shiftMapY), Color.White);
                }
            }







            ////
           


        }
    }
}
