using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg
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

        SensingArea playerArea = null;

        public void Initialize(SensingArea playerArea)
        {
            this.playerArea = playerArea;

        }

    }
}
