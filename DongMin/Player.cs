using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleRpg
{
    public class Player
    {
        INVENPANEL inv = null;
        ShortSkill shortSkill = null;
        LongSkill[] longSkills = null;
        Skill skill = null;
        INFO m_player = null;      
        
        public SensingArea playerArea = null;

        public int playerX;
        public int playerY;

        bool isJumping = false;
        bool isLanding = true;
        int jumpUpCount = 6;
        int jumpDownCount = 6;

        public bool sWeapon = false; //근접 무기
        public bool lWeapon = false; //원거리 무기

        int skillIndex = 0;

        public Skill getSkill()
        {
            return this.skill;
        }
        public void SetDamage(int iAttack) { m_player.pHp -= iAttack; } //데미지 받는 함수

        public void SetEXP(int exp)  //경험치 받아서 플레이어 레벨 올림
        {
            m_player.pEXP += exp;

            if (m_player.pEXP >= 100)
            {
                m_player.pLevel += 1;   //경험치100되면 레벨 1증가
                m_player.pMp = m_player.MaxMp;     //레벨 오르면 mp,hp 100으로 초기화
                m_player.pHp = m_player.MaxHp;
                m_player.pAttack += 10; //레벨 오르면 공격력 10증가
                m_player.pEXP = 0;      //레벨 오르면 경험치 0으로 초기화
            }
        }

        public INFO GetINFO() { return m_player; } //플레이어 정보


        public void Initailize()
        {
            longSkills = new LongSkill[100];           
            m_player = new INFO();
            m_player.pLevel = 1;
            m_player.pEXP = 0;

            inv = new INVENPANEL(this);
            skill = new Skill(this);
            shortSkill = new ShortSkill(this, skill);

            

            playerX = 0;  //플레이어 처음 x좌표
            playerY = 27; //플레이어 처음 y좌표

            playerArea = new SensingArea(new int[] { 4 }, new int[] { 4 },
                new Position[] { new Position(playerX, playerY) });

            Select();
            skill.SkillAttack = m_player.pAttack;
           

            for (int i = 0; i < longSkills.Length; i++)
            {
                longSkills[i] = new LongSkill(this, skill);
                longSkills[i].GetINFO().SkillX = playerX;
                longSkills[i].GetINFO().SkillY = playerY;
                longSkills[i].GetINFO().isActive = false;
            }

        }
        public void Select() //직업 선택
        {


            Console.WriteLine("직업을 선택하시오 1.전사 2.마법사");

            int Input;
            Input = int.Parse(Console.ReadLine());

            switch (Input)
            {
                case 1:
                    m_player.pName = "전사";
                    m_player.pHp = 100;
                    m_player.pMp = 100;
                    m_player.pAttack = 100;
                    m_player.MaxHp = 100;
                    m_player.MaxMp = 100;
                    sWeapon = true;
                    break;
                case 2:
                    m_player.pName = "마법사";
                    m_player.pHp = 80;
                    m_player.pMp = 120;
                    m_player.pAttack = 120;
                    m_player.MaxHp = 80;
                    m_player.MaxMp = 120;
                    lWeapon = true;
                    break;
            }
        }
        public void Progress(Monster m_monster)
        {
            
            KeySensing();
          
            Jump();
            shortSkill.Progress(m_monster);
            
            for (int i = 0; i < longSkills.Length; i++)
            {
                longSkills[i].Progress();  //스킬 나가는 좌표                   
            }
            

            if (playerX < 0) //플레이어 x좌 0 밑으로 가면 x좌표 초기화
            {
                playerX = 0;
            }
            if (playerX > 145)
            {
                playerX = 145;
            }

            playerArea.positions[0].x = playerX;
            playerArea.positions[0].y = playerY;

        }
        public void Render()
        {
            if (m_player.pHp > 0)
            {
                DrawPlayer();  //플레이어 출력
                shortSkill.Render();

               /* for (int i = 0; i < longSkills.Length; i++)  // 스킬 출력
                {
                    longSkills[i].Render();                 
                }*/
            }

        }
        public void DrawPlayer() //플레이어 그리기
        {
            string[] player = new string[]
            {
                "  ● ",
                "↙┃ ↘",
                " ┃ ┃",
                " ┘ └",
            };

            for (int i = 0; i < player.Length; i++)
            {
                Console.SetCursorPosition(playerX, playerY + i);
                Console.WriteLine(player[i]);
            }
        }
       
        public int GetPlayerFootPosition()
        {
            return playerY + 1;
        }

        public void Jump()
        {
            isLanding = ObjectManager.Instance().isLanding;

            if (isJumping)
            {
                if (jumpUpCount > 0)
                {
                    playerY -= 1;
                    jumpUpCount--;
                }
                else
                {
                    jumpUpCount = 6;
                    isJumping = false;
                }
            }

            if (!isLanding && !isJumping)
            {
                playerY += 1;
            }
        }

        //public void Jump()
        //{
        //    if (isJumping)
        //    {
        //        if (jumpUpCount > 0)
        //        {
        //            playerY -= 1;
        //            jumpUpCount--;
        //        }
        //        else if (jumpDownCount > 0)
        //        {
        //            playerY += 1;
        //            jumpDownCount--;
        //        }
        //        else
        //        {
        //            isJumping = false;
        //            jumpUpCount = 6;
        //            jumpDownCount = 6;
        //        }
        //    }
        //}

        public void KeySensing()
        {
            
            if (KeyControlManager.Instance().KeyCompare(KeyControlManager.KeyState.right)) //오른쪽 키
            {
                skill.dir = true;
                playerX += 3;
            }
            else if (KeyControlManager.Instance().KeyCompare(KeyControlManager.KeyState.left)) //왼쪽 키
            {
                skill.dir = false;
                playerX -= 3;
            }
            else if (KeyControlManager.Instance().KeyCompare(KeyControlManager.KeyState.spaceBar)) //스페이스바
            {
                if (isLanding)
                {
                    isJumping = true;
                }
            }
            else if (KeyControlManager.Instance().KeyCompare(KeyControlManager.KeyState.z)) //z
            {
                if (lWeapon) // 지팡이 트루일떄
                {
                    for (skillIndex = 0; skillIndex < 100; skillIndex++)
                    {
                        longSkills[skillIndex].GetINFO().lAttack = true;
                        longSkills[skillIndex].Activate(playerX, playerY);
                    }
                }
                if (sWeapon) //근접무기 트루일떄
                {
                    shortSkill.GetINFO().sAttack = true;
                    shortSkill.Activate(playerX, playerY);
                    shortSkill.GetINFO().SkillAttack = m_player.pAttack;
                }
            }
            else if (KeyControlManager.Instance().KeyCompare(KeyControlManager.KeyState.x)) //x
            {
                if (lWeapon) //지팡이 트루일 때
                {
                    for (skillIndex = 0; skillIndex < 100; skillIndex++)
                    {
                        longSkills[skillIndex].GetINFO().lSkill = true;
                        longSkills[skillIndex].Activate(playerX, playerY);
                        longSkills[skillIndex].GetINFO().SkillAttack = m_player.pAttack * 2;
                        m_player.pMp -= 10;
                    }
                }
                if (sWeapon && m_player.pMp >= 10) //근접 트루일 떄
                {
                    shortSkill.GetINFO().sSkill = true;
                    shortSkill.Activate(playerX, playerY);
                    shortSkill.GetINFO().SkillAttack = m_player.pAttack * 2;
                    m_player.pMp -= 10;
                }
            }
        }
    }
}


