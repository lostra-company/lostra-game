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
    //  ОБрисовка всего что есть
    class gameDraw
    {
        public Global global;
        // Буфер класса
        public string bufferTexture = "";
        // Верхник фрем ресурсов
        public drawMenuTopFrame drawMenuTopFrame;
        // Здания рисум 
        public drawBuildings drawBuildings;
        // Юнитов
        public drawUnits drawUnits;
        // Карту
        public drawMap drawMap;
        // Выделенные ячейки
        public drawCellHover drawCellHover;
        public DrawActionMenu DrawActionMenu;

        public gameDraw(Global global)
        {
            this.global = global;

            // Ласки
            this.drawMenuTopFrame = new drawMenuTopFrame(global);
            this.drawBuildings = new drawBuildings(global);
            this.drawUnits = new drawUnits(global);
            this.drawMap = new drawMap(global);
            this.drawCellHover = new drawCellHover(global);
            this.DrawActionMenu = new DrawActionMenu(global);
        }



        public void Draw()
        {
            global.spriteBatch.Begin();



            // Draw map img
            drawMap.Draw();


            // Draw Hovered cells
            drawCellHover.Draw();

            // Draw Buildings
            drawBuildings.Draw();
            // Юниты
            drawUnits.Draw();

            // Draw Menu
            drawMenuTopFrame.Draw();
            //DrawActionMenu.Draw();




            global.spriteBatch.End(); 
        }

    }
}
