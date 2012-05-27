using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lostra
{
    // Самый главный
    class gameHandler
    {
        public Global global;
        // База данных
        public gameData GameData;
        // Цикл
        public gameUpdate GameUpdate;
        // Рисуем
        public gameDraw GameDraw;
        // Обработчик коориднат
        public mapCalc MapCalc;
        // Менюшки
        public gameMenu gameMenu;




        // Смещение карты 
        public int shiftMapX = 0;
        public int shiftMapY = 0;
        // Выделенные ячейки
        public bool isCellHovered = false;
        public int HoverCellIdX = -1;
        public int HoverCellIdY = -1;
        // Ключ карты
        public string levelKey = "01";
        // Уже играем?
        public bool started = false;

        public gameHandler(Global global)
        {
            // Предварительные ласки
            this.global = global;

            this.GameDraw = new gameDraw(global);
            this.GameUpdate = new gameUpdate(global);
            this.MapCalc = new mapCalc(global);
            this.gameMenu = new gameMenu(global);
        }



        public void Start(string uin)
        {
            // Поехали
            this.GameData = new gameData(global);
            global.globalTrigger = 1;
            global.bufferTrigger = 1;
            this.started = true;


        }

        public void Clean()
        {
            // Читстим за собой если игра закончена
            this.started = false;
        }

        public void Update()
        {
            // Циклим
            if (this.started)
            {
                GameUpdate.Update();
                GameDraw.Draw();
                gameMenu.Update();
            }

        }



    }
}
