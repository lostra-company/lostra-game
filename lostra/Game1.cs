using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
namespace lostra
{
    public class Game1 : Game
    {
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Global global;
        SpriteFont debugFont;
      
        #region Game
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        #endregion

        #region Initialize
        protected override void Initialize()
        {
           
            base.Initialize();
            
        }
        #endregion

        protected override void LoadContent()
        {
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();

            spriteBatch = new SpriteBatch(GraphicsDevice);
            global = new Global(this, Content, Window, spriteBatch, GraphicsDevice);
            global.windowHeight = Window.ClientBounds.Height;
            global.windowWidth = Window.ClientBounds.Width;

          
            global.Start();
   
            debugFont = Content.Load<SpriteFont>("debugFont");
        }

        #region UnloadContent
        protected override void UnloadContent()
        {
            global.debug.Close();
            try
            {
                // Рвем соединение
                // TO DO по джентельменски организоватть
                global.multi.handler.serverStream.Close();
                global.multi.mData.myLobby.insideHandle.Abort();
             
            }
            catch (Exception)
            {
                
            }
          
        }
        #endregion 
    
        #region Update
        protected override void Update(GameTime gameTime)
        {
           
            // Пишем специфицеские переменные в класс Глобал
            base.Update(gameTime);
        }
        #endregion

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
 
            global.Update();
            spriteBatch.Begin();



            string aa = "DEBUG: " + global.debugString + " / " + Mouse.GetState().X + " / " + Mouse.GetState().Y + " - - ";
            spriteBatch.DrawString(debugFont, aa, new Vector2(10, 20), Color.Red);

            aa = "INPUT DEBUG: " + global.inputHandler.trigger + " | " + global.inputHandler.data;
            spriteBatch.DrawString(debugFont, aa, new Vector2(10, 40), Color.Red);

            aa = "MULT DEBUG: " + global.multi.mData.myLobby.begin + " | " + global.multi.mData.myLobby.counter;
            spriteBatch.DrawString(debugFont, aa, new Vector2(10, 60), Color.Red);

            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
