using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public class ShortSkill
    {
        Player m_player = null;
        Skill m_skill = null;
        /*Monster m_monster = null;*/
        
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
                        Console.SetCursorPosition(m_skill.SkillX - 7, m_skill.SkillY + i);
                        Console.WriteLine(sMagic[i]);
                    }
                }


            }
            if (m_skill.sAttack)  //근거리 일반공격
            {
                if (m_player.getSkill().dir)
                {
                    Console.WriteLine(m_skill.SkillX);
                    Console.SetCursorPosition(m_skill.SkillX + 3, m_skill.SkillY + 1); 
                    Console.Write("--->");
                }
                else
                {
                    Console.SetCursorPosition(m_skill.SkillX-3, m_skill.SkillY + 1);  
                    Console.Write("<---");
                }
                
            }
        }
        public void Progress(Monster m_monster)
        {
            

            if (m_player.sWeapon && m_skill.dir) //근거리 무기 true일 떄
            {
                //스킬 플레이어 x좌표 앞에서 생성
                m_skill.SkillX = m_player.playerX + 5;
                
                if (m_monster.X - m_skill.SkillX+5<=20 && m_skill.sSkill && m_monster.Hp > 0
                    &&m_monster.Y == m_skill.SkillY+1)  // 스킬과 몬스터 거리 20이하일 때 데미지
                {
                    m_monster.SetDamage(m_skill.SkillAttack);
                }
                if(m_monster.X - m_skill.SkillX + 5 <= 15 && m_skill.sAttack && m_monster.Hp > 0
                    && m_monster.Y == m_skill.SkillY+1) //일반공격과 몬스터 거리 15이하일 때 데미지
                {
                    m_monster.SetDamage(m_player.GetINFO().pAttack);
                }
                
            }
            else if (m_player.sWeapon && m_skill.dir == false && m_player.playerX > m_monster.X)
            {
                m_skill.SkillX = m_player.playerX - 3;

                if (m_monster.X+8 - m_skill.SkillX + 3 >= -8 && m_skill.sSkill && m_monster.Hp>0
                    && m_monster.Y == m_skill.SkillY + 1) //왼쪽 스킬공격
                {
                    m_monster.SetDamage(m_skill.SkillAttack);
                }
                if (m_monster.X+8 - m_skill.SkillX + 3 >= -4 && m_skill.sAttack && m_monster.Hp > 0
                    && m_monster.Y == m_skill.SkillY + 1) //왼쪽 공격
                {
                    m_monster.SetDamage(m_player.GetINFO().pAttack);
                }
            }

            if (m_skill.SkillX > 145) //x좌표 한계 넘어가면 초기화
            {
                m_skill.SkillX = 145;
            }
            else if (m_skill.SkillX < 0)
            {
                m_skill.SkillX = 0;
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

