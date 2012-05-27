using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace lostra
{
    class DrawActionMenu
    {
        public Global global;
        private int mX = 0;
        private int mY = 0;
        private Texture2D mT;

        public DrawActionMenu(Global global)
        { 
            this.global = global;
        }

        public void Draw()
        {
            // Фон
            mT = global.resources.getTexture("game.menu.UnitAction");
            mX = global.windowWidth - mT.Width;
            mY = global.windowHeight - mT.Height;
            global.spriteBatch.Draw(mT, new Vector2(mX, mY), Color.White);
        }
    }
}
