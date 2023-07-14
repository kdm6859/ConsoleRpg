using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
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
    }
}
