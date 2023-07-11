using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg
{
    public class Program
    {
        [DllImport("msvcrt.dll")]
        public static extern int _getch(); //C언어 함수 가져옴

        static void Main(string[] args)
        {
            Console.WriteLine("?????");
            Console.WriteLine("!!?!");
        }
    }
}
