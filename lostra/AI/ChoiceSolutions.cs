using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lostra
{
    class ChoiceSolutions
    {
        public Global global;
        public Player Player;
        public dataGecs Gecs;
        public UnitAction UnitAction;
        
        public int Priority;

        public ChoiceSolutions(Global global)
        {
            this.global = global;
            Player = new Player(global);
            UnitAction = new UnitAction(global);
        }

        public int ChoisePriority()
        {
            int i = 0;
            //смотрит кто ходит. ту ход противника
            if(Player.isBot)
            {
                //бежим по массиву юнитов
                foreach (var units in global.gameHandler.GameData.dataUnits)
                {
                    //ищем кол-во юнитов
                    if(units.Value.owner == 1)
                    {
                        i++;//если находим, инкапсуляция, и так далее
                    }
                }

                //если у нас больше 2 юнитов, то  goto на другие
                if(i < 2)
                {
                    this.BuildingUnitsPriority();
                }
            }
            //{
            //    lable 1: проверяем наличие юнитов, если нет,создаем
            //        {
            //            проверяем, хватает ли ресурсов для юниита.

            //                 если нет, идем их добывать

            //                если ресурсы есть, создаем ~ 2 юнита, самые дешевые
            //        }

            //    проверям, виден ли противник в 5 кругах
            //    {
            //        если виден, то сколько
            //        {
            //            идем к самому ближнему и слабому, от которого остальные враги дальше всего
            //        }
            //    }

            //    проверям, знаем ли мы где база
            //    {
            //        если да, и юнитов достаточно, пытаемся атаковать

            //        если да, но нет юнитов, goto lable 1
            //    }

            //    поверяем, сколько протиников в радиусе 4 кругов от нашей базы
            //    {
            //        если овер9000, выдвигаем самых сильных и близких на защиту

            //        если все ок, забиваем
            //    }

            //}
            return 0;
        }

        //0
        public void AttackBasePriority()
        {
            //пишем сюда условия, обработчики всякие
            foreach (var building in global.gameHandler.GameData.dataBuildings)
            {
                if (building.Value.team == 0)
                {
                    foreach (var units in global.gameHandler.GameData.dataUnits)
                    {
                        if (units.Value.owner == 1)
                        {
                            Gecs = new dataGecs(units.Value.uX, units.Value.uY);
                            foreach (var c2 in Gecs.c2)
                            {
                                if (c2.X == building.Value.bX && c2.Y == building.Value.bY)
                                {
                                    UnitAction.AttacBase(units.Value.uX, units.Value.uY, building.Value.bX, building.Value.bY);
                                }
                            }
                        }
                    }
                }
            }
        }

        //1
        public void AttackUnitPriority()
        {
            //пишем сюда условия, обработчики всякие
            
        }

        //2
        public void GoldPriority()
        {
            //пишем сюда условия, обработчики всякие
            
        }

        //3
        public void DeffendsBasePriority()
        {
            //пишем сюда условия, обработчики всякие
            
        }

        //4
        public void BuildingUnitsPriority()
        {
            //пишем сюда условия, обработчики всякие
           
        }
    }
}
