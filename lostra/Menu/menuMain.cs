namespace lostra
{
    class menuMain
    {
        public Global global;
        public inGameMenu inGameMenu;
        public outGameMenu outGameMenu;
        public loadingScreen loadingScreen;

        public menuMain(Global global)
        { 
            this.global = global;
            inGameMenu = new inGameMenu(global);
            outGameMenu = new outGameMenu(global);
            loadingScreen = new loadingScreen(global);

        }

        public void Update()
        {
            
            if (global.globalTrigger == 1)
            {
                inGameMenu.Draw();
            }


            if (global.globalTrigger == 0)
            {
                outGameMenu.Draw();
            }

            if (global.globalTrigger == -1)
            {
                loadingScreen.Draw();
            }

            // Дополнительный обсчет на цикле
            this.extraCalculate();
        }

        public void extraCalculate()
        { 
            // Если триггер на 4 то закрываем игру
            if (global.globalTrigger == 0 && global.localTrigger == 4)
                global.game.Exit();  
        }
    }
}
