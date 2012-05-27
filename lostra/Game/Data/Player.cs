using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lostra
{
    // Сам игрок, создаюца 2 класа 0 мы, 1 или бот или мультиплеер, в апдейте нуно буит тупо вставить чей ща ход и еси ход 1 то врубаешь обработчик бота
    class Player
    {
        public Global global;
        public bool isBot = false; // ну собсно бот это или мульиплеер, есно будет вребаца ИИ или неа

        
        // Data

        // // resources
        // ресы игрока, начальные беруца из файла карты
        public int resGold = 0;
        //public int resWood = 0;
        //public int resIron = 0;
        //public int resPower = 0;
        //public int resDiamond = 0;


        public Player(Global global, bool bot)
        {
            this.global = global;
            this.isBot = bot;
            // Грузим ресы
            this.initResources();
        }

        public Player(Global global)
        {
            this.global = global;
            // Грузим ресы
            this.initResources();
        }


        public void initResources()
        {
            this.resGold = global.resources.listLevels[global.gameHandler.levelKey].sResGold;
            //this.resWood = global.resources.listLevels[global.gameHandler.levelKey].sResWood;
            //this.resIron = global.resources.listLevels[global.gameHandler.levelKey].sResIron;
            //this.resPower = global.resources.listLevels[global.gameHandler.levelKey].sResPower;
            //this.resDiamond = global.resources.listLevels[global.gameHandler.levelKey].sResDiamond;
        }

    }
}
