using System;
using System.Collections.Generic;
using System.IO;
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
    class Turn
    {
        public Global global;
        public Player Player;
        private KeyboardState keyboard;

        public Turn(Global global)
        {
            this.global = global;
            Player = new Player(global);
        }

        //в таком виде бы запустить *trolface*
        public void NetxTurn()
        {
            keyboard = Keyboard.GetState();

            if(Player.isBot)
            {
                //if(тут обработчик условий конца хода ИИ, какой нить бул,лежит в ChoiseSolutions)
                Player.isBot = false;
            }
            else
            {
                if(keyboard.IsKeyDown(Keys.Enter))
                {
                    Player.isBot = true;
                }
            }
        }
    }
}
