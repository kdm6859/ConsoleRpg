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

        public void Initialize()
        {
            player = new Player();
            player.Initailize();
        }
        public void Progress()
        {
            player.Progress();
        }
        public void Render()
        {
            Console.Clear();
            player.Render();
        }
            
    }
    
}
