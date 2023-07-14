
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.InteropServices;

namespace ConsoleRpg
{
    internal class INVENPANEL
    {
        public static INVENPANEL instance = null;      

        public static INVENPANEL Instance()
        {
            if (instance == null)
            {
                instance = new INVENPANEL(player);
            }
            return instance;
        }

        Dictionary<ConsoleKey, Action> inventory;
        public static Player player;

        bool invenOnOff = false;
        bool usehppotion = false;
        bool usemppotion = false;
             

        public INVENPANEL(Player player)
        {
            INVENPANEL.player = player;            
        }

        public void OpenInventory()
        {
            if(invenOnOff)
            {
                Console.SetCursorPosition(125, 32);
                Console.WriteLine("=== 인벤토리 ===");
                Console.SetCursorPosition(125, 33);
                Console.WriteLine("1. HP 포션");
                Console.SetCursorPosition(125, 34);
                Console.WriteLine("2. MP 포션");
                Console.SetCursorPosition(125, 35);
                Console.WriteLine("================");
               

                DisplayInfoPanel();
            }
        }
        /*public void ClearInventory()
        {
            int inventoryStartRow = 32; // 인벤토리 시작 행 위치
            int inventoryEndRow = 35; // 인벤토리 끝 행 위치
            int inventoryColumn = 125; // 인벤토리 열 위치

            for (int row = inventoryStartRow; row <= inventoryEndRow; row++)
            {
                Console.SetCursorPosition(inventoryColumn, row);
                Console.Write(new string(' ', Console.WindowWidth - inventoryColumn));
            }

            Console.SetCursorPosition(100, 36);
            Console.Write(new string(' ', Console.WindowWidth - 100));
        }*/

        public void DisplayInfoPanel()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 8);
            Console.WriteLine("========= 플레이어 정보 =========");
            Console.WriteLine("직업: " + player.GetINFO()?.pName);
            Console.WriteLine("HP: " + player.GetINFO()?.pHp + " / " + PlayerMaxHP() + "  MP: " + player.GetINFO()?.pMp + " / " + PlayerMaxMP());
            Console.WriteLine("공격력: " + player.GetINFO()?.pAttack);
            Console.WriteLine("================================");
        }

        int PlayerMaxHP()
        {
            return player.GetINFO()?.MaxHp ?? 0;
        }

        int PlayerMaxMP()
        {
            return player.GetINFO()?.MaxMp ?? 0;
        }

        public void UseHPotion()
        {
            int healAmount = 30;
            int currentHP = player.GetINFO()?.pHp ?? 0;
            int maxHP = PlayerMaxHP();
            int newHP = currentHP + healAmount;

            if (usehppotion)
            {
                if (currentHP == maxHP)
                {
                    Console.SetCursorPosition(120, 1);
                    Console.WriteLine("이미 체력은 최대치 입니다..");
                    return;
                }

                if(currentHP < maxHP)
                {
                    newHP = currentHP + healAmount;
                    if(newHP > currentHP)
                    {
                        usehppotion = false;
                    }
                }

                if (newHP >= maxHP)
                    newHP = maxHP;

                player.GetINFO().pHp = newHP;
                Console.SetCursorPosition(120, 1);
                Console.WriteLine("체력을 {0} 회복하였습니다.", newHP - currentHP);
            }
        }

        public void UseMPotion()
        {
            int healAmount = 30;
            int currentMP = player.GetINFO().pMp;
            int maxMP = PlayerMaxMP();
            int newMP = currentMP + healAmount;
            ///int ResetMp = 0;
            if(usemppotion)
            {
                if (currentMP == maxMP)
                {
                    Console.SetCursorPosition(120, 1);
                    Console.WriteLine("이미 마나는 최대치 입니다.");
                    return;
                }//마나 최대 체크

                
                if (currentMP < maxMP) //현재 마나가 최대치보다 작은가?
                {                  
                    newMP = currentMP + healAmount; //현재마나가 최대치보다 작으면 30 회복

                    if (newMP > currentMP) //현재 마나에 회복 마나 값을 던한 값. = newMp
                    {
                        usemppotion = false;                       
                    }                   
                }
                if(newMP >= maxMP)
                    newMP = maxMP;

                player.GetINFO().pMp = newMP;
                Console.SetCursorPosition(120, 1);
                Console.WriteLine("마나를 {0} 회복하였습니다.", newMP - currentMP);
            }
        }

        public void KeySensing()
        {
            if (KeyControlManager.Instance().KeyCompare(KeyControlManager.KeyState.i))
            {
                if (invenOnOff)
                {
                    invenOnOff = false;
                    //ClearInventory();
                }
                else
                {
                    invenOnOff = true;
                    //INVENPANEL.Instance().OpenInventory();
                }
                DisplayInfoPanel();
            }
            else if (KeyControlManager.Instance().KeyCompare(KeyControlManager.KeyState.num1))
            {
                if(!usehppotion)
                {
                    usehppotion = true;                    
                }
               
                /*UseHPotion();
                DisplayInfoPanel();*/
            }
            else if (KeyControlManager.Instance().KeyCompare(KeyControlManager.KeyState.num2))
            {
                if (!usemppotion)
                {
                    usemppotion = true;
                    
                }
                
                /*UseMPotion();
                DisplayInfoPanel();*/
            }
            


            ////switch문 ex)
            //switch (KeyControlManager.Instance().keyState)
            //{
            //    case KeyControlManager.KeyState.right:
            //        skill.dir = true;
            //        playerX += 3;

            //        KeyControlManager.Instance().keyState = KeyControlManager.KeyState.None;
            //        break;
            //}
        }

    //    public void InvenKeyControl(ConsoleKey key)
    //    {

    //        switch (key)
    //        {
    //            case ConsoleKey.I:
    //                if (invenOnOff)
    //                {
    //                    invenOnOff = false;
    //                    ClearInventory();
    //                }
    //                else
    //                {
    //                    invenOnOff = true;
    //                    OpenInventory();
    //                }
    //                DisplayInfoPanel();
    //                break;
    //            case ConsoleKey.D1:
    //                // 1번키 처리 내용: 인벤토리 내의 HP포션을 사용하는 버튼 동작
    //                UseHPotion();
    //                DisplayInfoPanel();
    //                break;
    //            case ConsoleKey.D2:
    //                // 2번키 처리 내용: 인벤토리 내의 MP포션을 사용하는 버튼 동작
    //                UseMPotion();
    //                DisplayInfoPanel();
    //                break;
    //            default:
    //                Console.SetCursorPosition(120, 1);
    //                Console.WriteLine("잘못된 아이템입니다.");
    //                break;
    //        }
    //    }
    }
}