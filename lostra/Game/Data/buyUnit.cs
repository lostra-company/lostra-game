using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lostra
{
    // Маска юнитов
    class buyUnit
    {
        public Global global;

        public string mUIN;


        public string name; // название
        public string skin; // название тектуры к ночку прибаляецо .s или .b большой и малый размер, передавать без них. т.е. если текстуры goblin.s и goblin.b передать посто goblin 
        // цены
        public int costGold = 0;

        // характеристики, пока в обработчик нече не забито моно убрать поправить
        public int hitPoint = 0;
        public int atackPoint = 0;
        public int maxGoWay = 0;
        public int atackRange = 1;

        // Тип юнита
        // 0 melie, 1 - range, 2 - mage area
        public int type = 0;



        public buyUnit(Global global,string name,string skin)
        {
            this.global = global;
            this.name = name;
            this.skin = skin;

        }
    }
}
