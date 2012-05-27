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
    class UnitAction
    {
        public Global global;

        public Player Player;
        public dataGecs Gecs;
        public Unit Unit;

        //проверка, можем ли мы двигать юнит
        public bool isCanMove = false;
       

        private MouseState oldState;
        private MouseState oldState1;
        
        public KeyboardState KeyboardState;
        public KeyboardState OldState;

        public bool AttackPermitted;

        public bool MoveStop = false;

        public int ForCounts;

        public UnitAction(Global global)
        {
            this.global = global;
            Unit = new Unit(global,0,0,0,null);
        }

        public void ChoiceUnit()
        {
            MouseState m = Mouse.GetState();
            //if (global.mouseHandler.Check()) <--странно себя ведет <_<
            //if (!isCanMove)
            //{
                if (m.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
                {
                    foreach (var units in global.gameHandler.GameData.dataUnits.Values)
                    {
                        if (global.gameHandler.HoverCellIdX == units.uX &&
                            global.gameHandler.HoverCellIdY == units.uY)
                        {
                            Unit.owner = 0;
                            Unit.uX = units.uX;
                            Unit.uY = units.uY;
                            Unit.mask = units.mask;
                            //isCanMove = true;
                        }
                    }
                }
            //}

            oldState = m;
        }

        public void MoveUnit()
        {
            MouseState m = Mouse.GetState();

            //if (isCanMove)
            //{
                //if (global.mouseHandler.Check())
                if (m.LeftButton == ButtonState.Pressed && oldState1.LeftButton == ButtonState.Released)
                {
                    //if (global.gameHandler.HoverCellIdX != Unit.uX && global.gameHandler.HoverCellIdY != Unit.uY)
                    //{
                        foreach (var unit in global.gameHandler.GameData.dataUnits)
                        {
                            if (Unit.uX == unit.Value.uX && Unit.uY == unit.Value.uY)
                            {
                                Unit.uX = global.gameHandler.HoverCellIdX;
                                Unit.uY = global.gameHandler.HoverCellIdY;
                                unit.Value.uX = Unit.uX;
                                unit.Value.uY = Unit.uY;
                                //isCanMove = false;
                            }
                        }
                    //}
                }
            //}
            oldState1 = m;
        }


        /// <summary>
        /// Метод, вызываем для атаки, натягиваем на событие
        /// </summary>
        /// <param name="uX">координаты юнита х</param>
        /// <param name="uY">коорлдинаты юнита у</param>
        /// <param name="tX">координаты цели х</param>
        /// <param name="tY">координаты цели у</param>
        public void Attac(/*int uX, int uY, int tX, int tY*/)
        {
            int AttacPoint = 0;
            dataGecs dataGecs;

            //тест
            int bx = 0;
            int by = 0;

            KeyboardState = Keyboard.GetState();

           
            if (KeyboardState.IsKeyDown(Keys.A))
            {
                foreach (var units in global.gameHandler.GameData.dataUnits)
                {
                    if (units.Key == ForCounts)
                    {
                        bx = units.Value.uX;
                        by = units.Value.uY;
                        AttacPoint = units.Value.mask.atackPoint;
                    }

                    dataGecs = new dataGecs(bx, by);

                    foreach (var c2 in dataGecs.c1)
                    {
                        if (units.Value.uX != bx && units.Value.uY != by)
                        {
                            if (units.Value.uX == c2.X && units.Value.uY == c2.Y)
                            {
                                units.Value.mask.hitPoint -= AttacPoint;
                            }
                        }
                    }
                }

            }

            OldState = KeyboardState;
        }

        /// <summary>
        /// Метод, вызываем для атаки >>>БАЗЫ!, натягиваем на событие
        /// </summary>
        /// <param name="uX">координаты юнита х</param>
        /// <param name="uY">координаты юнита у</param>
        /// <param name="tX">координаты базы х</param>
        /// <param name="tY">координаты базы у</param>
        public void AttacBase(int uX, int uY, int tX, int tY)
        {
            int AttacPoint = 0;

            foreach (var units in global.gameHandler.GameData.dataUnits)
            {
                if (units.Value.uX == uX && units.Value.uY == uY)
                {
                    AttacPoint = units.Value.mask.atackPoint;
                }
            }

            foreach (var building in global.gameHandler.GameData.dataBuildings)
            {
                if (building.Value.bX == tX && building.Value.bY == tY)
                {
                    building.Value.HitPoint -= AttacPoint;
                }
            }

        }
    }
}
