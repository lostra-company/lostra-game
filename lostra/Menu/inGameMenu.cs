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
    class inGameMenu
    {
        public Global global;
        KeyboardState keyboardState;
        private Texture2D PausaMenu;
        public inGameMenu(Global global)
        {
            this.global = global;
        }
        
        public void Draw()
        {
            global.spriteBatch.Begin();
         

            global.spriteBatch.End();
            
        }
    }
}
