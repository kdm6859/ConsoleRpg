using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            map.Initialize();
            player.Initailize();
        }

        public void Progress()
        {
            KeyControlManager.Instance().KeyControl();
            map.Progress();

            player.Progress();
            
        }

        public void Render(Map.StageNum stageNUm)
        {
            Console.Clear();
            map.Render(stageNUm);
            player.Render();
        }


        public void Release()
        {

        }
    }
}
