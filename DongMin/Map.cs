using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleRpg
{
    
    public class Map
    {
        public enum StageNum
        {
            stage1,
            stage2,
            stage3
        }
        Field[] field;
        const int fieldNum = 3;

        public void Initialize()
        {
            field = new Field[fieldNum];
            for (int i = 0; i < fieldNum; i++)
            {
                field[i] = new Field();
            }


        }

        void MakeMap()
        {
            //field[0].AddObjectPosition(Field)
        }

        public void Progress()
        {

        }

        public void Testmap()
        {


            field[0].AddObjectPosition(Field.ObjectName.Island2, new Position(60, 20), new Position(100, 15)
                , new Position(25, 10), new Position(0, 10));
            field[0].AddObjectPosition(Field.ObjectName.Island3, new Position(65, 10));
            field[0].AddObjectPosition(Field.ObjectName.Island4, new Position(20, 24));
            field[0].AddObjectPosition(Field.ObjectName.Portal, new Position(140, 27));
            field[0].AddObjectPosition(Field.ObjectName.Trap, new Position(120, 30), new Position(25, 10));
            field[0].AddObjectPosition(Field.ObjectName.Ground,
                new Position(0, 30), new Position(10, 30), new Position(20, 30)
                , new Position(30, 30), new Position(40, 30), new Position(50, 30)
                , new Position(60, 30), new Position(70, 30), new Position(80, 30), new Position(90, 30)
                , new Position(100, 30), new Position(110, 30), new Position(120, 30), new Position(130, 30)
                , new Position(140, 30));


            //field[0].AddObjectPosition(Field.ObjectName.Island1, new Position(0, 24), new Position(20, 24));

            //field[0].AddObjectPosition(Field.ObjectName.Island2, new Position(32, 10), new Position(0, 10),
            //    new Position(45, 20), new Position(115, 20));

            //field[0].AddObjectPosition(Field.ObjectName.Island3, new Position(80, 15));

            //field[0].AddObjectPosition(Field.ObjectName.Portal, new Position(140, 27), new Position(2, 7));


            //field[0].AddObjectPosition(Field.ObjectName.Trap, new Position(50, 30), new Position(110, 30));

            //field[0].AddObjectPosition(Field.ObjectName.Ground, new Position(0, 30), new Position(10, 30),
            //    new Position(20, 30), new Position(30, 30), new Position(40, 30), new Position(50, 30)
            //    , new Position(60, 30), new Position(70, 30), new Position(80, 30), new Position(90, 30)
            //    , new Position(100, 30), new Position(110, 30), new Position(120, 30), new Position(130, 30)
            //    , new Position(140, 30));




            //field[0].AddObjectPosition(Field.ObjectName.Island2, new Position(20, 23), new Position(59, 19));
            //field[0].AddObjectPosition(Field.ObjectName.Island1, new Position(100, 23));

            //field[0].AddObjectPosition(Field.ObjectName.Trap, new Position(40, 30), new Position(100, 30));
            //field[0].AddObjectPosition(Field.ObjectName.Portal, new Position(2, 27));
            //field[0].AddObjectPosition(Field.ObjectName.Ground, new Position(0, 30), new Position(10, 30),
            //    new Position(20, 30), new Position(30, 30), new Position(40, 30), new Position(50, 30)
            //    , new Position(60, 30), new Position(70, 30), new Position(80, 30), new Position(90, 30)
            //    , new Position(100, 30), new Position(110, 30), new Position(120, 30), new Position(130, 30)
            //    , new Position(140, 30));

            //field[0].AddObjectPosition(Field.ObjectName.Meteo, new Position(10, 0), new Position(30, 0));
            //20간격으로 x좌표 랜덤으로 2~3개정도 수직으로 떨어지게 하면될 것 같습니다. 

        }

        public void Render(StageNum stageNUm)
        {
            field[(int)stageNUm].MakeField();
        }

        public void Release()
        {

        }
    }
}
