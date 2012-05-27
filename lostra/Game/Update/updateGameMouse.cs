using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lostra
{
    // Поведение мышки
    class updateGameMouse
    {
        public Global global;
        public updateGameMouse(Global global)
        {
            this.global = global;
        }

        public void Update()
        {
            // Триггер показывает что не выделенны не здания, ни юниты ни ресурсы и тд
            bool trigger = true;
            // Проверяем что выделенно

            // Проверяем все здания
            foreach (Building b in global.gameHandler.GameData.dataBuildings.Values)
            {
                if (b.Check()) trigger = false;
            }

            // Проверяем все юниты
            foreach (Unit u in global.gameHandler.GameData.dataUnits.Values)
            {
                if (u.Check()) trigger = false;
            }

            // Предаем триггер
            global.gameHandler.isCellHovered = trigger;
        }
    }
}
