using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lostra
{

    class drawMain
    {
        public Global global;

        public drawMain(Global global)
        {
            this.global = global;
        }




        //public void Update()
        //{
        //    if (this.globalTrigger == 1)
        //    {
        //        this.map.Draw();

        //        this.graficsHandlerV.UPDATE();

        //        this.cursorHandlerV.getCellHoverId();

        //        this.menuHandlerV.Update();

        //        this.Units.AddUnitImMap();
        //        this.Units.DrawUnit();
        //        this.Units.MoveUnit();
        //        // this.Units.ActivePlant();

        //        this.Buildings.DrawBuildings();
        //        this.ChoiceUnit.ChoiseUnitMenu();
        //        this.Buildings.BuildUnit();


        //        //debug
        //        this.ID = Units.ID;
        //        this.AP = Units.AP;



        //    }

        //    if (this.globalTrigger == 0 || this.globalTrigger == -1 || this.globalTrigger == -2)
        //    {
        //        this.menuHandlerV.Update();
        //    }


        //    cycleCalculate();

        //    // Mouse clicked notify
        //    mousePressed();

        //    if (globalTrigger > -1)
        //    {
        //        this.drawArrow.Drow();

        //    }

        //}

    }
}
