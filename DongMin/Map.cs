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
            field[0].AddObjectPosition(Field.ObjectName.Ground, new Position(0, 30), new Position(10, 30), new Position(20, 30));
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
