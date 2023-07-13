using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class LongSkill
    {
        Skill m_skill = null;
        Player m_player = null;
        int Current =Environment.TickCount;

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
                        Console.WriteLine("플레이어 x좌표 : " + m_player.playerX);
                        Console.WriteLine("스킬 x좌표 :" + m_skill.SkillX);

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
                        Console.SetCursorPosition(m_skill.SkillX, m_skill.SkillY + i);
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

        public void Progress() //스킬 좌표 설정
        {          
            if (m_skill.isActive)
            {
                if (m_player.lWeapon)
                {                    
                    if (m_player.getSkill().dir)
                    {
                        // m_skill.SkillX = m_player.playerX + 5;
                        m_skill.SkillX += 1;
                    }
                    else
                    {
                       //m_skill.SkillX = m_player.playerX - 1;
                        m_skill.SkillX -= 1;
                    }
                }

                if (m_skill.SkillX >= 145 || m_skill.SkillX <= 5) 
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
                m_skill.SkillX = playerX + 1; //스킬 발사되는 위치 설정
                m_skill.SkillY = playerY;
            }
            else
            {
                m_skill.SkillX = playerX - 1; //스킬 발사되는 위치 설정
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
