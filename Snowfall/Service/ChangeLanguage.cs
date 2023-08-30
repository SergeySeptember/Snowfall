using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowfall.Service
{
    public static class ChangeLanguage
    {
        public static Dictionary<string, string> languagesRus = new()
        {
            {"Change Language","Смена языка"},
            {"Todo List", "Список дел" },
            {"Notes", "Заметки"},
            {"Settings", "Настройки" },
            {"Change color", "Сменить цвет" },
            {"Show all tasks","Показать все задачи" },
            {"Show completed tasks","Показать выполненые задачи" },
            {"Show pending tasks","Показать невыполненые задачи" }
        };

        public static Dictionary<string, string> languagesEng = new()
        {
            {"Change Language","Change Language"},
            {"Todo List", "Todo List" },
            {"Notes", "Notes"},
            {"Settings", "Settings" },
            {"Change color", "Change color" },
            {"Show all tasks","Show all tasks" },
            {"Show completed tasks","Show completed tasks" },
            {"Show pending tasks","Show pending tasks" }
        };
    }
}
