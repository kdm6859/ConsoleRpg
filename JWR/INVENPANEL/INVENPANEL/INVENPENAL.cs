using System;
using System.Collections.Generic;

namespace TeamRPG
{
    internal class INVENPANEL
    {
        public static INVENPANEL instanse = null;

        public static INVENPANEL Instanse()
        {
            if(instanse == null)
            {
                instanse = new INVENPANEL();
            }
            return instanse;
        }

        static Dictionary<ConsoleKey, Action> inventory;
        public static Player player;

        bool invenOnOff = false;

        public void OpenInventory(Player p)
        {
            player = p;
            InitializeInventory();

            DisplayInfoPanel();
            
            //while (true)
            //{
            //    ConsoleKeyInfo keyInfo = Console.ReadKey(); 
                

            //    if (keyInfo.Key == ConsoleKey.I)//i키를 입력하면 인벤토리를 열고, 플레이어정보창을 연다.
            //    {
            //        OpenInventory();
            //        DisplayInfoPanel();
            //    }
            //    else if (inventory.ContainsKey(keyInfo.Key))//인벤토리에서 사용하는 키값 중 하나인 경우(1,2,esc)관련 내용으로 작동하게 처리한다.
            //    {
            //        inventory[keyInfo.Key]();
            //        DisplayInfoPanel();
            //    }
            //    else
            //    {
            //        InvenKeyControl(keyInfo.Key); // 인벤토리 외의 키 입력은 InvenKeyControl 메서드에 전달하여 처리한다.
            //    }
            //}
        }

        static void InitializeInventory()
        {
            inventory = new Dictionary<ConsoleKey, Action>();

            inventory[ConsoleKey.D1] = UseHPotion;//1번키를 누르면 HP포션 사용
            inventory[ConsoleKey.D2] = UseMPotion;//2번키를 누르면 MP포션 사용
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

        void InvenKeyControl(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.I:
                    if (invenOnOff)
                    {
                        invenOnOff = false;
                    }
                    else
                    {
                        invenOnOff = true;
                    }
                    

                    if (invenOnOff)
                    {
                        OpenInventory();
                    }
                    // i키 처리 내용: 인벤토리를 여는 버튼 동작
                    //OpenInventory();
                    DisplayInfoPanel();
                    break;
                case ConsoleKey.Escape:
                    // esc 키 처리 내용: 인벤토리 창을 닫는 버튼 동작
                    //Console.SetCursorPosition(125, 32);
                    //Console.WriteLine("                "); // 인벤토리 부분 지우기
                    //Console.SetCursorPosition(125, 33);
                    //Console.WriteLine("                ");
                    //Console.SetCursorPosition(125, 34);
                    //Console.WriteLine("                ");
                    //Console.SetCursorPosition(125, 35);
                    //Console.WriteLine("                ");
                    //Console.SetCursorPosition(100, 36);
                    //Console.WriteLine("                                  "); // 선택 메시지 부분 지우기
                    
                    break;
                case ConsoleKey.D1:
                    // 1번키 처리 내용: 인벤토리 내의 HP포션을 사용하는 버튼 동작
                    UseHPotion();
                    DisplayInfoPanel();
                    break;
                case ConsoleKey.D2:
                    // 2번키 처리 내용: 인벤토리 내의 MP포션을 사용하는 버튼 동작
                    UseMPotion();
                    DisplayInfoPanel();
                    break;
                default:
                    Console.SetCursorPosition(120, 1);
                    Console.WriteLine("잘못된 아이템입니다.");
                    break;
            }
        }
    }
}