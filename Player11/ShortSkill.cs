using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class ShortSkill
    {
        Player m_player = null;
        Skill m_skill = null;
        public ShortSkill(Player player, Skill skill)
        {
            this.m_player = player;
            this.m_skill = skill;
        }
        ShortSkill() { }
        public Skill GetINFO() { return m_skill; }
        public void SkillDraw()
        {
            if (m_skill.sSkill) //근거리 스킬공격
            {
                if (m_player.getSkill().dir)
                {

                    string[] sMagic = new string[]
                    {
                        "---->->->",
                        "---->->->",
                        "---->->->"

                    };

                    for (int i = 0; i < sMagic.Length; i++)
                    {
                        Console.SetCursorPosition(m_skill.SkillX + 5, m_skill.SkillY + i);
                        Console.WriteLine(sMagic[i]);
                    }

                }
                else
                {
                    string[] sMagic = new string[]
                    {

                       "<-<-<----",
                       "<-<-<----",
                       "<-<-<----"
                    };

                    for (int i = 0; i < sMagic.Length; i++)
                    {
                        Console.SetCursorPosition(m_skill.SkillX - 8, m_skill.SkillY + i);
                        Console.WriteLine(sMagic[i]);
                    }
                }


            }
            if (m_skill.sAttack)  //근거리 일반공격
            {
                if (m_player.getSkill().dir)
                {
                    Console.SetCursorPosition(m_skill.SkillX + 5, m_skill.SkillY + 1); 
                    Console.Write("--->");
                }
                else
                {
                    Console.SetCursorPosition(m_skill.SkillX-5, m_skill.SkillY + 1);  
                    Console.Write("<---");
                }
                
            }
        }

        public void Progress()
        {
            if (m_player.sWeapon && m_skill.dir) //근거리 무기 true일 떄
            {
                //스킬 플레이어 x좌표 앞에서 생성
                m_skill.SkillX = m_player.playerX + 5;
            }
            else if (m_player.sWeapon && m_skill.dir == false)
            {
                m_skill.SkillX = m_player.playerX - 7;
            }

            if (m_skill.SkillX > 145) //x좌표 한계 넘어가면 초기화
            {
                m_player.sWeapon = false;
            }
        }

        public void Activate(int playerX, int playerY)
        {
            m_skill.isActive = true;
            m_skill.SkillX = playerX; //스킬 발사되는 위치 설정
            m_skill.SkillY = playerY;
        }

        public void Render()
        {
            if (m_skill.isActive)
            {
                Console.WriteLine(m_skill.isActive);
                SkillDraw();
                

                m_skill.Current = Environment.TickCount;

                if ((m_skill.sAttack || m_skill.sSkill) && m_skill.Current + 2000 > Environment.TickCount)
                {
                    ClearsSkillAndsAttack();
                }
            }
        }
        public void ClearsSkillAndsAttack()
        {
            if (m_skill.sSkill)
            {
                // sSkill 지우기                
                m_skill.isActive = false;
                m_skill.sSkill= false;
            }

            if (m_skill.sAttack)
            {
                // sAttack 지우기                
                m_skill.isActive = false;
                m_skill.sAttack= false;
            }
        }
    }
}

