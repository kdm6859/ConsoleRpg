using System;
using System.Collections.Generic;

namespace TeamRPG
{
    internal class INVENPANEL
    {
        static Dictionary<ConsoleKey, Action> inventory;
        public static Player player;

        public static void OpenInventory(Player p)
        {
            player = p;
            InitializeInventory();

            Console.WriteLine("게임을 시작합니다.");

            DisplayInfoPanel();

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.I)
                {
                    OpenInventory();
                    DisplayInfoPanel();
                }
                else if (inventory.ContainsKey(keyInfo.Key))
                {
                    inventory[keyInfo.Key]();
                    DisplayInfoPanel();
                }
            }
        }

        static void InitializeInventory()
        {
            inventory = new Dictionary<ConsoleKey, Action>();

            inventory[ConsoleKey.D1] = UseHPotion;
            inventory[ConsoleKey.D2] = UseMPotion;
        }

        public static void OpenInventory()
        {
            //Console.Clear();
            Console.SetCursorPosition(125, 32);
            Console.WriteLine("=== 인벤토리 ===");
            Console.SetCursorPosition(125, 33);
            Console.WriteLine("1. HP 포션");
            Console.SetCursorPosition(125, 34);
            Console.WriteLine("2. MP 포션");
            Console.SetCursorPosition(125, 35);
            Console.WriteLine("================");
            Console.SetCursorPosition(100, 36);
            Console.WriteLine("아이템을 선택해주세요 (esc: 닫기):");

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    else if (inventory.ContainsKey(keyInfo.Key))
                    {
                        inventory[keyInfo.Key]();
                        DisplayInfoPanel();
                    }
                    else
                    {
                        Console.SetCursorPosition(120, 1);
                        Console.WriteLine("잘못된 아이템입니다.");
                    }
                }
                else
                {
                    player.KeyControl();
                }

                DisplayInfoPanel();
            }

            //Console.Clear();
            DisplayInfoPanel();
        }

        public static void DisplayInfoPanel()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 5);
            Console.WriteLine("========= 플레이어 정보 =========");
            Console.WriteLine("직업: " + player.GetINFO()?.pName);
            Console.WriteLine("HP: " + player.GetINFO()?.pHp + " / " + PlayerMaxHP() + "  MP: " + player.GetINFO()?.pMp + " / " + PlayerMaxMP());
            Console.WriteLine("공격력: " + player.GetINFO()?.pAttack);
            Console.WriteLine("================================");
        }

        static int PlayerMaxHP()
        {
            return player.GetINFO()?.MaxHp ?? 0;
        }

        static int PlayerMaxMP()
        {
            return player.GetINFO()?.MaxMp ?? 0;
        }

        static void UseHPotion()
        {
            int healAmount = 30;
            int currentHP = player.GetINFO()?.pHp ?? 0;
            int maxHP = PlayerMaxHP();

            if (currentHP == maxHP)
            {
                Console.SetCursorPosition(120, 1);
                Console.WriteLine("이미 체력은 최대치 입니다..");
                return;
            }

            int newHP = currentHP + healAmount;
            if (newHP > maxHP)
                newHP = maxHP;

            player.GetINFO().pHp = newHP;
            Console.SetCursorPosition(120, 1);
            Console.WriteLine("체력을 {0} 회복하였습니다.", newHP - currentHP);
        }

        static void UseMPotion()
        {
            int healAmount = 30;
            int currentMP = player.GetINFO()?.pMp ?? 0;
            int maxMP = PlayerMaxMP();

            if (currentMP == maxMP)
            {
                Console.SetCursorPosition(120, 1);
                Console.WriteLine("이미 마나는 최대치 입니다.");
                return;
            }

            int newMP = currentMP + healAmount;
            if (newMP > maxMP)
                newMP = maxMP;

            player.GetINFO().pMp = newMP;
            Console.SetCursorPosition(120, 1);
            Console.WriteLine("마나를 {0} 회복하였습니다.", newMP - currentMP);
        }
    }
}