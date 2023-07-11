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
        public int nAttack;
        public int sAttack;
        public int SkillX;
        public int SkillY;
        public bool isActive;
        public bool nSkill;
        public bool sSkill;
        
        public Skill()
        {
            SkillX = 0;
            SkillY = 0;
            isActive = false;
        }
        public void Activate(int playerX, int playerY)
        {
            SkillX = playerX+5;
            SkillY = playerY;
            isActive = true;
        }
        public void Progress()
        {
            if(isActive)
            {
                SkillX += 1;
                if(SkillX > 145)
                {
                    isActive = false;
                }
            }
        }       
        public void LSkillDraw()
        {
            if(sSkill)
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
            

            if (nSkill) 
            {
                string[] nMagic = new string[] { "★" };
                for (int i = 0; i < nMagic.Length; i++)
                {
                    Console.SetCursorPosition(SkillX, SkillY+1);
                    Console.WriteLine(nMagic[i]);
                }
            }
            

        }
        public void Render()
        {
            if(isActive)
            {                                         
                LSkillDraw();
            }               
        }
        public void Skillinfo()
        {

        }
            
    }
    
}
