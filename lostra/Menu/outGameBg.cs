using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace lostra
{
    class outGameBg
    {
        public Global global;
        public outGameBg(Global global)
        {
            this.global = global;
        }

        public void Draw()
        {
            global.spriteBatch.Draw(global.resources.getTexture("menu.background.1"), new Rectangle(0, 0, global.windowWidth, global.windowHeight), Color.White);
        }
    }
}
