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

        string[] island1 =
        {
            "┏━━━━━━━━━━━━━━━━━┓",
            "┃/////////////////┃",
            "┗━━━━━━━━━━━━━━━━━┛"
        };

        string[] island2 =
        {
            "┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓",
            "┃//////////////////////////////┃",
            "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛"
        };

        string[] island3 =
        {
            "┏━━━━━━━━━━━━━━┓",
            "┃//////////////┗━━━━━━━━━━━━━━━┓",
            "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛"
        };

        string[] island4 =
        {
            "                ┏━━━━━━━━━━━━━━┓",
            "┏━━━━━━━━━━━━━━━┛//////////////┃",
            "┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛"
        };

        string[] ground =
        {
            "━━━━━━━━━━"
        };

        string[] trap =
        {
            "┃        ┃",
            "┗▲▲▲▲┛"
        };

        string[] portal =
        {
            "▒▒▒▒▒",
            "▒▒▒▒▒",
            "▒▒▒▒▒"
        };

        string[] meteo =
        {
            "♨"
        };

        public string[] Island1
        {
            get { return island1; }
        }

        public string[] Island2
        {
            get { return island2; }
        }

        public string[] Island3
        {
            get { return island3; }
        }

        public string[] Island4
        {
            get { return island4; }
        }

        public string[] Ground
        {
            get { return ground; }
        }

        public string[] Trap
        {
            get { return trap; }
        }

        public string[] Portal
        {
            get { return portal; }
        }

        public string[] Meteo
        {
            get { return meteo; }
        }
    }
}
