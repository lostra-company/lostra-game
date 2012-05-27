using System;
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
    class unitsActionMenu
    {
        public Global global;
        // Внутренний буфер
        private int mX = 0;
        private int mY = 0;
        private Texture2D mT;
        private Texture2D mTh;
        private Color mC;

        //кнопки, пока не выбрали меню, они серые
        private Button AttackB;
        private Button MoveB;
        private Button HealthB;
        private Button SilentB;
        private Button CaptureB;
        private Button CancelB;

        // какая маска выделена
        private int unitChosed = -1;

        public unitsActionMenu(Global global)
        {
            this.global = global;
        }

        public void Update()
        {
            this.Draw();
        }

        public void Draw()
        {
            KeyboardState keyboard = Keyboard.GetState();
            global.spriteBatch.Begin();

            // Фон
            mT = global.resources.getTexture("game.menu.UnitAction");
            mX = global.windowWidth - mT.Width;
            mY = global.windowHeight - mT.Height;
            global.spriteBatch.Draw(mT, new Vector2(mX,mY), Color.White);

            // Кнопка закрытия
            //mT = global.resources.getTexture("game.menu.createunit.close");
            //mX = 274 / 2;
            //mY = 4;
            //if (new Rectangle(mX, mY, 23 / 2, 23 / 2).Contains(Mouse.GetState().X, Mouse.GetState().Y))
            //{
            //    // Рисуем
            //    global.spriteBatch.Draw(mT, new Rectangle(mX, mY, 23 / 2, 23 / 2), Color.White);
            //    // И если нажато закрываем
                if (keyboard.IsKeyDown(Keys.Escape))
                {
                    global.gameHandler.gameMenu.isMenuOpen = false;
                    global.gameHandler.gameMenu.MenuId = 0;
                    unitChosed = -1;
                }
            //}


            // Список команд
            mT = global.resources.getTexture("game.menu.UnitAction");
            mX = global.windowWidth - mT.Width + 30;
            mY = global.windowHeight - mT.Height + 30;

            AttackB = new Button(mX, mY, 120, 30,"Attack",global);
            AttackB.Draw();

            MoveB = new Button(mX, mY + 60, 120, 30, "Move", global);
            MoveB.Draw();

            HealthB = new Button(mX, mY + 120, 120, 30, "Health", global);
            HealthB.Draw();

            SilentB = new Button(mX + 180, mY, 120, 30, "Silent", global);
            SilentB.Draw();

            CaptureB = new Button(mX + 180, mY + 60, 120, 30, "Capture", global);
            CaptureB.Draw();

            CancelB = new Button(mX + 180, mY + 120, 120, 30, "Cancel", global);
            CancelB.Draw();

            if (CancelB.isPresses())
            {
                global.gameHandler.gameMenu.isMenuOpen = false;
                global.gameHandler.gameMenu.MenuId = 0;
                unitChosed = -1;
            }

            if(MoveB.isPresses())
            {
                global.gameHandler.gameMenu.isMenuOpen = false;
                global.gameHandler.gameMenu.MenuId = 0;
                unitChosed = -1;
            }
            
#region фигня
            //for (int i = 0; i < 3; i++)
            //{

            //    mT = global.resources.getTexture("game.menu.ab");
            //    mTh = global.resources.getTexture("game.menu.abH");
            //    // Если он ща выделен
            //    if (unitChosed == i)
            //    {
            //        // ... то выделяем
            //        global.spriteBatch.Draw(mTh, new Rectangle(mX,mY,mT.Width / 2,mT.Height/2), Color.White);
            //    }

            //    if (new Rectangle(mX, mY, mT.Width, mT.Height).Contains(Mouse.GetState().X, Mouse.GetState().Y))
            //    {
            //        global.spriteBatch.Draw(mT, new Rectangle(mX, mY, mT.Width / 2, mT.Height / 2), Color.White);
            //        // А если еще и нажали ...
            //        if (global.mouseHandler.Check())
            //        {
            //            this.unitChosed = i;
            //        }
            //    }
            //    // Ну и подписываем
            //    //global.spriteBatch.DrawString(global.resources.getFont("game.fonts.createUnitList"), global.gameHandler.GameData.dataBuyUnit[i].name, new Vector2(mX + 5, mY + 1), Color.Black);


            //    // Высота
            //    mY += mT.Height + 3;
            //}


            // Если что нить выделенно, много кода, кароче в конце там если не выделено кнопка серая, а ченить выделено то код ниже
            //if (this.unitChosed != -1)
            //{
            //    // Ищем куда нарисовать ....
            //    mT = global.resources.getTexture("game.menu.createunit");
            //    mX = global.windowWidth / 2 - mT.Width / 2;
            //    mY = global.windowHeight / 2 - mT.Height / 2;
            //    // ... скин юнита 
            //    mT = global.resources.getTexture(global.gameHandler.GameData.dataBuyUnit[unitChosed].skin + ".b");
            //    mX += 180 - mT.Width / 2;
            //    mY += 180 - mT.Height / 2;
            //    // Рисуем
            //    global.spriteBatch.Draw(mT, new Vector2(mX, mY), Color.White);


            //    //////
            //    // Переводим триггер
            //   // this.canBuild = true;

            //    // о5 ищем куда рисовать...
            //    mT = global.resources.getTexture("game.menu.createunit");
            //    mX = global.windowWidth / 2 - mT.Width / 2 + 35;
            //    mY = global.windowHeight / 2 - mT.Height / 2 + 315;
            //    // ... параметры юнита
            //    // Gold
            //    // И сразу сичтаем можем ли постоить
            //    if (global.gameHandler.GameData.dataPlayers[0].resGold >= global.gameHandler.GameData.dataBuyUnit[unitChosed].costGold)
            //    {
            //        mC = Color.White;
            //    }
            //    else
            //    {
            //        //this.canBuild = false;
            //        mC = Color.Red;
            //    }
            //    // Рисуем подписываем
            //    mT = global.resources.getTexture("game.res.gold");
            //    global.spriteBatch.Draw(mT, new Rectangle(mX, mY, Convert.ToInt32(mT.Width * 0.8f), Convert.ToInt32(mT.Height * 0.8f)), Color.White);
            //    global.spriteBatch.DrawString(global.resources.getFont("game.fonts.createUnitList"), global.gameHandler.GameData.dataBuyUnit[unitChosed].costGold.ToString(), new Vector2(mX + 30, mY + 1), mC);

            //    mY += 25;

            //    mT = global.resources.getTexture("game.menu.createunit");
            //    mX = global.windowWidth / 2 - mT.Width / 2 + 200;
            //    mY = global.windowHeight / 2 - mT.Height / 2 + 315;

            //    SpriteFont mF = global.resources.getFont("game.fonts.createUnitList");


            //    global.spriteBatch.DrawString(mF, "Здоровье: " + global.gameHandler.GameData.dataBuyUnit[unitChosed].hitPoint, new Vector2(mX, mY + 1), Color.White);
            //    mY += 25;

            //    global.spriteBatch.DrawString(mF, "Атака: " + global.gameHandler.GameData.dataBuyUnit[unitChosed].atackPoint, new Vector2(mX, mY + 1), Color.White);
            //    mY += 25;

            //    global.spriteBatch.DrawString(mF, "Защита: " + global.gameHandler.GameData.dataBuyUnit[unitChosed].defPoint, new Vector2(mX, mY + 1), Color.White);
            //    mY += 25;


            //    global.spriteBatch.DrawString(mF, "Крит: " + global.gameHandler.GameData.dataBuyUnit[unitChosed].critChance + "%", new Vector2(mX, mY + 1), Color.White);
            //    mY += 25;


            //    // Create buttom
            //    // Кнопка создания
            //    mT = global.resources.getTexture("game.menu.createunit");
            //    mX = global.windowWidth / 2 - mT.Width / 2 + 507;
            //    mY = global.windowHeight / 2 - mT.Height / 2 + 462;

            //    mT = global.resources.getTexture("game.menu.createunit.okH");
            //    if (new Rectangle(mX, mY, mT.Width, mT.Height).Contains(Mouse.GetState().X, Mouse.GetState().Y))
            //    {
            //        mT = global.resources.getTexture("game.menu.createunit.okH");
            //        global.spriteBatch.Draw(mT, new Vector2(mX, mY), Color.White);

            //        // Сразу считаем еси на нее нажали
            //        // Создаем юнита
            //        if (global.mouseHandler.Check())
            //        {
            //            //  Метод создания, смотреть ниже)
            //           // this.createUnit();
            //            //  Закрываем менюшку
            //            global.gameHandler.gameMenu.isMenuOpen = false;
            //            global.gameHandler.gameMenu.MenuId = 0;
            //            unitChosed = -1;
            //        }


            //    }
            //    else
            //    {

            //        mT = global.resources.getTexture("game.menu.createunit.ok");
            //        global.spriteBatch.Draw(mT, new Vector2(mX, mY), Color.White);
            //    }





            //}
            //else
            //{
            //    // Нечего не выделено - серая кнопка
            //    mT = global.resources.getTexture("game.menu.createunit");
            //    mX = global.windowWidth / 2 - mT.Width / 2 + 507;
            //    mY = global.windowHeight / 2 - mT.Height / 2 + 462;
            //    mT = global.resources.getTexture("game.menu.createunit.okU");
            //    global.spriteBatch.Draw(mT, new Vector2(mX, mY), Color.White);

            //}
#endregion

            global.spriteBatch.End();

        }
    }
}
