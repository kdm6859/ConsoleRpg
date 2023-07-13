using ConsoleRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    internal class GameManager
    {
        Player player = null;
        Monster mon = null;
        Skill skill = null;
        
        public Player GetPlayer() { return player; }
        public void Initialize()
        {
           
            skill = new Skill();
            player = new Player();
            
            player.Initailize();
            

            mon  = new Monster("Monster",40,25,"☆",1);
        
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


