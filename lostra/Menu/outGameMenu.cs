using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace lostra
{
    class outGameMenu
    {
    

        public Global global;
        public singlePlayerMenu singlePlayerMenu;
        public multiPlayerMenu multiPlayerMenu;
        public startGameMenu startGameMenu;
        public confMenu confMenu;
        public outGameBg outGameBg;

    
     
         
 

        // номер выводимого окна мультиплеера
       

        public bool showLoading = false;

        public outGameMenu(Global global)
        {
            this.global = global;

            singlePlayerMenu = new singlePlayerMenu(global);
            multiPlayerMenu = new multiPlayerMenu(global);
            startGameMenu = new startGameMenu(global);
            outGameBg = new outGameBg(global);
            confMenu = new confMenu(global);
        }
        public void Draw()
        {

         
            // Отлов нажатий кнопок на клаве
            calculateKeyPressedTrigger();

            //  Начинаем обрисовывать
            global.spriteBatch.Begin();
            // Рисуем фон
            outGameBg.Draw();

            // В зависимости какое меню активно
            // 0
            if (global.localTrigger == 0)
                startGameMenu.Draw();

            ////////////////////////////////////
            // 1
            if (global.localTrigger == 1)
            {
                singlePlayerMenu.Draw();
            }

            ////////////////////////////////////
            // 2
            if (global.localTrigger == 2)
                multiPlayerMenu.Draw();

            ////////////////////////////////////
            // 2
            if (global.localTrigger == 3)
                confMenu.Draw();


            global.spriteBatch.End();
        }





        private void calculateKeyPressedTrigger()
        {
            // По Esc в главное меню
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                // DO EMPTY HERE
                // If in multiplayer? refuse connection
                if(global.localTrigger == 2)
                {
                    global.multi.closeAll();
                }
                global.localTrigger = 0;

                global.inputHandler.Stop();
                this.confMenu.Clean();

            }
        }

 

    }
}
