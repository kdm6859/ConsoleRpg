﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gm = new GameManager();
            int Current = Environment.TickCount;

            gm.Initialize();

            while (true)
            {
                if (Current + 100 < Environment.TickCount)
                {
                    Current = Environment.TickCount;
                    gm.Progress();
                    gm.Render();

                }
            }


        }
    }
}