using System;
using Microsoft.Xna.Framework.Content;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
namespace lostra
{
    class singlePlayerMenu
    {


        public Global global;
        public int selectedMap = 0;

        public singlePlayerMenu(Global global)
        {
            this.global = global;


            #region buttons

            global.hButton.Add(580, 560, "Отмена", "single.cancel");
            global.hButton.Add(280, 560, "Начать игру", "single.start");

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

            #region single.cancel
            global.hButton.Draw("single.cancel");
            if (global.hButton.Cheack("single.cancel"))
                global.localTrigger = 0;
            #endregion

            #region single.start
            if (this.selectedMap != 0)
            {
                global.hButton.Draw("single.start");

                if (global.hButton.Cheack("single.start"))
                {
                    global.gameHandler.Start("01");
                }
            }

            #endregion


            // Level cycle
            for (int i = 0; i < global.resources.listLevels.Count; i++)
            {

                #region levels labels
                int sH =
                    Convert.ToInt32(
                        global.resources.getFont("menu.fonts.levelList").MeasureString(global.resources.listLevels.ElementAt(i).Value.title).Y);

                int sW =
                    Convert.ToInt32(
                        global.resources.getFont("menu.fonts.levelList").MeasureString(global.resources.listLevels.ElementAt(i).Value.title).
                            Length());

                int fH = global.resources.getTexture("lFh").Height;
                int fW = global.resources.getTexture("lFh").Width;

                int sposX = posXF + 50;
                int sposY = (posYF + 50) + i * 50;

                string title = global.resources.listLevels.ElementAt(i).Value.title;
                #endregion

                #region if selected
                if ((i + 1) == this.selectedMap)
                {
                    global.spriteBatch.Draw(global.resources.getTexture("lFh"), new Vector2(sposX, sposY), Color.White);


                    global.spriteBatch.DrawString(global.resources.getFont("menu.fonts.levelList"),
                                                  title, new Vector2(sposX + 20, sposY + ((fH - sH) / 2)), Color.White);
                }
                #endregion

                #region if not selected
                if ((i + 1) != this.selectedMap)
                {
                    if (new Rectangle(sposX, sposY, fW, fH).Contains(Mouse.GetState().X, Mouse.GetState().Y))
                    {
                        global.spriteBatch.Draw(global.resources.getTexture("lFh"), new Vector2(sposX, sposY),
                                                Color.White);


                        global.spriteBatch.DrawString(global.resources.getFont("menu.fonts.levelList"),
                                                      title, new Vector2(sposX + 20, sposY + ((fH - sH) / 2)), Color.White);

                        // Selected field
                        if (global.mouseHandler.Check())
                        {
                            this.selectedMap = i + 1;
                        }


                    }
                    else
                    {

                        global.spriteBatch.Draw(global.resources.getTexture("lF"), new Vector2(sposX, sposY),
                                                Color.White);

                        global.spriteBatch.DrawString(global.resources.getFont("menu.fonts.levelList"),
                                                      title, new Vector2(sposX + 20, sposY + ((fH - sH) / 2)), Color.Black);
                    }
                }
                #endregion

                #region minimap
                if (this.selectedMap != 0)
                {
                    int mW = 300;
                    int mH = 155;

                    sposX = 540;
                    sposY = 140;


                    global.spriteBatch.Draw(global.resources.getTexture("mapBorder"), new Vector2(sposX, sposY), Color.White);

                    Texture2D mini = global.resources.listLevels.ElementAt(this.selectedMap - 1).Value.mini;

                    global.spriteBatch.Draw(mini, new Rectangle(sposX + 8, sposY + 8, mW, mH), Color.White);

                }
                #endregion
            }
        }

      

        public void Clean()
        {
            this.selectedMap = 0;
        }


    }
}
