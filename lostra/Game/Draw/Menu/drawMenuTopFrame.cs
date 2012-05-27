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
    // Верхний фрем де ресы у нас
    class drawMenuTopFrame
    {
        public Global global;
        int resX = 0;
        int resY = 0;
        string resStr = "";


        public drawMenuTopFrame(Global global)
        { 
            this.global = global;
            
            // Init textures
            
        }

        public void Draw()
        {
            Texture2D topframe = global.resources.getTexture("game.menu.topframe");
            global.spriteBatch.Draw(topframe, new Vector2(global.windowWidth - topframe.Width, 0),  Color.White);


            // Gold

            resX = global.windowWidth - topframe.Width + 20;
            resY = topframe.Height / 2 - global.resources.getTexture("game.res.gold").Height / 2;
            global.spriteBatch.Draw(global.resources.getTexture("game.res.gold"), new Vector2(resX, resY), Color.White);

            resStr = Convert.ToString(global.gameHandler.GameData.dataPlayers[0].resGold);
            global.spriteBatch.DrawString(global.resources.getFont("game.fonts.resources"), resStr, new Vector2(resX + 30, 7), Color.White);

            //// Wood
            //resX += 100;
            //resY = topframe.Height / 2 - global.resources.getTexture("game.res.wood").Height / 2;
            //global.spriteBatch.Draw(global.resources.getTexture("game.res.wood"), new Vector2(resX, resY), Color.White);

            //resStr = Convert.ToString(global.gameHandler.GameData.dataPlayers[0].resWood);
            //global.spriteBatch.DrawString(global.resources.getFont("game.fonts.resources"), resStr, new Vector2(resX + 30, 7), Color.White);

            //// Iron
            //resX += 100;
            //resY = topframe.Height / 2 - global.resources.getTexture("game.res.iron").Height / 2;
            //global.spriteBatch.Draw(global.resources.getTexture("game.res.iron"), new Vector2(resX, resY), Color.White);

            //resStr = Convert.ToString(global.gameHandler.GameData.dataPlayers[0].resIron);
            //global.spriteBatch.DrawString(global.resources.getFont("game.fonts.resources"), resStr, new Vector2(resX + 30, 7), Color.White);

            //// Power
            //resX += 100;
            //resY = topframe.Height / 2 - global.resources.getTexture("game.res.power").Height / 2;
            //global.spriteBatch.Draw(global.resources.getTexture("game.res.power"), new Vector2(resX, resY), Color.White);
           
            //resStr = Convert.ToString(global.gameHandler.GameData.dataPlayers[0].resPower);
            //global.spriteBatch.DrawString(global.resources.getFont("game.fonts.resources"), resStr, new Vector2(resX + 30, 7), Color.White);



            //// Diamond
            //resX += 100;
            //resY = topframe.Height / 2 - global.resources.getTexture("game.res.diamond").Height / 2;
            //global.spriteBatch.Draw(global.resources.getTexture("game.res.diamond"), new Vector2(resX, resY), Color.White);

            //resStr = Convert.ToString(global.gameHandler.GameData.dataPlayers[0].resDiamond);
            //global.spriteBatch.DrawString(global.resources.getFont("game.fonts.resources"), resStr, new Vector2(resX + 30, 7), Color.White);

        }


    }
}
