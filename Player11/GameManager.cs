using ConsoleRpg;
using ConsoleRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleRpg.Map;

namespace ConsoleRPG
{
    internal class GameManager
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
        Monster mon = null;
        Skill skill = null;
        
        public Player GetPlayer() { return player; }
        public void Initialize()
        {
            map = new Map();
            skill = new Skill();
            player = new Player();

            map.Initialize();
            player.Initailize();
            

            mon  = new Monster("Monster",40,28, Monster.monsterStr, 1);
        
        }
        public void Progress()
        {
            INVENPANEL.Instance().KeySensing();
            KeyControlManager.Instance().KeyControl();
            player.Progress();
            mon.Progress(player);

        }
        public void Render()
        {
            //Console.Clear();

            Console.WriteLine("플레이어 dir :" + player.getSkill().dir);
            //Console.WriteLine("이즈엑티브 :" + player.getSkill().isActive);
            //Console.WriteLine("스킬 x좌표 : " + player.getSkill().SkillX);


            map.Render(0);

            INVENPANEL.Instance().OpenInventory();
            INVENPANEL.Instance().DisplayInfoPanel();
            INVENPANEL.Instance().UseHPotion();
            INVENPANEL.Instance().UseMPotion();

            player.Render();
            mon.Render();
            //mon.PrintLocation();
            
            
        }
            
    }
    
}


