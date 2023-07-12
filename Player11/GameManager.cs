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

            mon  = new Monster("Monster",40,30,"☆",1);
         
           

        }
        public void Progress()
        {
            player.Progress();
        }
        public void Render()
        {
            Console.Clear();
            player.Render();
            mon.Render();
            mon.PrintLocation();
            mon.Progress(player);
            
        }
            
    }
    
}
