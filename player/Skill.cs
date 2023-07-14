
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleRpg
{
    //스킬 정보 저장하는 클래스
    public class Skill
    {
        public int SkillAttack; //스킬 공격력

        public int SkillX;    //스킬 좌표
        public int SkillY;

        public bool dir;


        public bool isActive; //스킬 준비상태

        public bool lAttack;  // 원거리 노말 공격
        public bool lSkill;   //원거리 스킬 공격
        public bool sSkill;   //근거리 노말공격
        public bool sAttack;  //근거리 스킬 공격

        Player m_player = null;

        public int Current;

        public Skill(Player player)
        {
            m_player = player;

            SkillX = 0;
            SkillY = 0;
            isActive = false;
            dir = true;
            lAttack = false;
            lSkill = false;
            sSkill = false;
            sAttack = false;
            SkillAttack = m_player.GetINFO().pAttack; //스킬 데미지
        }

        public Skill()
        {
        }


    }
}


