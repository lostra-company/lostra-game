using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Threading;

namespace lostra
{
    class inputHandler
    {

        public Global global;

        public string data = "";
        public bool trigger = false;

        // Допуск ввода 
        // 0 - Все
        // 1 - Цифры
        // 2 - ip adrees
        public int mask = 0;

        // Максимальная длинна
        public int mLenght = 0;

        public inputHandler(Global global)
        {
            this.global = global;
            eventInput.Initialize(global.Window);
            eventInput.CharEntered += new CharEnteredHandler(CharacterEntered);
        }

        public void Start()
        {
            this.data = "";
            this.mask = 0;
            this.trigger = true;
            this.mLenght = 1000;
        }

        public void Start(string data)
        {
            this.data = data;
            this.mask = 0;
            this.trigger = true;
            this.mLenght = 1000;
        }

        public void Start(string data, int mask)
        {
            this.data = data;
            this.mask = mask;
            this.trigger = true;
            this.mLenght = 1000;

        }

        public void Start(string data, int mask,int mLenght)
        {
            this.data = data;
            this.mask = mask;
            this.trigger = true;
            this.mLenght = mLenght;
        }

        public void Stop()
        {
            this.trigger = false;
        }

        public string Get()
        {
            return this.data;
        }

        #region Main calculations
        public void CharacterEntered(object sender, CharacterEventArgs e)
        {
            char[] allowALL = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'o', 'O', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ' ', '.' };
            char[] allowNUM = { 'O', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            char[] allowIP = { 'O', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ' ', '.' };
            if (this.trigger)
            {
                if (!((int)e.Character < 32 || (int)e.Character > 126))
                {
                    if (!(Keyboard.GetState().IsKeyDown(Keys.LeftControl) || Keyboard.GetState().IsKeyDown(Keys.RightControl)))
                    {
                        if (this.mask == 0)
                            if (allowALL.Contains(e.Character))
                                this.data += e.Character;

                        if (this.mask == 1)
                            if (allowNUM.Contains(e.Character))
                                this.data += e.Character;

                        if (this.mask == 2)
                            if (allowIP.Contains(e.Character))
                                this.data += e.Character;


                        if (this.mLenght != 0)
                            if (this.data.Length > this.mLenght)
                                this.data = this.data.Remove(this.mLenght);

                    }
                }
                if ((int)e.Character == 0x08 && this.data.Length > 0)
                {
                    this.data = this.data.Remove(this.data.Length - 1);
                }
            }

        }
        #endregion
    }
}
