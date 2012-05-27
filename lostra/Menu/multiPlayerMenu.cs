using System;
using Microsoft.Xna.Framework.Content;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace lostra
{
    internal class multiPlayerMenu
    {

        public Global global;

        // 0 - in server
        // 1 - create new game
        // 2 - in the lobby
        public int multiplayerWindowsState = 0;


        public bool ipAdreesInputTrigger = false;
        public bool ipAdreesHoverTrigger = false;

        public int selectedMap = 0;
        public int selectedLobby = 0;

        public multiPlayerMenu(Global global)
        {
            this.global = global;

            #region buttons
            global.hButton.Add(580, 560, "Создать игру", "mult.newgame");
            global.hButton.Add(280, 560, "Обновить", "mult.refresh");

            global.hButton.Add(580, 560, "Войти в игру", "mult.join");

            global.hButton.Add(580, 560, "Создать", "mult.create.ok");
            global.hButton.Add(280, 560, "Отмена", "mult.create.cancel");

            global.hButton.Add(580, 560, "Готов / Не готов", "mult.lobby.ready");
            global.hButton.Add(280, 560, "Выйти", "mult.lobby.exit");


            for (int i = 0; i < 8; i++)
            {
                int sposX = 645;
                int sposY = 140 + i * 50;
                global.hButton.Add(sposX, sposY,203,42, "Войти", "mult.join." + i);

                global.hButton.Add(sposX, sposY, 203, 42, "Готов", "mult.ready." + i);
                global.hButton.Add(sposX, sposY, 203, 42, "Не готов", "mult.unready." + i);
            }



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


            #region STATE - 0 / In the server

            if (this.multiplayerWindowsState == 0)
            {
               

                #region mult.newgame
                global.hButton.Draw("mult.newgame");

                if (global.hButton.Cheack("mult.newgame"))
                {
                    this.multiplayerWindowsState = 1;
                    return;
                }
                #endregion

                #region mult.refresh
                global.hButton.Draw("mult.refresh");

                if(global.hButton.Cheack("mult.refresh"))
                {
                    global.multi.mCommands.refreshLobbyList();
                    return;
                }


                #endregion


                for (int i = 0; i < global.multi.mData.dLobby.Count; i++)
                {

                    #region mult.join.i
                    global.hButton.Draw("mult.join." + i);
                    
                    if(global.hButton.Cheack("mult.join." + i))
                        global.multi.mCommands.joinLobby(global.multi.mData.dLobby.ElementAt(i).Value.uin);

                    #endregion

                    #region lobbys labels
                    int sH =
                        Convert.ToInt32(
                            global.resources.getFont("menu.fonts.levelList").MeasureString(global.resources.listLevels.ElementAt(i).Value.title).Y);

                    int sW =
                        Convert.ToInt32(
                            global.resources.getFont("menu.fonts.levelList").MeasureString(global.resources.listLevels.ElementAt(i).Value.title).
                                Length());

                    int fH = global.resources.getTexture("blFh").Height;
                    int fW = global.resources.getTexture("blFh").Width;

          

                    int sposX = posXF + 50;
                    int sposY = (posYF + 50) + i * 50;

                    string map = "";
                    string uin = "";
                    string plr = "";
                    string tit = "";
                    string title = "";

                    try
                    {
                        map = global.multi.mData.dLobby.ElementAt(i).Value.map;
                        uin = global.multi.mData.dLobby.ElementAt(i).Value.uin;
                        plr = global.multi.mData.dLobby.ElementAt(i).Value.players;
                        tit = global.resources.listLevels[map].title;
                        title = tit + " (" + plr + ")";
                    }
                    catch (Exception)
                    {
                        break; 
                    }
                    


                    #endregion

                    #region if selected
                    if ((i + 1) == this.selectedLobby)
                    {
                        global.spriteBatch.Draw(global.resources.getTexture("blFh"), new Vector2(sposX, sposY), Color.White);


                        global.spriteBatch.DrawString(global.resources.getFont("menu.fonts.levelList"),
                                                      title, new Vector2(sposX + 20, sposY + ((fH - sH) / 2)), Color.White);
                    }
                    #endregion

                    #region if not selected
                    if ((i + 1) != this.selectedLobby)
                    {
                        if (new Rectangle(sposX, sposY, fW, fH).Contains(Mouse.GetState().X, Mouse.GetState().Y))
                        {
                            global.spriteBatch.Draw(global.resources.getTexture("blFh"), new Vector2(sposX, sposY),
                                                    Color.White);


                            global.spriteBatch.DrawString(global.resources.getFont("menu.fonts.levelList"),
                                                          title, new Vector2(sposX + 20, sposY + ((fH - sH) / 2)), Color.White);

                            // Selected field
                            if (global.mouseHandler.Check())
                            {
                                this.selectedLobby = i + 1;
                            }


                        }
                        else
                        {

                            global.spriteBatch.Draw(global.resources.getTexture("blF"), new Vector2(sposX, sposY),
                                                    Color.White);

                            global.spriteBatch.DrawString(global.resources.getFont("menu.fonts.levelList"),
                                                          title, new Vector2(sposX + 20, sposY + ((fH - sH) / 2)), Color.Black);
                        }
                    }
                    #endregion

             
                }

            }

            #endregion


            #region STATE - 1 / Create game

            if (this.multiplayerWindowsState == 1)
            {

                #region mult.create.ok
                global.hButton.Draw("mult.create.ok");

                if (global.hButton.Cheack("mult.create.ok"))
                {
                    this.multiplayerWindowsState = 0;

                    // Create
                    if (this.selectedMap > 0)
                        global.multi.mCommands.createLobby(global.resources.listLevels.ElementAt(this.selectedMap - 1).Value.uin);

                    return;
                }

                #endregion

                #region mult.create.cancel
                global.hButton.Draw("mult.create.cancel");

                if (global.hButton.Cheack("mult.create.cancel"))
                    this.multiplayerWindowsState = 0;
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

            #endregion


            #region STATE - 2 / In the lobby

            if (this.multiplayerWindowsState == 2)
            {

                #region mult.lobby.ready
                global.hButton.Draw("mult.lobby.ready");
                if (global.hButton.Cheack("mult.lobby.ready"))
                {
                    global.multi.mCommands.setReady();
                }

                #endregion

                #region mult.lobby.exit
                global.hButton.Draw("mult.lobby.exit");
                if (global.hButton.Cheack("mult.lobby.exit"))
                {
                    global.multi.mCommands.leaveLobby();
                    return;
                }
       
                #endregion

                string counter_texture = "counter.5u";
                if (global.multi.mData.myLobby.begin == "False")
                {
                    counter_texture = "counter.5u";
                }
                if (global.multi.mData.myLobby.begin == "True")
                {
                    if(global.multi.mData.myLobby.counter == 5)
                        counter_texture = "counter.5";

                    if (global.multi.mData.myLobby.counter == 4)
                        counter_texture = "counter.4";

                    if (global.multi.mData.myLobby.counter == 3)
                        counter_texture = "counter.3";

                    if (global.multi.mData.myLobby.counter == 2)
                        counter_texture = "counter.2";

                    if (global.multi.mData.myLobby.counter == 1)
                        counter_texture = "counter.1";

                    if (global.multi.mData.myLobby.counter < 1)
                        counter_texture = "counter.0";
                }

                

                int counter_width = global.resources.getTexture(counter_texture).Width;
                int counter_height = global.resources.getTexture(counter_texture).Height;
                int counter_x = posXF + widthF /2 - counter_width / 2;
                int counter_y = posYF + heightF / 2 - counter_height / 2;
                Rectangle counter_rect = new Rectangle(counter_x, counter_y, counter_width, counter_height);
                global.spriteBatch.Draw(global.resources.getTexture(counter_texture), counter_rect, Color.White);

             

                for (int i = 0; i < global.multi.mData.myLobby.playersList.Count; i++)
                {

                    #region lobbys labels
                    int sH =
                        Convert.ToInt32(
                            global.resources.getFont("menu.fonts.levelList").MeasureString(global.resources.listLevels.ElementAt(i).Value.title).Y);

                    int sW =
                        Convert.ToInt32(
                            global.resources.getFont("menu.fonts.levelList").MeasureString(global.resources.listLevels.ElementAt(i).Value.title).
                                Length());

                    int fH = global.resources.getTexture("blFh").Height;
                    int fW = global.resources.getTexture("blFh").Width;



                    int sposX = posXF + 50;
                    int sposY = (posYF + 50) + i * 50;

                    string name = "";
                    string btnn = "";
                    try
                    {
                        name = global.multi.mData.myLobby.playersList.ElementAt(i).Key;
                        btnn = global.multi.mData.myLobby.playersList.ElementAt(i).Value;
                    }
                    catch (Exception)
                    {
                        break;
                    }



                    #endregion

                    #region Draw
                    if (btnn == "False")
                            global.hButton.Draw("mult.unready." + i,0);

                        if (btnn == "True")
                            global.hButton.Draw("mult.ready." + i, 1);
                    

                        global.spriteBatch.Draw(global.resources.getTexture("blFh"), new Vector2(sposX, sposY), Color.White);


                        global.spriteBatch.DrawString(global.resources.getFont("menu.fonts.levelList"),
                                                      name, new Vector2(sposX + 20, sposY + ((fH - sH) / 2)), Color.White);

                    #endregion

                }








            }

            #endregion

        }
    }
}
