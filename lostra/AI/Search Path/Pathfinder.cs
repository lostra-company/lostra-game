using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

//Цена движения сюда от старта
// 
//  Примерная дистанция до конца изпользуя алгоритм Manhattan'а. 10 это разтояние между клетками
//  f = 10 * (Math.Abs(cell.X - goal.X) + Math.Abs(cell.Y - goal.Y));
// 
          
namespace lostra
{
    internal class Pathfinder
    {
        private Global global;

        private KeyboardState oldState;

        private int x;
        private int y;

        private int lastX;
        private int lastY;

        private int i = 0;

        private int nowX;
        private int nowY;

        private int[,] OpenList = new int[7, 2];
        private int[,] Closelist = new int[100, 2];

        private int F;
        

        private Vector2 vector2;

        public Pathfinder(Global global)
        {
            this.global = global;
        }

        public void SearchWays()
        {
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Q) && oldState.IsKeyUp(Keys.Q))
            {
                x = global.gameHandler.HoverCellIdX;
                y = global.gameHandler.HoverCellIdY;
                i = 1;
            }

            if (i == 1)
            {
                if (keyboard.IsKeyDown(Keys.Q) && oldState.IsKeyUp(Keys.Q))
                {
                    lastX = global.gameHandler.HoverCellIdX;
                    lastY = global.gameHandler.HoverCellIdY;
                    i = 2;
                }
            }

            if (i == 2)
            {
                if (nowY % 2 == 0)
                {

                    OpenList = new int[,] {   {nowX - 1, nowY},
                                            {nowX + 1, nowY - 1},
                                            {nowX + 1, nowY},
                                            {nowX, nowY - 1},
                                            {nowX + 1, nowY + 1},
                                            {nowX, nowY + 1}
                                                            };
                }

                if (nowY % 2 == 1)
                {
                    OpenList = new int[,] {   {nowX - 1, nowY},
                                            {nowX - 1, nowY - 1},
                                            {nowX, nowY + 1},
                                            {nowX, nowY - 1},
                                            {nowX + 1, nowY},
                                            {nowX - 1, nowY + 1}
                                                            };
                }
            }

            oldState = keyboard;
        }
    }
}
