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
    // рисуем юнитов
    class drawUnits
    {
        public Global global;

        private int uX = 0;
        private int uY = 0;
        private Texture2D uT;
        private string resStr = "";

        public drawUnits(Global global)
        {
            this.global = global;
            
        }


        public void Draw()
        {
            // По словарику бегаем
                for (int i = 0; i < global.gameHandler.GameData.dataUnits.Count; i ++)
                    // И рисуем
                    drawIt(global.gameHandler.GameData.dataUnits.ElementAt(i).Value);
            
        }

        public void drawIt(Unit u)
        {
            // Хозяина свитчем, рисум подложку
            switch (u.owner)
            {
                // Мы - зелененькии
                case 0:
                    uT = global.resources.getTexture("game.map.cHG1");
                    if (u.isHover)
                        uT = global.resources.getTexture("game.map.cHG1H");
                    uX = global.gameHandler.MapCalc.getRealXbyGecsCenter(u.uX, u.uY) + global.gameHandler.shiftMapX - uT.Width / 2;
                    uY = global.gameHandler.MapCalc.getRealYbyGecsCenter(u.uX, u.uY) + global.gameHandler.shiftMapY - uT.Height / 2;
                    global.spriteBatch.Draw(uT, new Vector2(uX, uY + 9), Color.White);
                    global.spriteBatch.Draw(global.resources.getTexture("game.build.healt"), new Rectangle(uX,uY-2, u.mask.hitPoint / 10, 8), Color.White);
                    break;
                // Вражина красные 
                case 1:
                    uT = global.resources.getTexture("game.map.cHR1");
                    if (u.isHover)
                        uT = global.resources.getTexture("game.map.cHR1H");
                    uX = global.gameHandler.MapCalc.getRealXbyGecsCenter(u.uX, u.uY) + global.gameHandler.shiftMapX - uT.Width / 2;
                    uY = global.gameHandler.MapCalc.getRealYbyGecsCenter(u.uX, u.uY) + global.gameHandler.shiftMapY - uT.Height / 2;
                    global.spriteBatch.Draw(uT, new Vector2(uX, uY + 9), Color.White);
                    break;
            }


            // Рисуем шкурку
            // поправки на текстуры для ровности
            int corrX = 0;
            int corrY = 0;

            switch (u.mask.skin)
            {
                case "game.unit.orc": corrX = - 6; break;
            }


            uT = global.resources.getTexture(u.mask.skin + ".s");


            uX = global.gameHandler.MapCalc.getRealXbyGecsCenter(u.uX, u.uY) + global.gameHandler.shiftMapX - uT.Width / 2 + corrX;
            uY = global.gameHandler.MapCalc.getRealYbyGecsCenter(u.uX, u.uY) + global.gameHandler.shiftMapY - uT.Height / 2 + corrY;
            global.spriteBatch.Draw(uT, new Vector2(uX, uY), Color.White);
        }
    }
}
