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
        public List<SensingArea> island1Pos = null;
        public List<SensingArea> island2Pos = null;
        public List<SensingArea> island3Pos = null;
        public List<SensingArea> island4Pos = null;
        public List<SensingArea> groundPos = null;
        public List<SensingArea> trapPos = null;
        public List<SensingArea> portalPos = null;
        public List<SensingArea> meteoPos = null;

        //public void AddObjectPosition(ObjectName objectName, int x, int y)
        //{
        //    switch(objectName)
        //    {
        //        case ObjectName.Island1:
        //            if (island1Pos == null)
        //                island1Pos = new List<Position>();
        //            island1Pos.Add(new Position(x, y));
        //            break;
        //        case ObjectName.Island2:
        //            if (island2Pos == null)
        //                island2Pos = new List<Position>();
        //            island2Pos.Add(new Position(x, y));
        //            break;
        //        case ObjectName.Island3:
        //            if (island3Pos == null)
        //                island3Pos = new List<Position>();
        //            island3Pos.Add(new Position(x, y));
        //            break;
        //        case ObjectName.Island4:
        //            if (island4Pos == null)
        //                island4Pos = new List<Position>();
        //            island4Pos.Add(new Position(x, y));
        //            break;
        //        case ObjectName.Ground:
        //            if (groundPos == null)
        //                groundPos = new List<Position>();
        //            groundPos.Add(new Position(x, y));
        //            break;
        //        case ObjectName.Trap:
        //            if (trapPos == null)
        //                trapPos = new List<Position>();
        //            trapPos.Add(new Position(x, y));
        //            break;
        //        case ObjectName.Portal:
        //            if (portalPos == null)
        //                portalPos = new List<Position>();
        //            portalPos.Add(new Position(x, y));
        //            break;
        //        case ObjectName.Meteo:
        //            if (meteoPos == null)
        //                meteoPos = new List<Position>();
        //            meteoPos.Add(new Position(x, y));
        //            break;
        //    }
        //}

        public void AddObjectPosition(ObjectName objectName, params Position[] pos)
        {
            int[] width;
            int[] height;

            switch (objectName)
            {
                case ObjectName.Island1:
                    if (island1Pos == null)
                        island1Pos = new List<SensingArea>();
                    width = new int[1];
                    height = new int[1];
                    width[0] = 19;
                    height[0] = 3;     
                    for (int i = 0; i < pos.Length; i++)
                    {
                        island1Pos.Add(new SensingArea(width, height, 
                            new Position[] { pos[i] }));
                    }
                    break;

                case ObjectName.Island2:
                    if (island2Pos == null)
                        island2Pos = new List<SensingArea>();
                    width = new int[1];
                    height = new int[1];
                    width[0] = 32;
                    height[0] = 3;
                    for (int i = 0; i < pos.Length; i++)
                    {
                        island2Pos.Add(new SensingArea(width, height, 
                            new Position[] { pos[i] }));
                    } 
                    break;

                case ObjectName.Island3:
                    if (island3Pos == null)
                        island3Pos = new List<SensingArea>();
                    width = new int[2];
                    height = new int[2];
                    width[0] = 16;
                    height[0] = 3;
                    width[1] = 16;
                    height[1] = 2;
                    for (int i = 0; i < pos.Length; i++)
                    {
                        island3Pos.Add(new SensingArea(new int[2] { 16, 16 }, height,
                            new Position[] { pos[i], new Position(pos[i].x + 16, pos[i].y + 1) }));
                    }
                    break;

                case ObjectName.Island4:
                    if (island4Pos == null)
                        island4Pos = new List<SensingArea>();
                    width = new int[2];
                    height = new int[2];
                    width[0] = 16;
                    height[0] = 2;
                    width[1] = 16;
                    height[1] = 3;
                    for (int i = 0; i < pos.Length; i++)
                    {
                        island4Pos.Add(new SensingArea(width, height,
                            new Position[] { pos[i], new Position(pos[i].x + 16, pos[i].y - 1) }));
                    }
                    break;

                case ObjectName.Ground:
                    if (groundPos == null)
                        groundPos = new List<SensingArea>();
                    width = new int[1];
                    height = new int[1];
                    width[0] = 10;
                    height[0] = 1;
                    for (int i = 0; i < pos.Length; i++)
                    {
                        groundPos.Add(new SensingArea(width, height,
                            new Position[] { pos[i] }));
                    }
                    break;

                case ObjectName.Trap:
                    if (trapPos == null)
                        trapPos = new List<SensingArea>();
                    width = new int[3];
                    height = new int[3];
                    width[0] = 1;
                    height[0] = 2;
                    width[1] = 9;
                    height[1] = 1;
                    width[2] = 1;
                    height[2] = 2;
                    for (int i = 0; i < pos.Length; i++)
                    {
                        trapPos.Add(new SensingArea(width, height,
                            new Position[] { pos[i], new Position(pos[i].x + 1, pos[i].y + 1),
                            new Position(pos[i].x+9,pos[i].y)}));
                    }
                    break;

                case ObjectName.Portal:
                    if (portalPos == null)
                        portalPos = new List<SensingArea>();
                    width = new int[1];
                    height = new int[1];
                    width[0] = 5;
                    height[0] = 3;
                    for (int i = 0; i < pos.Length; i++)
                    {
                        portalPos.Add(new SensingArea(width, height,
                            new Position[] { pos[i] }));
                    }
                    break;

                case ObjectName.Meteo:
                    if (meteoPos == null)
                        meteoPos = new List<SensingArea>();
                    width = new int[1];
                    height = new int[1];
                    width[0] = 1;
                    height[0] = 1;
                    for (int i = 0; i < pos.Length; i++)
                    {
                        meteoPos.Add(new SensingArea(width, height, 
                            new Position[] { pos[i] }));
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
                    MakeFieldObject(FieldObject.Instance().Island1,
                        island1Pos[i].positions[0].x, island1Pos[i].positions[0].y);
                }
            }

            if (island2Pos != null)
            {
                //island2오브젝트 배치
                for (int i = 0; i < island2Pos.Count; i++)
                {
                    MakeFieldObject(FieldObject.Instance().Island2, 
                        island2Pos[i].positions[0].x, island2Pos[i].positions[0].y);
                }
            }

            if (island3Pos != null)
            {
                //island3오브젝트 배치
                for (int i = 0; i < island3Pos.Count; i++)
                {
                    MakeFieldObject(FieldObject.Instance().Island3, 
                        island3Pos[i].positions[0].x, island3Pos[i].positions[0].y);
                }
            }

            if (island4Pos != null)
            {
                //island4오브젝트 배치
                for (int i = 0; i < island4Pos.Count; i++)
                {
                    MakeFieldObject(FieldObject.Instance().Island4, 
                        island4Pos[i].positions[0].x, island4Pos[i].positions[0].y);
                }
            }

            if (groundPos != null)
            {
                //ground오브젝트 배치
                for (int i = 0; i < groundPos.Count; i++)
                {
                    MakeFieldObject(FieldObject.Instance().Ground, 
                        groundPos[i].positions[0].x, groundPos[i].positions[0].y);
                }
            }
            
            if(trapPos != null)
            {
                //trap오브젝트 배치
                for (int i = 0; i < trapPos.Count; i++)
                {
                    MakeFieldObject(FieldObject.Instance().Trap, 
                        trapPos[i].positions[0].x, trapPos[i].positions[0].y);
                }
            }
            
            if(portalPos != null)
            {
                //portal오브젝트 배치
                for (int i = 0; i < portalPos.Count; i++)
                {
                    MakeFieldObject(FieldObject.Instance().Portal, 
                        portalPos[i].positions[0].x, portalPos[i].positions[0].y);
                }
            }
            
            if(meteoPos != null)
            {
                //meteo오브젝트 배치
                for (int i = 0; i < meteoPos.Count; i++)
                {
                    MakeFieldObject(FieldObject.Instance().Meteo, 
                        meteoPos[i].positions[0].x, meteoPos[i].positions[0].y);
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
