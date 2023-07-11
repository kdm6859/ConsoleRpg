using System;
using System.Collections.Generic;

namespace TeamRPG
{
    internal class INVENPANEL
    {
        static Dictionary<ConsoleKey, Action> inventory;
        static Player player;

        public static void OpenInventory(Player p)
        {
            player = p;

            Console.WriteLine("게임을 시작합니다.");

            DisplayInfoPanel(); // 초기 정보창 표시

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.I)
                {
                    OpenInventory();
                    DisplayInfoPanel(); // 인벤토리를 열고 닫은 후 정보창을 표시
                }
                else if (inventory.ContainsKey(keyInfo.Key))
                {
                    inventory[keyInfo.Key]();
                    DisplayInfoPanel(); // 아이템을 사용한 후 정보창을 표시
                }

                // 게임 로직 진행
                // ...
            }
        }

        static void OpenInventory()
        {
            Console.SetCursorPosition(135, 32);
            Console.WriteLine("=== 인벤토리 ===");
            Console.SetCursorPosition(135, 33);
            Console.WriteLine("1. HP 포션");
            Console.SetCursorPosition(135, 34);
            Console.WriteLine("2. MP 포션");
            Console.SetCursorPosition(135, 34);
            Console.WriteLine("================");
            Console.SetCursorPosition(120, 35);
            Console.WriteLine("아이템을 선택해주세요 (esc: 닫기):");

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }

                if (inventory.ContainsKey(keyInfo.Key))
                {
                    inventory[keyInfo.Key]();
                }
                else
                {
                    Console.WriteLine("잘못된 아이템입니다.");
                }
            }

            Console.Clear();
        }

        static void DisplayInfoPanel()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 8);
            Console.WriteLine("========= 플레이어 정보 =========");
            Console.WriteLine("이름: " + player.Name + "       직업: " + player.Job);
            Console.WriteLine("HP: " + player.HP + " / " + PlayerMaxHP() + "       MP: " + player.MP + " / " + PlayerMaxMP());
            Console.WriteLine("공격력: " + player.Attack);
            Console.WriteLine("================================");
        }

        static int PlayerMaxHP()
        {
            return 80; // 최대 HP 값 반환
        }

        static int PlayerMaxMP()
        {
            return 120; // 최대 MP 값 반환
        }
    }
}