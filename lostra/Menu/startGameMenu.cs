using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Text;
using System.Net.Sockets;
using System.Threading;
namespace lostra
{
    class startGameMenu
    {
        public Global global;

        // Message state 1- Connection 2 - Erorr 3 - OK,to 0
        public int msgState = 0;

        public bool blockIt = false;

        public startGameMenu(Global global)
        {
            this.global = global;

            // Some buttons
            global.hButton.Add(global.windowWidth / 2 - global.hButton.Width / 2, global.windowHeight / 2 - global.hButton.Height / 2, "Соединение...", "mult.connection", true);
            global.hButton.Add(global.windowWidth / 2 - global.hButton.Width / 2, global.windowHeight / 2 - global.hButton.Height / 2, "Ошибка...", "mult.error", true);
            global.hButton.Add(global.windowWidth / 2 - global.hButton.Width / 2, global.windowHeight / 2 - global.hButton.Height / 2, "OK", "mult.ok", true);
        }

        #region Draw
        public void Draw()
        {
            // if not blocked
            if (!blockIt)
            {
                this.drawLabel(1);
                this.drawLabel(2);
                this.drawLabel(3);
                this.drawLabel(4);
            }

            this.extraDraw();
        }
        #endregion

        public void drawLabel(int i)
        {

            string label0 = "menu.start." + i + "0";
            string label1 = "menu.start." + i + "1";

            int width = global.resources.getTexture(label0).Width;
            int height = global.resources.getTexture(label0).Height;

            int posX = global.windowWidth / 2 - width / 2;
            int posY = global.windowHeight / 8 * (i+1);

            Rectangle rect = new Rectangle(posX, posY, width, height);



            if (new Rectangle(posX, posY, width, height).Contains(Mouse.GetState().X, Mouse.GetState().Y))
            {
                global.spriteBatch.Draw(global.resources.getTexture(label1), rect, Color.White);

                if (global.mouseHandler.Check())
                {
                    // Do manualy
                    if (i == 1)
                    {
                        global.menuHandlerV.outGameMenu.singlePlayerMenu.Clean();
                        global.localTrigger = 1;
                    }

                    // Configuration
                    if (i == 3)
                    {
                        global.localTrigger = 3;
                        // load Config
                        global.menuHandlerV.outGameMenu.confMenu.Load();
                    }

                    // EXIT
                    if (i == 4)
                        global.localTrigger = 4;

                    #region Multiplayer mindows NULL

                    //global.menuHandlerV.outGameMenu.multiplayerWindowsState = 0;


                    #region Multiplayer calc
                    if (i == 2)
                    {
                        this.blockIt = true;
                        this.msgState = 1;

                        Thread ctThread = new Thread(new ThreadStart(global.multi.inMenuConnect));
                        ctThread.Start();
                    }
                    #endregion

                    #endregion

                    global.bufferTrigger = 1;
                }
            }
            else
            {
                global.spriteBatch.Draw(global.resources.getTexture(label0), rect, Color.White);
            }



          
        }

        #region Msg draw
        public void extraDraw()
        {
            // Connection label
            if (this.msgState == 1)
                global.hButton.Draw("mult.connection");

            // label that we cannot connected
            if (this.msgState == 2)
            {
                    global.hButton.Draw("mult.error");
                    if(global.hButton.Cheack("mult.error"))
                    {
                        this.msgState = 0;
                        this.blockIt = false;

                    }
            }
            // if all ok, go to the server
            if (this.msgState == 3)
            {
                global.hButton.Draw("mult.ok");
                this.msgState = 0;
                this.blockIt = false;
                global.localTrigger = 2;
                // Extra calculations to first connection
                global.multi.postConnect();
            }
        }
        #endregion

    }
}
