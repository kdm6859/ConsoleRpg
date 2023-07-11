using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TeamRPG
{
    internal class Skill
    {
        public int nAttack;   //스킬 공격력
        public int SkillAtaack;

        public int SkillX;    //스킬 좌표
        public int SkillY;

        public bool isActive; //스킬 준비상태

        public bool lAttack;  // 원거리 노말 공격
        public bool lSkill;   //원거리 스킬 공격
        public bool sSkill;   //근거리 노말공격
        public bool sAttack;  //근거리 스킬 공격

        Player m_player = new Player();

        public Skill()
        {
            SkillX = 0;
            SkillY = 0;
            isActive = false;
        }
        public void Activate(int playerX, int playerY)
        {
            SkillX = playerX + 5; //스킬 발사되는 위치 설정
            SkillY = playerY;
            isActive = true;
        }
        public void Progress()
        {
            if (isActive)
            {
                SkillX += 1;

                if (m_player.sWeapon)
                {
                    SkillX = m_player.playerX + 5;
                }

                if (SkillX > 145)
                {
                    isActive = false;
                }
            }
        }
        public void lSkillDraw()
        {
            if (lSkill) //원거리 스킬공격
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
                Console.SetCursorPosition(SkillX, SkillY + 1);
                Console.Write("★");
            }


            if (sSkill) //근거리 스킬공격
            {
                string[] sMagic = new string[] { "->", "->->", "->->->" };


                for (int i = 0; i < sMagic.Length; i++)
                {
                    Console.SetCursorPosition(SkillX, SkillY + i);
                    Console.WriteLine(sMagic[i]);
                }

            }
            if (sAttack)  //근거리 일반공격
            {
                Console.SetCursorPosition(SkillX, SkillY + 1);
                Console.Write("-->");
            }
        }

        public void sSkillDraw()
        {

        }
        public void Render()
        {
            if (isActive)
            {
                lSkillDraw();
            }
        }
        public void Skillinfo()
        {

        }

    }

}
