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
    // рисум здания
    class drawBuildings
    {
        public Global global;
        // координаты
        private int bX = 0;
        private int bY = 0;
        // текстура
        private Texture2D bT;
        // внутренний буфер для чегонить тама
        private string resStr = "";


        public drawBuildings(Global global)
        {
            this.global = global;

            // Init textures

        }

        public void Draw()
        {
            // бегаем по словарю
            foreach (Building build in global.gameHandler.GameData.dataBuildings.Values)
            {
                // и рисеум 
                drawIt(build);
            }
            
        }

        public void drawIt(Building b)
        {
            // (Кординты - координаты ячейки + смещение карты - половина длинны \ ширины, для нахождения центра + коректировка по текстуре, для ровности)

            // Хозяин обьекта, подложка семигранная
            switch (b.bOwn)
            {
                // Мы - зелененькии
                case 0: 
                    bT = global.resources.getTexture("game.map.cHG7");
                    if (b.isHover)
                        bT = global.resources.getTexture("game.map.cHG7H");
                    bX = global.gameHandler.MapCalc.getRealXbyGecsCenter(b.bX, b.bY) + global.gameHandler.shiftMapX - bT.Width / 2;
                    bY = global.gameHandler.MapCalc.getRealYbyGecsCenter(b.bX, b.bY) + global.gameHandler.shiftMapY - bT.Height / 2;
                    global.spriteBatch.Draw(bT, new Vector2(bX, bY + 8), Color.White);
                    global.spriteBatch.Draw(global.resources.getTexture("game.build.healt"),new Rectangle(bX,bY,b.HitPoint/7,8),Color.White );
                    break;
                // Вражина красные
                case 1:
                    bT = global.resources.getTexture("game.map.cHR7");
                    if (b.isHover)
                        bT = global.resources.getTexture("game.map.cHR7H");
                    bX = global.gameHandler.MapCalc.getRealXbyGecsCenter(b.bX, b.bY) + global.gameHandler.shiftMapX - bT.Width / 2;
                    bY = global.gameHandler.MapCalc.getRealYbyGecsCenter(b.bX, b.bY) + global.gameHandler.shiftMapY - bT.Height / 2;
                    global.spriteBatch.Draw(bT, new Vector2(bX, bY + 8), Color.White);
                    break;
                // Нетральные желтые
                case 2:
                    bT = global.resources.getTexture("game.map.cHY7");
                    if (b.isHover)
                        bT = global.resources.getTexture("game.map.cHY7H");
                    bX = global.gameHandler.MapCalc.getRealXbyGecsCenter(b.bX, b.bY) + global.gameHandler.shiftMapX - bT.Width / 2;
                    bY = global.gameHandler.MapCalc.getRealYbyGecsCenter(b.bX, b.bY) + global.gameHandler.shiftMapY - bT.Height / 2;
                    global.spriteBatch.Draw(bT, new Vector2(bX, bY + 8), Color.White);
                    break; 
       
            }

            // Тип стоения, сама текстурочка
            switch (b.bType)
            {
                // База
                case 0:
                    bT = global.resources.getTexture("game.build.main");
                    bX = global.gameHandler.MapCalc.getRealXbyGecsCenter(b.bX, b.bY) + global.gameHandler.shiftMapX - bT.Width / 2;
                    bY = global.gameHandler.MapCalc.getRealYbyGecsCenter(b.bX, b.bY) + global.gameHandler.shiftMapY - bT.Height / 2;
                    global.spriteBatch.Draw(bT, new Vector2(bX, bY), Color.White);
                    break;
            }

        }

    }
}
