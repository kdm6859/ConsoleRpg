
using ConsoleRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


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
        Monster mon2 = null;
        Monster mon3 = null;
        Monster mon4 = null;
        Monster mon5 = null;
        Monster mon6 = null;
        Skill skill = null;
        ShortSkill shortskill = null;

        public Player GetPlayer() { return player; }
        public Monster GetMonster() { return mon; }
        public void Initialize()
        {
            map = new Map();
            skill = new Skill();
            player = new Player();
            shortskill = new ShortSkill(player, skill);

            map.Initialize();
            player.Initailize();
            
            if (map.currentStageNum == Map.StageNum.stage1)
            {
                mon = new Monster("Monster", 40, 28, 1, 500); //string[] symbol
                mon2 = new Monster("Monster", 80, 28, 1, 500); //string[] symbol
                mon3 = new Monster("Monster", 70, 18, 1, 500); //string[] symbol
                mon4 = new Monster("Monster", 15, 8, 1, 500); //string[] symbol
                mon5 = new Monster("Monster", 80, 10, 1, 500); //string[] symbol
                mon6 = new Monster("Monster", 110, 15, 1, 500); //string[] symbol


            }



            ObjectManager.Instance().Initialize(ref player, ref mon, ref map);


        }
        public void Progress()
        {
            INVENPANEL.Instance().KeySensing();
            KeyControlManager.Instance().KeyControl();



            player.Progress(mon, mon2, mon3, mon4, mon5, mon6);

            mon.Progress(player);
            mon2.Progress(player);
            mon3.Progress(player);
            mon4.Progress(player);
            mon5.Progress(player);
            mon6.Progress(player);


            ObjectManager.Instance().Progress();
            

        }
        public void Render()
        {
            Console.SetCursorPosition(3, 3);
            Console.Write("isLanding = " + ObjectManager.Instance().isLanding);
           
            map.Render();

            INVENPANEL.Instance().OpenInventory();
            INVENPANEL.Instance().DisplayInfoPanel();
            INVENPANEL.Instance().UseHPotion();
            INVENPANEL.Instance().UseMPotion();
            mon.Render();
            mon2.Render();
            mon3.Render();
            mon4.Render();
            mon5.Render();
            mon6.Render();
            player.Render();

           

            //mon.PrintLocation();
        }

    }
    /* internal class GameManager
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
         public Monster GetMonster() { return mon; }
         public void Initialize()
         {
             map = new Map();
             skill = new Skill();
             player = new Player();
             shortskill = new ShortSkill(player, skill);

             map.Initialize();
             player.Initailize();


             mon = new Monster("Monster", 40, 28, Monster.monsterStr, 1, 500);

         }
         public void Progress()
         {
             INVENPANEL.Instance().KeySensing();
             KeyControlManager.Instance().KeyControl();
             player.Progress(mon);
             mon.Progress(player);



         }
         public void Render()
         {
             //Console.Clear();

             //Console.WriteLine("플레이어 dir :" + player.getSkill().dir);
             //Console.WriteLine("이즈엑티브 :" + player.getSkill().isActive);
             //Console.WriteLine("스킬 x좌표 : " + player.getSkill().SkillX);


             map.Render();

             INVENPANEL.Instance().OpenInventory();
             INVENPANEL.Instance().DisplayInfoPanel();
             INVENPANEL.Instance().UseHPotion();
             INVENPANEL.Instance().UseMPotion();

             player.Render();
             mon.Render();
             Console.WriteLine("캐릭터 공격력 :" + player.GetINFO().pAttack);
             Console.WriteLine("몬스터 체력 :" + mon.Hp);

             //mon.PrintLocation();


         }

     }*/

}


