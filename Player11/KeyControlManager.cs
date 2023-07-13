using ConsoleRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    internal class KeyControlManager
    {
        public static KeyControlManager instance;
        public static KeyControlManager Instance()
        {
            if (instance == null)
            {
                instance = new KeyControlManager();
            }
            return instance;
        }

        public enum KeyState
        {
            None,
            right,
            left,
            spaceBar,
            z,
            x,
            i,
            num1,
            num2,
        }

        public KeyState keyState = KeyState.None;

        public bool KeyCompare(KeyState keyState)
        {
            if (this.keyState == keyState)
            {
                this.keyState = KeyState.None;
                return true;
            }
            else
                return false;
        }

        public void KeyControl()
        {
            if (Console.KeyAvailable)
            {
                int input;
                input = Program._getch();
                if (input == 224)
                {
                    input = Program._getch();
                }

                switch (input)
                {
                    case 77: //오른쪽
                        keyState = KeyState.right;
                        break;

                    case 75: //왼쪽
                        keyState = KeyState.left;
                        break;

                    case 32: //스페이스바
                        keyState = KeyState.spaceBar;
                        break;

                    case 122: // z 노말 공격 발사  
                        keyState = KeyState.z;
                        break;

                    case 120:  // x 누르면 스킬 발사
                        keyState = KeyState.x;
                        break;

                    case 'i':
                        keyState = KeyState.i;
                        break;
                    case '1':
                        keyState = KeyState.num1;
                        break;
                    case '2':
                        keyState = KeyState.num2;
                        break;
                }
            }
        }
    }
}
