using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TeamRPG;

namespace TeamRPG
{
    internal class Player
    {       
        Skill[] skill = null;
        INFO m_player = null;
        
        public int playerX;
        public int playerY;

        public void SetDamage(int iAttack) { m_player.pHp -= iAttack; } //데미지 받는 함수
        public INFO GetINFO() { return m_player; }

        public bool sWeapon=false; //근접 무기
        public bool lWeapon=false; //원거리 무기

        int skillIndex = 0;
        
        public void Initailize()
        {
            m_player = new INFO();
            playerX = m_player.pX;
            playerY = m_player.pY;

            Select();

            skill = new Skill[50];

                      
            for (int i = 0; i < skill.Length; i++)
            {
                skill[i] = new Skill(this);
                skill[i].SkillX = playerX+5;
                skill[i].SkillY = playerY;
                skill[i].isActive = false;
            }
            
           
            playerX = 0;  //플레이어 처음 x좌표
            playerY = 50; //플레이어 처음 y좌표

        }
        public void Select() //직업 선택
        {


            Console.WriteLine("직업을 선택하시오 1.전사 2.마법사");

            int Input = 0;
            Input = int.Parse(Console.ReadLine());

            switch (Input)
            {
                case 1:
                    m_player.pName = "전사";
                    m_player.pHp = 100;
                    m_player.pMp = 100;
                    m_player.pAttack = 100;
                    sWeapon = true;
                    break;
                case 2:
                    m_player.pName = "마법사";
                    m_player.pHp = 80;
                    m_player.pMp = 120;
                    m_player.pAttack = 120;
                    lWeapon = true;
                    break;
            }
        }
        public void Progress()
        {

            KeyControl();        

            for (int i = 0; i < skill.Length; i++)
            {
                skill[i].Progress();  //스킬 나가는 좌표
                if (skill[i].SkillX > 145)
                {
                    skill[i].isActive = false;
                }                   
            }
            
            

            if (playerX < 0) //플레이어 x좌 0 밑으로 가면 x좌표 초기화
            {
                playerX = 0;
            }
            if(playerX > 140)
            {
                playerX = 140;
            }  
            
        }
        public void Render() 
        {           
                   
            DrawPlayer();  //플레이어 출력           

            for (int i = 0; i < skill.Length; i++)  // 스킬 출력
            {
                skill[i].Render();
            }                                       
        }
        public void DrawPlayer() //플레이어 그리기
        {
            string[] player = new string[]
            {
                "  ●",
                "↙┃ ↘",
                " ┃ ┃",
                " ┘ └",
            };

            for(int i=0; i<player.Length; i++)
            {
                Console.SetCursorPosition(playerX, playerY+i);
                Console.WriteLine(player[i]);
            }
        }                                              
        public void KeyControl()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey pressKey = Console.ReadKey(true).Key;

                switch (pressKey)
                {
                    case ConsoleKey.RightArrow:
                        playerX += 1;
                        break;

                    case ConsoleKey.LeftArrow:
                        playerX -= 1;
                        break;
                    case ConsoleKey.Spacebar:
                        playerX += 1;
                        playerY -= 1;
                        break;

                    case ConsoleKey.Z: // z 노말 공격 발사  
                       
                        if (lWeapon) // 지팡이 트루일떄
                        {                                              
                            if (skillIndex < skill.Length && skill[skillIndex].isActive == false)
                            {
                                 skill[skillIndex].lAttack = true;
                                 skill[skillIndex].Activate(playerX, playerY);
                                 skillIndex++;
                            }                           
                        }

                        if (sWeapon) //근접무기 트루일떄
                        {
                            if (skillIndex < skill.Length && skill[skillIndex].isActive == false)
                            {
                                skill[skillIndex].sAttack = true;
                                skill[skillIndex].Activate(playerX, playerY);
                                skillIndex++;
                            }
                     
                        }
                        break;
                    
                    case ConsoleKey.X:  // x 누르면 스킬 발사
                        
                        if (lWeapon) //지팡이 트루일 때
                        {
                            if (skillIndex < skill.Length && skill[skillIndex].isActive == false)
                            {
                                skill[skillIndex].lSkill = true;
                                skill[skillIndex].Activate(playerX, playerY);
                                skillIndex++;
                            }
                        }

                        if (sWeapon)
                        {
                            if (skillIndex < skill.Length && skill[skillIndex].isActive == false)
                            {
                                skill[skillIndex].sSkill = true;
                                skill[skillIndex].Activate(playerX, playerY);
                                skillIndex++;
                            }
                        }
                        break;
                }
            }   
        }
    }
}


