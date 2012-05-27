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
    class unitsUpdate
    {
        public Global global;
        //public Unit unit;
        public UnitAction Action;

        public unitsUpdate(Global global)
        {
            this.global = global;
            //unit = new Unit(global);
            Action = new UnitAction(global);
        }

        public void Update()
        {
            Action.ChoiceUnit();
            Action.MoveUnit();
            //Action.Attac();
        }
    }
}
