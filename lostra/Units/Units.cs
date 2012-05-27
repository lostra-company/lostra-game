//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Audio;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.GamerServices;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using Microsoft.Xna.Framework.Media;


//namespace lostra
//{
//    class Units
//    {
//        //дикий дебаг переменные
//        KeyboardState oldState;//прибавление AP

//        public int ForCount = 0;//вообще левая штука для записи i из for

//        private Rectangle rect;

//        private bool isCanMove;//проверка можно ли его двигать
//        private bool Active;//проверка выбран ли юнит

//        public List<int> positionX = new List<int>();
//        public List<int> positionY = new List<int>();

//        public bool isLive;//если да, рисуем

//        public int ID;
//        public int AP = 100;//очки действия, одни на все

//        public string UnitText;

//        public MouseState oldState1;
//        public MouseState oldState2;

//        public Texture2D texture;
//        public int x;
//        public int y;
//        public int team;
//        public int MaxHealth;
//        public int AttacPoint;
//        public int AttacPower;
//        public int DefendPower;
//        public int MovePoint;
//        public int CurentHealth;

//        Global global;

//        public Units(Global global)
//        {
//            this.global = global;
//        }

//        public Units(Texture2D texture, int x, int y, int team, int MaxHealth, int AttacPoint, int AttacPower, int DefendPower, int MovePoint)
//        {
//            this.texture = texture;
//            this.x = x;
//            this.y = y;
//            this.team = team;
//            this.MaxHealth = MaxHealth;
//            this.AttacPoint = AttacPoint;
//            this.AttacPower = AttacPower;
//            this.DefendPower = DefendPower;
//            this.MovePoint = MovePoint;
//        }

//        public void MoveUnit()
//        {
//            int bufX = 0;
//            int bufY = 0;
//            MouseState mouse = Mouse.GetState();
           
//            if (isLive)
//            {
//                if (mouse.LeftButton == ButtonState.Pressed && oldState1.LeftButton == ButtonState.Released)
//                {
//                    foreach (KeyValuePair<int,Units> units in global.UnitsList)
//                    {
//                        if (global.gameHandler.HoverCellIdX == units.Value.x && global.gameHandler.HoverCellIdY == units.Value.y)
//                        {
//                            Active = true;
//                            isCanMove = true;
//                            bufX = units.Value.x;
//                            bufY = units.Value.y;
//                            ForCount = units.Key;
//                        }
//                    }
//                }

//                if(isCanMove)
//                    if (mouse.LeftButton == ButtonState.Pressed && oldState1.LeftButton == ButtonState.Released)
//                    {
//                        if (global.gameHandler.HoverCellIdX != bufX && global.gameHandler.HoverCellIdY != bufY)
//                        {
//                            foreach (KeyValuePair<int, Units> units in global.UnitsList)
//                            {
//                                if (units.Key == ForCount)
//                                {
//                                    units.Value.x = global.gameHandler.HoverCellIdX;
//                                    units.Value.y = global.gameHandler.HoverCellIdY;
//                                    isCanMove = false;
//                                    Active = false;
//                                }
//                            }
//                        }
//                    }

//                if(Keyboard.GetState().IsKeyDown(Keys.Z))//дикий тест, убирает выделение
//                {
//                    isCanMove = false;
//                    Active = false;
//                }

//                oldState1 = mouse;
//            }
//          }
                

//        public void AddUnitImMap()
//        {
//            KeyboardState keyboard = Keyboard.GetState();
//            MouseState mouse = Mouse.GetState();

//            if (keyboard.IsKeyDown(Keys.Space) && oldState.IsKeyUp(Keys.Space))//дикий дебаг
//            {
//                AP++;
//            }

//            if (global.globalTrigger == 1)
//            {
//                if (global.gameHandler.HoverCellIdX != -1 && global.gameHandler.HoverCellIdY != -1)
//                {
//                    if (global.gameHandler.HoverCellIdX != 1 && global.gameHandler.HoverCellIdY != 2)//проверка на попадание в здание
//                    {
//                        if (global.AP > 0)
//                        {
//                            if (global.Buildings.isUnitAdd == 2) //проверка щелкнули мы на здание
//                            {
//                                global.spriteBatch.Begin();
//                                global.spriteBatch.Draw(global.resources.getTexture(UnitText), new Vector2(mouse.X, mouse.Y), Color.White);
//                                global.spriteBatch.End();

//                                if (mouse.LeftButton == ButtonState.Pressed && oldState2.LeftButton == ButtonState.Released)
//                                {
//                                    isLive = true;
//                                    global.ID++;
//                                    global.AP--;
//                                    ID++; 
//                                    AP--;
//                                    positionX.Add(global.gameHandler.HoverCellIdX);
//                                    positionY.Add(global.gameHandler.HoverCellIdY);
//                                    global.Buildings.isUnitAdd = 0;
//                                    global.AddUnitInform.AddInArray(global.ChoiceUnit.NumberUnit);
//                                }
//                            }
//                        }
//                    }
//                }
//            }

//            oldState = keyboard;
//            oldState2 = mouse;
//        }
    

//        public void DrawUnit()
//        {
//            if (isLive) // проверка щелчка на карту
//            {
//                if (global.globalTrigger == 1)
//                {
//                    global.spriteBatch.Begin();

//                    foreach (KeyValuePair<int,Units> units in global.UnitsList)
//                    {
//                            if (units.Value.y % 2 == 0)
//                            {
//                                rect = new Rectangle(units.Value.x * 48 + global.gameHandler.shiftMapX + 3,
//                                                     units.Value.y * 40 + global.gameHandler.shiftMapY + 5, 42, 40);
                                
//                            }
//                            if (units.Value.y % 2 == 1)
//                            {
//                                rect = new Rectangle(units.Value.x * 48 - 21 + global.gameHandler.shiftMapX,
//                                                    units.Value.y * 40 + global.gameHandler.shiftMapY + 5, 42, 40);
//                            }

//                            global.spriteBatch.Draw(global.resources.getTexture("heart"),new Vector2(rect.X - 12,rect.Y - 15),Color.White);

//                            global.spriteBatch.DrawString(global.resources.getFont("menu.fonts.button"), ":" + units.Value.MaxHealth,
//                                                          new Vector2(rect.X, rect.Y - 22), Color.Red);

//                            global.spriteBatch.Draw(units.Value.texture, rect, Color.White);

//                        }

//                    global.spriteBatch.End();
//                }

//            }
            

//        }
//    }
//}
