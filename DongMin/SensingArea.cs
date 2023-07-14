using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg
{
    public class SensingArea
    {
        public Position[] positions;
        public int[] width;
        public int[] height;

        public SensingArea(int[] width, int[] height, params Position[][] position)
        {
            positions = new Position[position.Length];

            this.width = new int[position.Length];
            this.height = new int[position.Length];

            for (int i = 0; i < position.Length; i++)
            {
                this.width[i] = width[i];
                this.height[i] = height[i];
                for (int j = 0; j < position[i].Length; j++)
                {
                    positions[i] = position[i][j];
                }
            }
        }
    }
}
