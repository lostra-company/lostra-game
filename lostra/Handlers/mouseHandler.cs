using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace lostra
{
    class mouseHandler
    {

        public bool mouseKeyPressed;
        public Global global;



        public mouseHandler(Global global)
        {
            this.global = global;
        }

        public bool Check()
        {
            if (!global.game.IsActive)
                return false;

            if(this.mouseKeyPressed == false && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                this.mouseKeyPressed = true;
                return true;
            }
            return false;
        }

        public void Update()
        {
            if (Mouse.GetState().LeftButton == ButtonState.Released)
            {
                    this.mouseKeyPressed = false;
            }

        }
   
    }
}
