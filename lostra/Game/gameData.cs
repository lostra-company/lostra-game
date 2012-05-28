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
            dataBuyUnit[0].hitPoint = 100;
            dataBuyUnit[0].atackPoint = 40;
            dataBuyUnit[0].maxGoWay = 4;
            dataBuyUnit[0].atackRange = 1;
            #endregion

            #region Орк - Солдат
            dataBuyUnit.Add(1, new buyUnit(global, "Орк - Солдат", "game.unit.orc"));
            dataBuyUnit[1].costGold = 300;
            dataBuyUnit[1].hitPoint = 150;
            dataBuyUnit[1].atackPoint = 60;
            dataBuyUnit[1].maxGoWay = 6;
            dataBuyUnit[1].atackRange = 1;
            #endregion

            #region Орк - Ветеран
            dataBuyUnit.Add(2, new buyUnit(global, "Орк - Ветеран", "game.unit.orc"));
            dataBuyUnit[2].costGold = 400;
            dataBuyUnit[2].hitPoint = 300;
            dataBuyUnit[2].atackPoint = 120;
            dataBuyUnit[2].maxGoWay = 7;
            dataBuyUnit[2].atackRange = 1;
            #endregion

            #region Орк - Герой
            dataBuyUnit.Add(3, new buyUnit(global, "Орк - Герой", "game.unit.orc"));
            dataBuyUnit[3].costGold = 500;
            dataBuyUnit[3].hitPoint = 500;
            dataBuyUnit[3].atackPoint = 150;
            dataBuyUnit[3].maxGoWay = 8;
            dataBuyUnit[3].atackRange = 2;
            #endregion

            #region Гоблин - оруженосец
            dataBuyUnit.Add(4, new buyUnit(global, "Гоблин - Оруженосец", "game.unit.goblin"));
            dataBuyUnit[4].costGold = 200;
            dataBuyUnit[4].hitPoint = 100;
            dataBuyUnit[4].atackPoint = 40;
            dataBuyUnit[4].maxGoWay = 4;
            dataBuyUnit[4].atackRange = 1;
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
