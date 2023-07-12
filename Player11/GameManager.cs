using ConsoleRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRPG
{
    internal class GameManager
    {
        Player player = null;
        Monster mon = null;
        public void Initialize()
        {
            player = new Player();
            player.Initailize();

            mon  = new Monster("Monster",40,25,"☆",1);
         
           

        }
        public void Progress()
        {
            player.Progress();
            mon.Progress(player);
        }
        public void Render()
        {
            Console.Clear();
            Console.Write(player.GetINFO().pMp);
            player.Render();
            mon.Render();
            mon.PrintLocation();
            
            
        }
            
    }
    
}
