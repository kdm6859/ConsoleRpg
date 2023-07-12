using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TeamRPG
{
    public class Skill
    {               
        public float SkillAtaack; //스킬 공격력

        public int SkillX;    //스킬 좌표
        public int SkillY;

        public bool isActive; //스킬 준비상태

        public bool lAttack;  // 원거리 노말 공격
        public bool lSkill;   //원거리 스킬 공격
        public bool sSkill;   //근거리 노말공격
        public bool sAttack;  //근거리 스킬 공격

        Player m_player = new Player();

        public int Current;
        
        public Skill(Player player)
        {           
            SkillX = 0;
            SkillY = 0;
            isActive = false;
            m_player = player;
            SkillAtaack = player.GetINFO().pAttack ; //스킬 데미지
        }
        public void Activate(int playerX, int playerY)
        {
            isActive = true;
            SkillX = playerX+5; //스킬 발사되는 위치 설정
            SkillY = playerY;            
        }
        public void Progress()
        {           
            if(isActive)
            {                                       
                if (m_player.sWeapon) //근거리 무기 true일 떄
                {
                    //스킬 플레이어 x좌표 앞에서 생성
                    SkillX = m_player.playerX + 5;                  
                }
                else
                {
                    //스킬 발사
                    SkillX += 1;
                }
                
                if(SkillX > 145) //x좌표 한계 넘어가면 초기화
                {
                    isActive = false;
                }
            }
            
        }       
        public void SkillDraw()
        {
            if(lSkill) //원거리 스킬공격
            {
                string[] sMagic = new string[]
                {
                    "┐",
                    "│",
                    "┘"
                };
                for (int i = 0; i < sMagic.Length; i++)
                {
                    Console.SetCursorPosition(SkillX, SkillY + i);
                    Console.WriteLine(sMagic[i]);
                }
            }
            
            if (lAttack)  //원거리 일반공격
            {               
                Console.SetCursorPosition(SkillX, SkillY+1);
                Console.Write("★");                 
            }


            if (sSkill) //근거리 스킬공격
            {
                string[] sMagic = new string[]
               {
                    "---->->->",
                    "---->->->",
                    "---->->->"
               };
                for (int i = 0; i < sMagic.Length; i++)
                {
                    Console.SetCursorPosition(SkillX+3, SkillY + i);
                    Console.WriteLine(sMagic[i]);
                }              

            }
            if (sAttack)  //근거리 일반공격
            {
                Console.SetCursorPosition(SkillX+3, SkillY + 1);
                Console.Write("--->");                
            }
        }

       
        public void Render()
        {
           
            if(isActive)
            {                                         
                SkillDraw();
                //Console.WriteLine(SkillAtaack);

                Current = Environment.TickCount;

                if ((sAttack||sSkill) && Current+2000 > Environment.TickCount)
                {
                    ClearsSkillAndsAttack();
                }
            }               
        }
        public void ClearsSkillAndsAttack()
        {
            if (sSkill)
            {
                // sSkill 지우기
                Console.SetCursorPosition(SkillX + 2, SkillY + 1);                
                sSkill = false;
            }
            if (sAttack)
            {
                // sAttack 지우기
                Console.SetCursorPosition(SkillX+3, SkillY + 1);
                sAttack = false;
            }                 
        }
            
    }
    
}
