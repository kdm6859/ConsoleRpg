using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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

        bool isJumping = false;
        bool isJumpUp = false;
        bool isJumpDown = false;
        bool startJumping = false;
        int jumpHeight = 5;  // 점프 높이 조정 (값이 클수록 더 높이 점프)
        int jumpDuration = 500;  // 점프에 걸리는 시간 (밀리초)
        int startJumpTime = 0;
        int currentJumpTime = 0;
        int jumpUpCount = 3;
        int jumpDownCount = 3;
        //public int playerJump = 2;


        public void SetDamage(int iAttack) { m_player.pHp -= iAttack; } //데미지 받는 함수
        public void PlayerGameOver()
        {
            if(m_player.pHp==0) 
            {
                
            }
        }

        public void SetEXP(int exp)  //경험치 받아서 플레이어 레벨 올림
        { 
            m_player.pEXP += exp;

            if(m_player.pEXP >= 100)
            {
                m_player.pLevel += 1;   //경험치100되면 레벨 1증가
                m_player.pMp = m_player.MaxMp;     //레벨 오르면 mp,hp 100으로 초기화
                m_player.pHp = m_player.MaxHp;
                m_player.pAttack += 10; //레벨 오르면 공격력 10증가
                m_player.pEXP = 0;      //레벨 오르면 경험치 0으로 초기화
            }
        }

        public INFO GetINFO() { return m_player; } //플레이어 정보

        public bool sWeapon=false; //근접 무기
        public bool lWeapon=false; //원거리 무기

        int skillIndex = 0;
        
        public void Initailize()
        {
            m_player = new INFO();
            playerX = m_player.pX;
            playerY = m_player.pY;
            m_player.pLevel = 1;
            m_player.pEXP = 0;

            playerX = 0;  //플레이어 처음 x좌표
            playerY = 25; //플레이어 처음 y좌표

            Select();

            skill = new Skill[100]; //스킬 갯수

                      
            for (int i = 0; i < skill.Length; i++)
            {
                skill[i] = new Skill(this);
                skill[i].SkillX = playerX+5;
                skill[i].SkillY = playerY;
                skill[i].isActive = false;
            }
                                                        
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
            Jump();
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
            if(playerX > 145)
            {
                playerX = 145;
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
                        isJumping = true;
                        //if (playerY > 1 && playerY == 25)
                        //playerJump = 0;

                        //Jump();                                              
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
                            
                            if (skillIndex < skill.Length && skill[skillIndex].isActive == false && m_player.pMp >= 10)
                            {
                                skill[skillIndex].lSkill = true;
                                skill[skillIndex].Activate(playerX, playerY);
                                skill[skillIndex].SkillAtaack = m_player.pAttack * 1.5f;
                                m_player.pMp -= 10;
                                skillIndex++;
                            }
                            
                           
                        }
                        if (sWeapon)
                        {                           
                            if (skillIndex < skill.Length && skill[skillIndex].isActive == false && m_player.pMp >= 10)
                            {
                                skill[skillIndex].sSkill = true;
                                skill[skillIndex].Activate(playerX, playerY);
                                skill[skillIndex].SkillAtaack = m_player.pAttack * 1.5f;
                                m_player.pMp -= 10;
                                skillIndex++;
                            }                                                         
                        }
                        break;
                }
            }   
        }

        public void Jump()
        {                       
            if(isJumping)
            {
                //if (startJumping)
                //{
                //    startJumpTime = Environment.TickCount;
                //    startJumping = false;
                //}

                if (jumpUpCount > 0)
                {
                    playerY -= 1;
                    jumpUpCount--;
                }
                else if(jumpDownCount > 0)
                {
                    playerY += 1;
                    jumpDownCount--;
                }
                else
                {
                    isJumping = false;
                    jumpUpCount = 3;
                    jumpDownCount = 3;
                }
                

                //if (Environment.TickCount - startJumpTime >= 500)
                //{

                //}

                //while (isJumping)
                //{
                //    int currentJumpTime = Environment.TickCount - startJumpTime;

                //    //for(int i = 0;)

                //    //Console.Clear();

                //    if (currentJumpTime >= jumpDuration)
                //    {
                //        // 점프 종료
                //        isJumping = false;
                //        playerY = 25;

                //    }
                //    /*
                //    else if (doJumping == false)
                //    { 
                        
                //    }*/
                //    else
                //    {
                        
                //        int jumpProgress = (int)((float)currentJumpTime / jumpDuration * jumpHeight);
                //        playerY = 25 - jumpProgress;
                //        //Render();

                //    }
                //}
                //playerY -= 2;
                //playerX += 2;

                //if (playerY < 35)
                //{

                //    if (playerJump < 4)
                //        playerJump += 1;

                //    playerY -= playerJump;
                //    playerX += playerJump;

                //    while(playerY > targetY)
                //    {
                //        if (Current + 1000 < Environment.TickCount)
                //        {
                //            playerY--;
                //            playerX += 2;
                //            Current = Environment.TickCount;
                //        }
                //    }
                //    playerY = Math.Max(playerY, 35);



                //}
                //else
                //{
                //    playerJump = 0;
                //    playerY = 35;
                //}

            }
            
        }
     
    }
}


