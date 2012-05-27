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
    class mapShift
    {
        public Global global;
        public int lastMapX = 0;
        public int lastMapY = 0;
        public int shiftMapXOld = 0;
        public int shiftMapYOld = 0;
        // Максимальное, минимальное  смещение камеры
        public int maxMapShiftX = 0;
        public int maxMapShiftY = 0;
        public int minMapShiftX = 0;
        public int minMapShiftY = 0;
        // Обрезка карты по бокам
        public int prunX0 = 0;
        public int prunX1 = 24;
        public int prunY0 = -12;
        public int prunY1 = 12;
        // Размер ячейки карты в пикселях
        public int mapCellWidth = 48;
        public int mapCellHeightReal = 52;
        public int mapCellHeight = 40; // Гексельная высота
        public int mapCellHeightEx = 12;  // Дополнительная гексельная высота
        // Множитель смещение карты при передвижении
        public int mapShiftScale = 10;


        public mapShift(Global global)
        {
            this.global = global;
        }


        public void Update()
        {
   


            int scale = mapShiftScale;
            // За пределы экрана
            if (Mouse.GetState().Y < 1) updateShiftY(1 * scale);
            if (Mouse.GetState().Y > global.windowHeight - 1) updateShiftY(-1 * scale);
            if (Mouse.GetState().X < 1) updateShiftX(1 * scale);
            if (Mouse.GetState().X > global.windowWidth - 1) updateShiftX(-1 * scale);
            // По щелчку и перемещению
            if (Mouse.GetState().RightButton == ButtonState.Released)
            {
                this.lastMapX = Mouse.GetState().X;
                this.lastMapY = Mouse.GetState().Y;
                this.shiftMapXOld = global.gameHandler.shiftMapX;
                this.shiftMapYOld = global.gameHandler.shiftMapY;
            }
            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                global.gameHandler.shiftMapY = this.shiftMapYOld - (this.lastMapY - Mouse.GetState().Y);
                global.gameHandler.shiftMapX = this.shiftMapXOld - (this.lastMapX - Mouse.GetState().X);
            }
            this.cheakMaxMinShift();







            maxMapShiftX = -1 * (global.resources.listLevels[global.gameHandler.levelKey].matrix.GetLength(1) * mapCellWidth - global.windowWidth) + prunX1;
            maxMapShiftY = -1 * (global.resources.listLevels[global.gameHandler.levelKey].matrix.GetLength(0) * mapCellHeight - global.windowHeight) - mapCellHeightEx + prunY1;
            minMapShiftX = 0 + prunX0;
            minMapShiftY = 0 + prunY0;

        }


        public void updateShiftX(int value)
        {
            global.gameHandler.shiftMapX = global.gameHandler.shiftMapX + value;
        }
        public void updateShiftY(int value)
        {
            global.gameHandler.shiftMapY = global.gameHandler.shiftMapY + value;
        }
        public void cheakMaxMinShift()
        {
            if (global.gameHandler.shiftMapX < this.maxMapShiftX)
                global.gameHandler.shiftMapX = this.maxMapShiftX;

            if (global.gameHandler.shiftMapY < this.maxMapShiftY)
                global.gameHandler.shiftMapY = this.maxMapShiftY;

            if (global.gameHandler.shiftMapX > this.minMapShiftX)
                global.gameHandler.shiftMapX = this.minMapShiftX;

            if (global.gameHandler.shiftMapY > this.minMapShiftY)
                global.gameHandler.shiftMapY = this.minMapShiftY;

        }
    }
}
