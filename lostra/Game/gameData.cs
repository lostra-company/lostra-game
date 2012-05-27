using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lostra
{
    // База данных
    class gameData
    {
        // Кудаж без него
        public Global global;
        // Игроки
        public Dictionary<int,Player> dataPlayers = new Dictionary<int,Player>();
        // Здания
        public Dictionary<int, Building> dataBuildings = new Dictionary<int, Building>();
        //  Маска юнитов
        public Dictionary<int, buyUnit> dataBuyUnit = new Dictionary<int, buyUnit>();
        // Юниты
        public Dictionary<int, Unit> dataUnits = new Dictionary<int, Unit>();

        public gameData(Global global)
        {
            this.global = global;

            this.initPlayers();
            this.initBuildings();
            this.initBuyListUnits();
            this.initUnits();
        }
        // Создаем маски юнитов
        public void initBuyListUnits()
        {
            #region Орк - оруженосец
            dataBuyUnit.Add(0, new buyUnit(global, "Орк - Оруженосец", "game.unit.orc"));
            dataBuyUnit[0].costGold = 200;
            //dataBuyUnit[0].costWood = 50;
            //dataBuyUnit[0].costIron = 0;
            //dataBuyUnit[0].costPower = 0;
            //dataBuyUnit[0].costDiamond = 0;
            dataBuyUnit[0].hitPoint = 100;
            dataBuyUnit[0].defPoint = 20;
            dataBuyUnit[0].atackPoint = 40;
            dataBuyUnit[0].maxGoWay = 4;
            dataBuyUnit[0].atackRange = 1;
            dataBuyUnit[0].seeRange = 5;
            dataBuyUnit[0].canHide = false;
            dataBuyUnit[0].ActionPoint = 5;
            //dataBuyUnit[0].critChance = 10.0f;
            #endregion

            #region Орк - Солдат
            dataBuyUnit.Add(1, new buyUnit(global, "Орк - Солдат", "game.unit.orc"));
            dataBuyUnit[1].costGold = 300;
            //dataBuyUnit[1].costWood = 100;
            //dataBuyUnit[1].costIron = 50;
            //dataBuyUnit[1].costPower = 0;
            //dataBuyUnit[1].costDiamond = 0;
            dataBuyUnit[1].hitPoint = 150;
            dataBuyUnit[1].defPoint = 40;
            dataBuyUnit[1].atackPoint = 60;
            dataBuyUnit[1].maxGoWay = 6;
            dataBuyUnit[1].atackRange = 1;
            dataBuyUnit[1].seeRange = 7;
            dataBuyUnit[1].canHide = false;
            dataBuyUnit[1].ActionPoint = 5;
            //dataBuyUnit[1].critChance = 15.0f;
            #endregion

            #region Орк - Ветеран
            dataBuyUnit.Add(2, new buyUnit(global, "Орк - Ветеран", "game.unit.orc"));
            dataBuyUnit[2].costGold = 400;
            //dataBuyUnit[2].costWood = 150;
            //dataBuyUnit[2].costIron = 100;
            //dataBuyUnit[2].costPower = 50;
            //dataBuyUnit[2].costDiamond = 0;
            dataBuyUnit[2].hitPoint = 300;
            dataBuyUnit[2].defPoint = 60;
            dataBuyUnit[2].atackPoint = 120;
            dataBuyUnit[2].maxGoWay = 7;
            dataBuyUnit[2].atackRange = 1;
            dataBuyUnit[2].seeRange = 8;
            dataBuyUnit[2].canHide = false;
            dataBuyUnit[2].ActionPoint = 5;
            //dataBuyUnit[2].critChance = 30.0f;
            #endregion

            #region Орк - Герой
            dataBuyUnit.Add(3, new buyUnit(global, "Орк - Герой", "game.unit.orc"));
            dataBuyUnit[3].costGold = 500;
            //dataBuyUnit[3].costWood = 200;
            //dataBuyUnit[3].costIron = 150;
            //dataBuyUnit[3].costPower = 100;
            //dataBuyUnit[3].costDiamond = 1;
            dataBuyUnit[3].hitPoint = 500;
            dataBuyUnit[3].defPoint = 60;
            dataBuyUnit[3].atackPoint = 150;
            dataBuyUnit[3].maxGoWay = 8;
            dataBuyUnit[3].atackRange = 2;
            dataBuyUnit[3].seeRange = 9;
            dataBuyUnit[3].canHide = false;
            dataBuyUnit[3].ActionPoint = 7;
            //dataBuyUnit[3].critChance = 40.0f;
            #endregion

            #region Гоблин - оруженосец
            dataBuyUnit.Add(4, new buyUnit(global, "Гоблин - Оруженосец", "game.unit.goblin"));
            dataBuyUnit[4].costGold = 200;
            //dataBuyUnit[4].costWood = 50;
            //dataBuyUnit[4].costIron = 0;
            //dataBuyUnit[4].costPower = 0;
            //dataBuyUnit[4].costDiamond = 0;
            dataBuyUnit[4].hitPoint = 100;
            dataBuyUnit[4].defPoint = 20;
            dataBuyUnit[4].atackPoint = 40;
            dataBuyUnit[4].maxGoWay = 4;
            dataBuyUnit[4].atackRange = 1;
            dataBuyUnit[4].seeRange = 5;
            dataBuyUnit[4].canHide = false;
            dataBuyUnit[4].ActionPoint = 3;
            //dataBuyUnit[4].critChance = 10.0f;
            #endregion
        }

        public void initPlayers()
        {
            // Игроки
            // мы
            this.dataPlayers.Add(0, new Player(global,false));
            // бот 
            this.dataPlayers.Add(1,new Player(global,true));
        }

        public void initUnits()
        {
            //  Сортируем юнитов по Y чтобы обрисовывлись по порядку растоновки
            this.sortUnits();
        }

        public void initBuildings()
        {
            int inc = 0;
            // Здания
            // Init  player 0 Main building (must always be 0)
            // Создаем нашу базу из данных в файле карты
            int p0bX = global.resources.listLevels[global.gameHandler.levelKey].p0buildMainX;
            int p0bY = global.resources.listLevels[global.gameHandler.levelKey].p0buildMainY;
            this.dataBuildings.Add(inc, new Building(global, 0, p0bX, p0bY, 0,1000));
             
            inc++;
            // Создаем базу вражины
            // Init  player 1 Main building (must always be 1)
            int p1bX = global.resources.listLevels[global.gameHandler.levelKey].p1buildMainX;
            int p1bY = global.resources.listLevels[global.gameHandler.levelKey].p1buildMainY;
            this.dataBuildings.Add(inc, new Building(global, 0, p1bX, p1bY, 1,1000));
        }

        public void Update()
        {
            //  хз че тут делает
        }

        // Сортируем читать выше
        public void sortUnits()
        {
            for (int i = dataUnits.Count - 1; i > 0; i--)
                for (int j = 0; j < i; j++)
                    if (dataUnits.ElementAt(j).Value.uY > dataUnits.ElementAt(j+1).Value.uY)
                    {
                        Unit tmp = dataUnits.ElementAt(j).Value;
                        dataUnits[dataUnits.ElementAt(j).Key] = dataUnits.ElementAt(j + 1).Value;
                        dataUnits[dataUnits.ElementAt(j+1).Key] = tmp;
                    }
        }

    }
}
