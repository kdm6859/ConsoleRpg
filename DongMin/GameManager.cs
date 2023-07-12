using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG;

namespace ConsoleRpg
{
    public class GameManager
    {
        public static GameManager instance;
        public static GameManager Instance()
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }

        Map map = null;
        Player player = null;
        


        public void Initialize()
        {
            map = new Map();
            player = new Player();

            //map.Initialize();
            player.Initailize();
            
        }

        public void Progress()
        {
            
        }

        public void Render(Map.StageNum stageNUm)
        {
            map.Render(stageNUm);
        }

        public void Release()
        {
            
        }
    }
}
