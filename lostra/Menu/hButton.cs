using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
namespace lostra
{
    class hButton
    {

        public Global global;
        public Dictionary<string,Button> listButtons = new Dictionary<string, Button>();

        public int Width = 291;
        public int Height = 59;

        public hButton(Global global)
        {
            this.global = global;
        }

        public void Add(int x, int y, int w, int h, string title,string key)
        {
            listButtons.Add(key,new Button(x,y,w,h,title,global));
        }

        public void Add(int x, int y,string title, string key)
        {
            listButtons.Add(key, new Button(x, y, title, global));
        }

        public void Add(int x, int y, string title, string key,bool a)
        {
            listButtons.Add(key, new Button(x, y, title, global));
            listButtons[key].spriteInit = true;
        }

        public void Draw(string key)
        {

                this.listButtons[key].Draw();
        }

        public void Draw(string key,int caze)
        {
            this.listButtons[key].Draw(caze);
        }

        public bool Cheack(string key)
        {
            try
            {
               return this.listButtons[key].isPresses();
            }
            catch (Exception ex)
            {
                global.debug.WriteLine("No button in dictionary");
                return false;
            }
        }

    }
}
