using ConsoleRpg.DongMin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg
{
    public class Field
    {


        public void MakeField(Position[] island1Pos,
            Position[] island2Pos, Position[] island3Pos,
            Position[] island4Pos, Position[] groundPos,
            Position[] trapPos, Position[] portalPos,
            Position[] meteoPos)
        {
            for (int i = 0; i < island1Pos.Length; i++)
            {
                Console.SetCursorPosition(island1Pos[i].x, island1Pos[i].y);
                for(int j=0;j< FieldObject.Instance().island1.Length; j++)
                {
                    Console.Write(FieldObject.Instance().island1[j]);
                    Console.SetCursorPosition(island1Pos[i].x, island1Pos[i].y + (j + 1));
                }
                
            }


        }
    }
}
