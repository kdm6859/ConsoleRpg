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

        public bool sWeapon=false;
        public bool lWeapon=false;

        int skillIndex = 0;
        public void Select() //직업 선택
        {
            m_player = new INFO();
            Console.WriteLine("직업을 선택하시오 1.전사 2.마법사");

            int Input = 0;
            Input = int.Parse(Console.ReadLine());

            switch(Input)
            {
                case 1:
                    m_player.pName = "전사";
                    m_player.pHp = 100;
                    m_player.pAttack = 100;
                    sWeapon = true;
                    break;
                case 2:
                    m_player.pName = "마법사";
                    m_player.pHp = 80;
                    m_player.pAttack = 120;
                    lWeapon = true;
                    break;
            }
        }
        public void Initailize()
        {
            Select();

            skill = new Skill[20];            

            for(int i = 0; i < skill.Length; i++)
            {
                skill[i] = new Skill();
                skill[i].SkillX = m_player.pX+5;
                skill[i].SkillY = m_player.pY;
                skill[i].isActive = false;
            }
            
           
            m_player.pX = 0;  //플레이어 처음 x좌표
            m_player.pY = 50; //플레이어 처음 y좌표

        }
        public void Progress()
        {

            KeyControl();

            for (int i = 0; i < skill.Length; i++)
            {
                skill[i].Progress();  //스킬 나가는 좌표
            }
            

            if (m_player.pX < 0) //플레이어 x좌 0 밑으로 가면 x좌표 초기화
            {
                m_player.pX = 0;
            }
            if(m_player.pX > 140)
            {
                m_player.pX = 140;
            }  
            
        }
        public void Render() 
        {
            Console.Clear();        
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
                Console.SetCursorPosition(m_player.pX, m_player.pY+i);
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
                        m_player.pX += 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        m_player.pX -= 1;
                        break;
                    case ConsoleKey.Spacebar:
                        if (lWeapon)
                        {
                            //스페이스바 노말 공격 발사                    
                            if (skillIndex < skill.Length && skill[skillIndex].isActive == false)
                            {
                                skill[skillIndex].nSkill = true;
                                skill[skillIndex].Activate(m_player.pX, m_player.pY);
                                skillIndex++;
                            }                           
                        }
                        break;
                    
                    case ConsoleKey.Enter:  //엔터 누르면 스킬 발사
                        if (lWeapon)
                        {
                            if (skillIndex < skill.Length && skill[skillIndex].isActive == false)
                            {
                                skill[skillIndex].sSkill = true;
                                skill[skillIndex].Activate(m_player.pX, m_player.pY);
                                skillIndex++;
                            }
                        }                       
                        break;
                }
            }   
        }
    }
}


