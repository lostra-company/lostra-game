//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace lostra
//{
//    class AddUnitInform
//    {
//        private int i = 1;

//        private Global global;
//        private Units units;

//        public AddUnitInform(Global global)
//        {
//            this.global = global;
//        }
        
//        public void AddInArray(int UnitNumber)
//        {
//            switch (UnitNumber)
//            {
//                case 1:
//                    units = new Units(global.resources.getTexture("test"), 
//                        global.Units.positionX[global.Units.ID - 1],
//                        global.Units.positionY[global.Units.ID - 1],
//                        1,
//                        150,
//                        5,
//                        10,
//                        3,
//                        14);

//                    global.UnitsList.Add(i,units);
//                    i++;
//                    break;

//                case 2:
//                     units = new Units(global.resources.getTexture("test2"), //текстура
//                        global.Units.positionX[global.Units.ID - 1], //x
//                        global.Units.positionY[global.Units.ID - 1], //y
//                        2,//team
//                        100,//Health
//                        8,//AttacPoint
//                        12,//AttacPower
//                        4,//DefendPower
//                        8);//MovePoint
//                    global.UnitsList.Add(i,units);
//                    i++;
//                    break;
//            }
           
//        }
//    }
//}
