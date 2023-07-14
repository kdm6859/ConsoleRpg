using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg
{
    public class ObjectManager
    {
        public static ObjectManager instance;
        public static ObjectManager Instance()
        {
            if (instance == null)
            {
                instance = new ObjectManager();
            }
            return instance;
        }

        Player player = null;
        Monster monster = null;
        Map map = null;

        public bool isLanding = true;
        public bool isTrap = false;
        public bool isPortal = false;
        public bool stageUpDown = false;
        //public Position currPortalArea = null;

        //SensingArea playerArea = null;
        //SensingArea playerShortSkill = null;
        //SensingArea monsterArea = null;
        //List<SensingArea> island1Area = null;
        //List<SensingArea> island2Area = null;
        //List<SensingArea> island3Area = null;
        //List<SensingArea> island4Area = null;
        //List<SensingArea> groundArea = null;
        //List<SensingArea> trapArea = null;
        //List<SensingArea> portalArea = null;
        //List<SensingArea> meteoArea = null;

        //public void Initialize(ref SensingArea playerArea,
        //    ref SensingArea playerShortSkill,ref SensingArea monsterArea,
        //    ref SensingArea fieldObject)
        //{
        //    this.playerArea = playerArea;
        //    this.playerShortSkill = playerShortSkill;
        //    this.monsterArea = monsterArea;


        //}

        public void Initialize(ref Player player, ref Monster monster, ref Map map)
        {
            this.player = player;
            this.monster = monster;
            this.map = map;
        }

        public void Progress()
        {
            int playerX = player.playerArea.positions[0].x + 2;
            int playerY = player.playerArea.positions[0].y + 3;

            //if (!isLanding)
            //{
            //    PlayerLandState(playerX, playerY);
            //}
            isLanding = PlayerLandState(playerX, playerY);
            isTrap = PlayerTrapState(map.field[(int)map.currentStageNum].trapPos, playerX, playerY);
            isPortal = PlayerPortalState(map.field[(int)map.currentStageNum].portalPos, playerX, playerY);

        }

        bool PlayerLandState(int playerX, int playerY)
        {
            if (PlayerObjectLandState(map.field[(int)map.currentStageNum].island1Pos, playerX, playerY) ||
                PlayerObjectLandState(map.field[(int)map.currentStageNum].island2Pos, playerX, playerY) ||
                PlayerObjectLandState(map.field[(int)map.currentStageNum].island3Pos, playerX, playerY) ||
                PlayerObjectLandState(map.field[(int)map.currentStageNum].island4Pos, playerX, playerY) ||
                PlayerObjectLandState(map.field[(int)map.currentStageNum].groundPos, playerX, playerY) ||
                PlayerObjectLandState(map.field[(int)map.currentStageNum].trapPos, playerX, playerY))
                return true;
            else
                return false;
                
        }

        bool PlayerObjectLandState(List<SensingArea> objectFieldArea, int playerX, int playerY)
        {
            if (objectFieldArea == null)
                return false;

            for(int i = 0; i < objectFieldArea.Count; i++)
            {
                for (int j = 0; j < objectFieldArea[i].positions.Length; j++)
                {
                    if (objectFieldArea[i].positions[j].x <= playerX &&
                        objectFieldArea[i].positions[j].x + objectFieldArea[i].width[j] > playerX &&
                        objectFieldArea[i].positions[j].y == playerY)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        bool PlayerTrapState(List<SensingArea> trapObjectArea, int playerX, int playerY)
        {
            if (trapObjectArea == null)
                return false;

            for (int i = 0; i < trapObjectArea.Count; i++)
            {
                for (int j = 0; j < trapObjectArea[i].positions.Length; j++)
                {
                    if (trapObjectArea[i].positions[j].x <= playerX &&
                        trapObjectArea[i].positions[j].x + trapObjectArea[i].width[j] > playerX &&
                        trapObjectArea[i].positions[j].y == playerY)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        bool PlayerPortalState(List<SensingArea> portalObjectArea, int playerX, int playerY)
        {
            if (portalObjectArea == null)
                return false;

            for (int i = 0; i < portalObjectArea.Count; i++)
            {
                for (int j = 0; j < portalObjectArea[i].positions.Length; j++)
                {
                    if (portalObjectArea[i].positions[j].x <= playerX &&
                        portalObjectArea[i].positions[j].x + portalObjectArea[i].width[j] > playerX &&
                        portalObjectArea[i].positions[j].y + portalObjectArea[i].height[j] == playerY)
                    {
                        if (portalObjectArea[i].positions[j].x < 75)
                        {
                            stageUpDown = false;
                            //currPortalArea = map.field[(int)map.currentStageNum].portalPos[1].positions[0];
                        }
                        else
                        {
                            stageUpDown = true;
                            //currPortalArea = map.field[(int)map.currentStageNum].portalPos[0].positions[0];
                        }
                        
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
