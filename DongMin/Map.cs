using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG;

namespace ConsoleRpg
{
    
    public class Map
    {
        Field[] field;
        const int fieldNum = 3;
        //FieldObject fieldObject;


        public void Initialize()
        {
            field = new Field[fieldNum];
        }

        public void Progress()
        {

        }

        public void Render()
        {
            field[0].island1Pos = new List<Position>();
        }

        public void Release()
        {

        }
    }
}
