using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg
{
    public class Info
    {
        string name;
        int attack;
        int hp;
        int speed;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }
        public int HP
        {
            get { return hp; }
            set { hp = value; }
        }
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
    }
}
