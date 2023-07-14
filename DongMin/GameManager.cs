using ConsoleRpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg
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
        ShortSkill shortskill = null;
        
        public Player GetPlayer() { return player; }
        public Monster GetMonster() { return mon;}
        public void Initialize()
        {
            map = new Map();
            skill = new Skill();
            player = new Player();
            shortskill = new ShortSkill(player, skill);
            
            map.Initialize();
            player.Initailize(ref map);

            if (map.currentStageNum == Map.StageNum.stage1)
            {
                mon = new Monster("Monster", 40, 28, Monster.monsterStr, 1, 500);
            }
            

            ObjectManager.Instance().Initialize(ref player, ref mon, ref map);


        }
        public void Progress()
        {
            INVENPANEL.Instance().KeySensing();
            KeyControlManager.Instance().KeyControl();
            player.Progress(mon);
            mon.Progress(player);

            ObjectManager.Instance().Progress();

        }
        public void Render()
        {
            Console.Clear();

            //Console.SetCursorPosition(3, 3);
            //Console.Write("isLanding = " + ObjectManager.Instance().isLanding);
            //Console.Write("asd = " + player.asd);
            //Console.WriteLine("플레이어 dir :" + player.getSkill().dir);
            //Console.WriteLine("이즈엑티브 :" + player.getSkill().isActive);
            //Console.WriteLine("스킬 x좌표 : " + player.getSkill().SkillX);


            map.Render();

            INVENPANEL.Instance().OpenInventory();
            INVENPANEL.Instance().DisplayInfoPanel();
            INVENPANEL.Instance().UseHPotion();
            INVENPANEL.Instance().UseMPotion();
            mon.Render();
            player.Render();
                   
            Console.WriteLine("캐릭터 공격력 :"+ player.GetINFO().pAttack);  
            Console.WriteLine("몬스터 체력 :"+ mon.Hp);  
            
            //mon.PrintLocation();


        }
            
    }
    
}


