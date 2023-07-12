using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg
{
    public class FieldObject
    {
        public static FieldObject instance;
        public static FieldObject Instance()
        {
            if (instance == null)
            {
                instance = new FieldObject();
            }
            return instance;
        }

        public string[] island1 =
        {
            "┏━━━━━━━━━━━━━━━━━┓",
            "┃                 ┃",
            "┗━━━━━━━━━━━━━━━━━┛"
        };

        public string[] island2 =
        {
            "┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓",
            "┃                              ┃",
            "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛"
        };

        public string[] island3 =
        {
            "┏━━━━━━━━━━━━━━┓",
            "┃              ┗━━━━━━━━━━━━━━━┓",
            "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛"
        };

        public string[] island4 =
        {
            "                ┏━━━━━━━━━━━━━━┓",
            "┏━━━━━━━━━━━━━━━┛              ┃",
            "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛"
        };

        public string[] ground =
        {
            "━━━━━━━━━━"
        };

        public string[] trap =
        {
            "┃        ┃",
            "┗▲▲▲▲┛"
        };

        public string[] portal =
        {
            "▒▒▒▒▒",
            "▒▒▒▒▒",
            "▒▒▒▒▒"
        };

        public string[] meteo =
        {
            "♨"
        };

    }
}
