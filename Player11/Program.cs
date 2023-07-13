using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    internal class Program
    {
        [DllImport("msvcrt.dll")]
        public static extern int _getch();
        static void Main(string[] args)
        {

            
            int Current = Environment.TickCount;

           
            GameManager.Instance().Initialize();
            while (true)
            {
               
                if(Current + 100 < Environment.TickCount)
                {
                    Console.Clear();
                    Current = Environment.TickCount;
                    GameManager.Instance().Progress();
                    GameManager.Instance().Render();
                }
            }                        
        }
    }
}
