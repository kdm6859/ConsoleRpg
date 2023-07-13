using ConsoleRPG;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    //스킬 정보 저장하는 클래스
    public class Skill
    {
        public int SkillAtaack; //스킬 공격력

        public int SkillX;    //스킬 좌표
        public int SkillY;

        public bool dir;


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
            SkillAtaack = player.GetINFO().pAttack; //스킬 데미지
            dir = true;
            lAttack = false;
            lSkill = false;
            sSkill = false;
            sAttack = false;
        }

        public Skill()
        {
        }

          
    }
}


