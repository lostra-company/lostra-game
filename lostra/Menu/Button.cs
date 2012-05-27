using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using SYS_DRAW = System.Drawing;
namespace lostra
{
    class Button
    {
        private int x;
        private int y;
        private int w;
        private int h;
        private string title;
        public Global global;

        public bool spriteInit = false;


        public Button(int x, int y, int w, int h, string title,Global global)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.title = title;
            this.global = global;
        }

        public Button(int x, int y, string title, Global global)
        {
            this.x = x;
            this.y = y;
            this.w = 291;
            this.h = 59;
            this.title = title;
            this.global = global;

        }

        public void Draw()
        {

            int sH = Convert.ToInt32(global.resources.getFont("menu.fonts.button").MeasureString(title).Y);
            int sW = Convert.ToInt32(global.resources.getFont("menu.fonts.button").MeasureString(title).X);
           
            

            if (new Rectangle(x, y, w, h).Contains(Mouse.GetState().X, Mouse.GetState().Y))
            {
                global.spriteBatch.Draw(global.resources.getTexture("mBh"), new Rectangle(x, y, w, h), Color.White);


                global.spriteBatch.DrawString(global.resources.getFont("menu.fonts.button"),
                                                 title, new Vector2(x + ((w - sW) / 2), y + ((h - sH) / 2)), Color.FromNonPremultiplied(255,127,0,255));
            }
            else 
            {
                global.spriteBatch.Draw(global.resources.getTexture("mB"), new Rectangle(x, y, w, h), Color.White);

                
                global.spriteBatch.DrawString(global.resources.getFont("menu.fonts.button"),
                                                  title, new Vector2(x + ((w - sW) / 2), y + ((h - sH) / 2)), Color.FromNonPremultiplied(255, 225, 184, 255));
            }

           
        }

        public void Draw(int caze)
        {

            int sH = Convert.ToInt32(global.resources.getFont("menu.fonts.button").MeasureString(title).Y);
            int sW = Convert.ToInt32(global.resources.getFont("menu.fonts.button").MeasureString(title).X);


            if(caze == 0)
            {

                global.spriteBatch.Draw(global.resources.getTexture("mBu"), new Rectangle(x, y, w, h), Color.White);


                global.spriteBatch.DrawString(global.resources.getFont("menu.fonts.button"),
                                                  title, new Vector2(x + ((w - sW) / 2), y + ((h - sH) / 2)), Color.FromNonPremultiplied(255, 225, 184, 255));
            }


            if (caze == 1)
            {

                global.spriteBatch.Draw(global.resources.getTexture("mB"), new Rectangle(x, y, w, h), Color.White);


                global.spriteBatch.DrawString(global.resources.getFont("menu.fonts.button"),
                                                  title, new Vector2(x + ((w - sW) / 2), y + ((h - sH) / 2)), Color.FromNonPremultiplied(255, 225, 184, 255));
            }

        }

        public bool isPresses()
        {
            if (new Rectangle(x, y, w, h).Contains(Mouse.GetState().X, Mouse.GetState().Y))
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed && global.mouseHandler.mouseKeyPressed == false)
                {
                    return true;
                }
            }
            return false;
        }

    }



}
