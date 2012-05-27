using System;
using Microsoft.Xna.Framework.Content;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace lostra
{
    internal class confMenu
    {

        public Global global;

        #region Label 1 conf

        public bool labelNAME_B = false;
        public string labelNAME_T = "";

        #endregion

        #region Label 2 conf

        public bool labelIP_B = false;
        public string labelIP_T = "";

        #endregion

        public confMenu(Global global)
        {
            this.global = global;

            #region buttons

            global.hButton.Add(580, 560, "Отмена", "conf.cancel");
            global.hButton.Add(280, 560, "Сохранить", "conf.save");

            #endregion

       
        }



        public void Draw()
        {

            #region Фон

            string labelF = "menu.background.field";

            int widthF = global.resources.getTexture(labelF).Width;
            int heightF = global.resources.getTexture(labelF).Height;

            int posXF = global.windowWidth / 2 - widthF / 2;
            int posYF = global.windowHeight / 2 - heightF / 2;

            Rectangle rect = new Rectangle(posXF, posYF, widthF, heightF);

            global.spriteBatch.Draw(global.resources.getTexture(labelF), rect, Color.White);

            #endregion

            global.hButton.Draw("conf.cancel");
            if (global.hButton.Cheack("conf.cancel"))
            {
                this.Clean();
                global.localTrigger = 0;
            }

            global.hButton.Draw("conf.save");
            if (global.hButton.Cheack("conf.save"))
            {
                this.Save();
                this.Clean();
                global.localTrigger = 0;
            }



            #region Лейбел Никнейма
             
            string labelNAME_TEX = "iL";

            int labelNAME_W = global.resources.getTexture(labelNAME_TEX).Width;
            int labelNAME_H = global.resources.getTexture(labelNAME_TEX).Height;

            int labelNAME_PX = posXF + 350;
            int labelNAME_PY = posYF + 50;


            // LABEL TITLE
            string labelNAME_TIT = "Ник-нейм: ";
         
            global.spriteBatch.DrawString(global.resources.getFont("menu.fonts.levelList"), labelNAME_TIT, new Vector2(posXF + 60, labelNAME_PY + 5), Color.Black);


            Rectangle labelNAME_RECT = new Rectangle(labelNAME_PX, labelNAME_PY, labelNAME_W, labelNAME_H);

            // IF FOCUSED
            if (this.labelNAME_B)
            {
                // label
                global.spriteBatch.Draw(global.resources.getTexture(labelNAME_TEX + "i"), labelNAME_RECT, Color.White);

                // new text
                this.labelNAME_T = global.inputHandler.Get();
                global.spriteBatch.DrawString(global.resources.getFont("menu.fonts.levelList"), labelNAME_T, new Vector2(labelNAME_PX + 5, labelNAME_PY + 5), Color.Black);


                // IF CLICKED NO FOCUS
                if (!labelNAME_RECT.Contains(Mouse.GetState().X, Mouse.GetState().Y))
                {
                    if (global.mouseHandler.Check())
                    {
                        this.labelNAME_B = false;
                        // Stop input
                        global.inputHandler.Stop();
                    }
                }
            }

            // IF NOT FOCUSED
            if(!this.labelNAME_B)
            {
                if (labelNAME_RECT.Contains(Mouse.GetState().X, Mouse.GetState().Y))
                {
                    global.spriteBatch.Draw(global.resources.getTexture(labelNAME_TEX + "h"), labelNAME_RECT, Color.White);

                    // IF CLICKED
                    if (global.mouseHandler.Check())
                    {
                        if (!this.labelIP_B)
                        {
                            this.labelNAME_B = true;

                            // Start input
                            global.inputHandler.Start(this.labelNAME_T, 0, 20);
                        }
                    }
                }
                else
                {
                    global.spriteBatch.Draw(global.resources.getTexture(labelNAME_TEX), labelNAME_RECT, Color.White);
                }

                // Draw label
                global.spriteBatch.DrawString(global.resources.getFont("menu.fonts.levelList"), labelNAME_T, new Vector2(labelNAME_PX + 5, labelNAME_PY + 5), Color.Black);

            }
            



            #endregion

            #region Лейбел IP адресса

            string labelIP_TEX = "iL";

            int labelIP_W = global.resources.getTexture(labelIP_TEX).Width;
            int labelIP_H = global.resources.getTexture(labelIP_TEX).Height;

            int labelIP_PX = posXF + 350;
            int labelIP_PY = posYF + 90;


            // LABEL TITLE
            string labelIP_TIT = "IP Адресс сервера: ";

            global.spriteBatch.DrawString(global.resources.getFont("menu.fonts.levelList"), labelIP_TIT, new Vector2(posXF + 60, labelIP_PY + 5), Color.Black);


            Rectangle labelIP_RECT = new Rectangle(labelIP_PX, labelIP_PY, labelIP_W, labelIP_H);

            // IF FOCUSED
            if (this.labelIP_B)
            {
                // label
                global.spriteBatch.Draw(global.resources.getTexture(labelIP_TEX + "i"), labelIP_RECT, Color.White);

                // new text
                this.labelIP_T = global.inputHandler.Get();
                global.spriteBatch.DrawString(global.resources.getFont("menu.fonts.levelList"), labelIP_T, new Vector2(labelIP_PX + 5, labelIP_PY + 5), Color.Black);


                // IF CLICKED NO FOCUS
                if (!labelIP_RECT.Contains(Mouse.GetState().X, Mouse.GetState().Y))
                {
                    if (global.mouseHandler.Check())
                    {
                        this.labelIP_B = false;
                        // Stop input
                        global.inputHandler.Stop();
                    }


                }
            }

            // IF NOT FOCUSED
            if (!this.labelIP_B)
            {


                if (labelIP_RECT.Contains(Mouse.GetState().X, Mouse.GetState().Y))
                {
                    global.spriteBatch.Draw(global.resources.getTexture(labelIP_TEX + "h"), labelIP_RECT, Color.White);

                    // IF CLICKED
                    if (global.mouseHandler.Check())
                    {
                        this.labelIP_B = true;

                        // Start input
                        global.inputHandler.Start(this.labelIP_T, 2, 16); ;
                    }

                }
                else
                {
                    global.spriteBatch.Draw(global.resources.getTexture(labelIP_TEX), labelIP_RECT, Color.White);
                }

                // Draw label
                global.spriteBatch.DrawString(global.resources.getFont("menu.fonts.levelList"), labelIP_T, new Vector2(labelIP_PX + 5, labelIP_PY + 5), Color.Black);

            }




            #endregion

        }


        public void Load()
        {
            this.labelNAME_T = global.resources.Config.confNick;
            this.labelIP_T = global.resources.Config.confIPserver;
        }

        public void Save()
        {
            global.resources.Config.confNick = this.labelNAME_T;
            global.resources.Config.confIPserver = this.labelIP_T;
        }

        public void Clean()
        {
            this.labelIP_B = false;
            this.labelNAME_B = false;

        }
    }
}
