﻿using System;
using System.Collections.Generic;
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
    // Меню создания юнита
    class menuCreateUnit
    {
        public Global global;
        // Внутренний буфер
        private int mX = 0;
        private int mY = 0;
        private Texture2D mT;
        private Color mC;

        // какая маска выделена
        private int unitChosed = -1;
        // Можем ли создать
        private bool canBuild = false;

        public menuCreateUnit(Global global)
        {
            this.global = global;

        }

        public void Update()
        {
          

            this.Draw();
        }


        public void Draw()
        {

            global.spriteBatch.Begin();

            // Фон
            mT = global.resources.getTexture("game.menu.createunit");
            mX = global.windowWidth / 2 - mT.Width / 2;
            mY = global.windowHeight / 2 - mT.Height / 2;
            global.spriteBatch.Draw(mT, new Vector2(mX, mY), Color.White);

            // Кнопка закрытия
            mT = global.resources.getTexture("game.menu.createunit.close");
            mX += 623;
            mY += 3;
            if (new Rectangle(mX, mY, mT.Width, mT.Height).Contains(Mouse.GetState().X, Mouse.GetState().Y))
            {
                // Рисуем
                global.spriteBatch.Draw(mT, new Vector2(mX, mY), Color.White);
                // И если нажато закрываем
                if(global.mouseHandler.Check())
                {
                    global.gameHandler.gameMenu.isMenuOpen = false;
                    global.gameHandler.gameMenu.MenuId = 0;
                    unitChosed = -1;
                }
            }


            // Список юнитов
            mT = global.resources.getTexture("game.menu.createunit");
            mX = global.windowWidth / 2 - mT.Width / 2 + 388;
            mY = global.windowHeight / 2 - mT.Height / 2 + 70;
            // По словарику
            for (int i = 0; i < global.gameHandler.GameData.dataBuyUnit.Count; i ++ )
            {

                mT = global.resources.getTexture("game.menu.createunit.label");
                // Если он ща выделен
                if (unitChosed == i)
                {
                    // ... то выделяем
                    global.spriteBatch.Draw(mT, new Vector2(mX, mY), Color.White);
                }
                
                if (new Rectangle(mX, mY, mT.Width, mT.Height).Contains(Mouse.GetState().X, Mouse.GetState().Y))
                {
                    global.spriteBatch.Draw(mT, new Vector2(mX, mY), Color.White);
                    // А если еще и нажали ...
                    if (global.mouseHandler.Check())
                    {
                        this.unitChosed = i;
                    }
                }
                // Ну и подписываем
                global.spriteBatch.DrawString(global.resources.getFont("game.fonts.createUnitList"), global.gameHandler.GameData.dataBuyUnit[i].name, new Vector2(mX + 5, mY + 1), Color.Black);


                // Высота
                mY += mT.Height + 3;
            }


            // Если что нить выделенно, много кода, кароче в конце там если не выделено кнопка серая, а ченить выделено то код ниже
            if(this.unitChosed != -1)
            {
                // Ищем куда нарисовать ....
                mT = global.resources.getTexture("game.menu.createunit");
                mX = global.windowWidth / 2 - mT.Width / 2;
                mY = global.windowHeight / 2 - mT.Height / 2;
                // ... скин юнита 
                mT = global.resources.getTexture(global.gameHandler.GameData.dataBuyUnit[unitChosed].skin + ".b");
                mX += 180 - mT.Width / 2;
                mY += 180 - mT.Height / 2;
                // Рисуем
                global.spriteBatch.Draw(mT, new Vector2(mX, mY), Color.White);


                //////
                // Переводим триггер
                this.canBuild = true;

                // о5 ищем куда рисовать...
                mT = global.resources.getTexture("game.menu.createunit");
                mX = global.windowWidth / 2 - mT.Width / 2 + 35;
                mY = global.windowHeight / 2 - mT.Height / 2 + 315;
                // ... параметры юнита
                // Gold
                // И сразу сичтаем можем ли постоить
                if (global.gameHandler.GameData.dataPlayers[0].resGold >= global.gameHandler.GameData.dataBuyUnit[unitChosed].costGold)
                {
                    mC = Color.White;
                }
                else
                {
                    this.canBuild = false;
                    mC = Color.Red;
                }
                // Рисуем подписываем
                mT = global.resources.getTexture("game.res.gold");
                global.spriteBatch.Draw(mT, new Rectangle(mX, mY, Convert.ToInt32(mT.Width * 0.8f), Convert.ToInt32(mT.Height * 0.8f)), Color.White);
                global.spriteBatch.DrawString(global.resources.getFont("game.fonts.createUnitList"), global.gameHandler.GameData.dataBuyUnit[unitChosed].costGold.ToString(), new Vector2(mX + 30, mY + 1), mC);

                mY += 25;

                // Wood
                if (global.gameHandler.GameData.dataPlayers[0].resWood >= global.gameHandler.GameData.dataBuyUnit[unitChosed].costWood)
                {
                    mC = Color.White;
                }
                else
                {
                    this.canBuild = false;
                    mC = Color.Red;
                }
                mT = global.resources.getTexture("game.res.wood");
                global.spriteBatch.Draw(mT, new Rectangle(mX, mY, Convert.ToInt32(mT.Width * 0.8f), Convert.ToInt32(mT.Height * 0.8f)), Color.White);
                global.spriteBatch.DrawString(global.resources.getFont("game.fonts.createUnitList"), global.gameHandler.GameData.dataBuyUnit[unitChosed].costWood.ToString(), new Vector2(mX + 30, mY + 1), mC);

                mY += 25;

                // Iron
                if (global.gameHandler.GameData.dataPlayers[0].resIron >= global.gameHandler.GameData.dataBuyUnit[unitChosed].costIron)
                {
                    mC = Color.White;
                }
                else
                {
                    this.canBuild = false;
                    mC = Color.Red;
                }
                mT = global.resources.getTexture("game.res.iron");
                global.spriteBatch.Draw(mT, new Rectangle(mX, mY, Convert.ToInt32(mT.Width * 0.8f), Convert.ToInt32(mT.Height * 0.8f)), Color.White);
                global.spriteBatch.DrawString(global.resources.getFont("game.fonts.createUnitList"), global.gameHandler.GameData.dataBuyUnit[unitChosed].costIron.ToString(), new Vector2(mX + 30, mY + 1), mC);

                mY += 25;

                // Power
                if (global.gameHandler.GameData.dataPlayers[0].resPower >= global.gameHandler.GameData.dataBuyUnit[unitChosed].costPower)
                {
                    mC = Color.White;
                }
                else
                {
                    this.canBuild = false;
                    mC = Color.Red;
                }
                mT = global.resources.getTexture("game.res.power");
                global.spriteBatch.Draw(mT, new Rectangle(mX, mY, Convert.ToInt32(mT.Width * 0.8f), Convert.ToInt32(mT.Height * 0.8f)), Color.White);
                global.spriteBatch.DrawString(global.resources.getFont("game.fonts.createUnitList"), global.gameHandler.GameData.dataBuyUnit[unitChosed].costPower.ToString(), new Vector2(mX + 30, mY + 1), mC);

                mY += 25;

                // Diamond
                if (global.gameHandler.GameData.dataPlayers[0].resDiamond >= global.gameHandler.GameData.dataBuyUnit[unitChosed].costDiamond)
                {
                    mC = Color.White;
                }
                else
                {
                    this.canBuild = false;
                    mC = Color.Red;
                }
                mT = global.resources.getTexture("game.res.diamond");
                global.spriteBatch.Draw(mT, new Rectangle(mX, mY, Convert.ToInt32(mT.Width * 0.8f), Convert.ToInt32(mT.Height * 0.8f)), Color.White);
                global.spriteBatch.DrawString(global.resources.getFont("game.fonts.createUnitList"), global.gameHandler.GameData.dataBuyUnit[unitChosed].costDiamond.ToString(), new Vector2(mX + 30, mY + 1), mC);


                /////////////
                /// //////////
                /// //////////


                mT = global.resources.getTexture("game.menu.createunit");
                mX = global.windowWidth / 2 - mT.Width / 2 + 200;
                mY = global.windowHeight / 2 - mT.Height / 2 + 315;

                SpriteFont mF = global.resources.getFont("game.fonts.createUnitList");


                global.spriteBatch.DrawString(mF, "Здоровье: " + global.gameHandler.GameData.dataBuyUnit[unitChosed].hitPoint, new Vector2(mX, mY + 1), Color.White);
                mY += 25;

                global.spriteBatch.DrawString(mF, "Атака: " + global.gameHandler.GameData.dataBuyUnit[unitChosed].atackPoint, new Vector2(mX, mY + 1), Color.White);
                mY += 25;

                global.spriteBatch.DrawString(mF, "Защита: " + global.gameHandler.GameData.dataBuyUnit[unitChosed].defPoint, new Vector2(mX, mY + 1), Color.White);
                mY += 25;


                global.spriteBatch.DrawString(mF, "Крит: " + global.gameHandler.GameData.dataBuyUnit[unitChosed].critChance + "%", new Vector2(mX, mY + 1), Color.White);
                mY += 25; 


                // Create buttom
                // Кнопка создания
                mT = global.resources.getTexture("game.menu.createunit");
                mX = global.windowWidth / 2 - mT.Width / 2 + 507;
                mY = global.windowHeight / 2 - mT.Height / 2 + 462;

                mT = global.resources.getTexture("game.menu.createunit.okH");
                if (new Rectangle(mX, mY, mT.Width, mT.Height).Contains(Mouse.GetState().X, Mouse.GetState().Y))
                {
                    mT = global.resources.getTexture("game.menu.createunit.okH");
                    global.spriteBatch.Draw(mT, new Vector2(mX, mY), Color.White);

                    // Сразу считаем еси на нее нажали
                    // Создаем юнита
                    if (global.mouseHandler.Check())
                    {
                        //  Метод создания, смотреть ниже)
                        this.createUnit();
                        //  Закрываем менюшку
                        global.gameHandler.gameMenu.isMenuOpen = false;
                        global.gameHandler.gameMenu.MenuId = 0;
                        unitChosed = -1;


                    }


                }
                else 
                {
                    
                    mT = global.resources.getTexture("game.menu.createunit.ok");
                    global.spriteBatch.Draw(mT, new Vector2(mX, mY), Color.White);
                }


                
                

            } 
            else
            {
                // Нечего не выделено - серая кнопка
                mT = global.resources.getTexture("game.menu.createunit");
                mX = global.windowWidth / 2 - mT.Width / 2 + 507;
                mY = global.windowHeight / 2 - mT.Height / 2 + 462;
                mT = global.resources.getTexture("game.menu.createunit.okU");
                global.spriteBatch.Draw(mT, new Vector2(mX, mY), Color.White);

            }


            global.spriteBatch.End();

        }

        // Создание юнита, парамет их this. берется

        public void createUnit()
        {
            bool trigger = true;
            // Координаты нашей базы
            int rX = global.gameHandler.GameData.dataBuildings[0].bX;
            int rY = global.gameHandler.GameData.dataBuildings[0].bY;
            // Ищем соседние гексели
            dataGecs r = new dataGecs(rX, rY);
            
            // начинаем со второго круга тк первый еще здание 
            foreach (findGecs c in r.c2)
            {
                trigger = true;
                foreach (Unit u in global.gameHandler.GameData.dataUnits.Values)
                {
                    if (u.uX == c.X && u.uY == c.Y)
                        trigger = false;
                }
                // Если нашли свободный гексель
                if (trigger)
                {
                    // Виии стоим юнита
                    int inc = global.gameHandler.GameData.dataUnits.Count + 1;
                    global.gameHandler.GameData.dataUnits.Add(inc,
                                                             new Unit(global, 0, c.X, c.Y,
                                                                    global.gameHandler.GameData.dataBuyUnit.ElementAt
                                                                        (this.unitChosed).Value));
                    // Сортирем юнитов поСлоям что бы четко накладывались друг на друга
                    global.gameHandler.GameData.sortUnits();
                    return;
                }
            }

        }
    }
}
