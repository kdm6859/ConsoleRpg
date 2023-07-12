using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg
{
    public class Field
    {
        public enum ObjectName
        {
            Island1,
            Island2, 
            Island3, 
            Island4,
            Ground,
            Trap,
            Portal,
            Meteo
        }
        public List<Position> island1Pos = null;
        public List<Position> island2Pos = null;
        public List<Position> island3Pos = null;
        public List<Position> island4Pos = null;
        public List<Position> groundPos = null;
        public List<Position> trapPos = null;
        public List<Position> portalPos = null;
        public List<Position> meteoPos = null;

        public void AddObjectPosition(ObjectName objectName, int x, int y)
        {
            switch(objectName)
            {
                case ObjectName.Island1:
                    if (island1Pos == null)
                        island1Pos = new List<Position>();
                    island1Pos.Add(new Position(x, y));
                    break;
                case ObjectName.Island2:
                    if (island2Pos == null)
                        island2Pos = new List<Position>();
                    island2Pos.Add(new Position(x, y));
                    break;
                case ObjectName.Island3:
                    if (island3Pos == null)
                        island3Pos = new List<Position>();
                    island3Pos.Add(new Position(x, y));
                    break;
                case ObjectName.Island4:
                    if (island4Pos == null)
                        island4Pos = new List<Position>();
                    island4Pos.Add(new Position(x, y));
                    break;
                case ObjectName.Ground:
                    if (groundPos == null)
                        groundPos = new List<Position>();
                    groundPos.Add(new Position(x, y));
                    break;
                case ObjectName.Trap:
                    if (trapPos == null)
                        trapPos = new List<Position>();
                    trapPos.Add(new Position(x, y));
                    break;
                case ObjectName.Portal:
                    if (portalPos == null)
                        portalPos = new List<Position>();
                    portalPos.Add(new Position(x, y));
                    break;
                case ObjectName.Meteo:
                    if (meteoPos == null)
                        meteoPos = new List<Position>();
                    meteoPos.Add(new Position(x, y));
                    break;
            }
        }

        public void AddObjectPosition(ObjectName objectName, params Position[] pos)
        {
            switch (objectName)
            {
                case ObjectName.Island1:
                    if (island1Pos == null)
                        island1Pos = new List<Position>();
                    for(int i = 0; i < pos.Length; i++)
                    {
                        island1Pos.Add(pos[i]);
                    }
                    break;
                case ObjectName.Island2:
                    if (island2Pos == null)
                        island2Pos = new List<Position>();
                    for (int i = 0; i < pos.Length; i++)
                    {
                        island2Pos.Add(pos[i]);
                    } 
                    break;
                case ObjectName.Island3:
                    if (island3Pos == null)
                        island3Pos = new List<Position>();
                    for (int i = 0; i < pos.Length; i++)
                    {
                        island3Pos.Add(pos[i]);
                    }
                    break;
                case ObjectName.Island4:
                    if (island4Pos == null)
                        island4Pos = new List<Position>();
                    for (int i = 0; i < pos.Length; i++)
                    {
                        island4Pos.Add(pos[i]);
                    }
                    break;
                case ObjectName.Ground:
                    if (groundPos == null)
                        groundPos = new List<Position>();
                    for (int i = 0; i < pos.Length; i++)
                    {
                        groundPos.Add(pos[i]);
                    }
                    break;
                case ObjectName.Trap:
                    if (trapPos == null)
                        trapPos = new List<Position>();
                    for (int i = 0; i < pos.Length; i++)
                    {
                        trapPos.Add(pos[i]);
                    }
                    break;
                case ObjectName.Portal:
                    if (portalPos == null)
                        portalPos = new List<Position>();
                    for (int i = 0; i < pos.Length; i++)
                    {
                        portalPos.Add(pos[i]);
                    }
                    break;
                case ObjectName.Meteo:
                    if (meteoPos == null)
                        meteoPos = new List<Position>();
                    for (int i = 0; i < pos.Length; i++)
                    {
                        meteoPos.Add(pos[i]);
                    }
                    break;
            }
        }


        //전체 필드를 그려주는 함수
        //public void MakeField(List<Position> island1Pos = null,
        //    List<Position> island2Pos = null, List<Position> island3Pos = null,
        //    List<Position> island4Pos = null, List<Position> groundPos = null,
        //    List<Position> trapPos = null, List<Position> portalPos = null,
        //    List<Position> meteoPos = null)
        public void MakeField()
        {
            if (island1Pos != null)
            {
                //island1오브젝트 배치
                for (int i = 0; i < island1Pos.Count; i++)
                {
                    MakeFieldObject(FieldObject.Instance().island1, island1Pos[i].x, island1Pos[i].y);
                }
            }

            if (island2Pos != null)
            {
                //island2오브젝트 배치
                for (int i = 0; i < island2Pos.Count; i++)
                {
                    MakeFieldObject(FieldObject.Instance().island2, island2Pos[i].x, island2Pos[i].y);
                }
            }

            if (island3Pos != null)
            {
                //island3오브젝트 배치
                for (int i = 0; i < island3Pos.Count; i++)
                {
                    MakeFieldObject(FieldObject.Instance().island3, island3Pos[i].x, island3Pos[i].y);
                }
            }

            if (island4Pos != null)
            {
                //island4오브젝트 배치
                for (int i = 0; i < island4Pos.Count; i++)
                {
                    MakeFieldObject(FieldObject.Instance().island4, island4Pos[i].x, island4Pos[i].y);
                }
            }

            if (groundPos != null)
            {
                //ground오브젝트 배치
                for (int i = 0; i < groundPos.Count; i++)
                {
                    MakeFieldObject(FieldObject.Instance().ground, groundPos[i].x, groundPos[i].y);
                }
            }
            
            if(trapPos != null)
            {
                //trap오브젝트 배치
                for (int i = 0; i < trapPos.Count; i++)
                {
                    MakeFieldObject(FieldObject.Instance().trap, trapPos[i].x, trapPos[i].y);
                }
            }
            
            if(portalPos != null)
            {
                //portal오브젝트 배치
                for (int i = 0; i < portalPos.Count; i++)
                {
                    MakeFieldObject(FieldObject.Instance().portal, portalPos[i].x, portalPos[i].y);
                }
            }
            
            if(meteoPos != null)
            {
                //meteo오브젝트 배치
                for (int i = 0; i < meteoPos.Count; i++)
                {
                    MakeFieldObject(FieldObject.Instance().meteo, meteoPos[i].x, meteoPos[i].y);
                }
            }
            
        }

        //필드 오브젝트 그려주는 함수
        public void MakeFieldObject(string[] Object, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            for (int j = 0; j < Object.Length; j++)
            {
                Console.Write(Object[j]);
                Console.SetCursorPosition(x, y + (j + 1));
            }
        }
    }
}
