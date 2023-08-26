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
            {"L/D Theme","Светлая/тёмная тема"},
            {"Change Language","Смена языка"}
        };

        public static Dictionary<string, string> languagesEng = new()
        {
            {"L/D Theme","Light/Dark Theme"},
            {"Change Language","Смена языка"}
        };
    }
}
