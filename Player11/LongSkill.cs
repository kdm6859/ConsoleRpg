using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class LongSkill
    {
        Skill m_skill = null;
        Player m_player = null;

        public LongSkill(Player player, Skill skill)
        {
            m_skill = skill;
            m_player = player;
        }  
        LongSkill() { }

        public Skill GetINFO() { return m_skill; }

        public void SkillDraw()
        {

            if (m_skill.lSkill) //원거리 스킬공격
            {
                if (m_player.getSkill().dir)
                {
                    string[] sMagic = new string[]
                    {
                        "┐",
                        "│",
                        "┘"
                    };
                    for (int i = 0; i < sMagic.Length; i++)
                    {
                        Console.SetCursorPosition(m_skill.SkillX, m_skill.SkillY + i);
                        Console.WriteLine(sMagic[i]);
                    }
                   
                }
                else
                {
                    string[] sMagic = new string[]
                   {
                        "┏",
                        "┃",
                        "┗"
                   };
                    for (int i = 0; i < sMagic.Length; i++)
                    {
                        Console.SetCursorPosition(m_skill.SkillX-5, m_skill.SkillY + i);
                        Console.WriteLine(sMagic[i]);
                    }
                    
                }
                if(m_skill.lAttack)
                {                   
                        Console.SetCursorPosition(m_skill.SkillX, m_skill.SkillY + 1);
                        Console.Write("★");                    
                }                                               
            }
               
        }

        public void Progress()
        {
            if (m_skill.isActive)
            {
                

                if (m_player.lWeapon && m_player.getSkill().dir) 
                {
                    //스킬 플레이어 x좌표 앞에서 생성
                    m_skill.SkillX = m_player.playerX+5;
                    m_skill.SkillX += 1;

                }
                else if (m_player.lWeapon && m_player.getSkill().dir == false)
                {
                   // m_skill.SkillX = m_player.playerX - 7;
                    m_skill.SkillX -= 1;
                }

                if (m_skill.SkillX >= 145 || m_skill.SkillX <= 5) //x좌표 한계 넘어가면 초기화
                {
                    m_skill.isActive = false;
                }

            }
        }

        public void Activate(int playerX, int playerY)
        {
            m_skill.isActive = true;
         
            if (m_player.getSkill().dir)
            {
                m_skill.SkillX = playerX+5; //스킬 발사되는 위치 설정
                m_skill.SkillY = playerY;
            }
            else
            {
                m_skill.SkillX = playerX-5; //스킬 발사되는 위치 설정
                m_skill.SkillY = playerY;
            }
            
        }

        public void Render()
        {

            if (m_skill.isActive)
            {
                SkillDraw();                                           
            }
        }

    }
}
