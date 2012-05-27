using Microsoft.Xna.Framework;
namespace lostra
{
    class loadingScreen
    {
        public Global global;
        
        public loadingScreen(Global global)
        {
            this.global = global;
        }
        public void Draw()
        {
            global.spriteBatch.Begin();

            global.spriteBatch.Draw(global.resources.getTexture("prelogo"), new Vector2(global.windowWidth / 2 - global.resources.getTexture("prelogo").Width / 2, global.windowHeight / 2 - global.resources.getTexture("prelogo").Height), Color.White);

            int unloadWidht = global.windowWidth;
            int unloadHeight = 20;
            int unloadX = 0;
            int unloadY = global.windowHeight - 70;

            global.spriteBatch.Draw(global.resources.getTexture("preunload"), new Rectangle(unloadX,unloadY,unloadWidht,unloadHeight), Color.White);


            int loadWidht = unloadWidht / global.resources.allCount * global.resources.allLoaded;
            int loadHeight = 20;
            int loadX = 0;
            int loadY = global.windowHeight - 70;

            global.spriteBatch.Draw(global.resources.getTexture("preload"), new Rectangle(loadX, loadY, loadWidht, loadHeight), Color.White);

            global.spriteBatch.DrawString(global.resources.getFont("prefont"), global.resources.stringData, new Vector2(10, loadY - 20), Color.White);

            global.spriteBatch.End();
        }
    }
}
