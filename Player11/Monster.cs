﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleRPG;

namespace ConsoleRPG
{
    public class Monster
    {       
        public int Hp { get; private set; }
        public int monsterdamage = 20;
        public string Name { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public string[] Symbol { get; private set; }
        //public int Speed { get; private set; }

       
        public static string[] monsterStr =
        {
           "o  o /￣＼",
            " )( ｜＠ ｜",
           " 〓〓〓〓",
        };

        public static string[] monsterStr2 =
        {
           " /￣＼  o  o",    
           "｜＠ ｜ )( ",
           "  〓〓〓〓",
        };

        private int prevX;
        private int prevY;
        bool dir = true;
        private bool isJumping = false;
        //private int jumpDistance = 0;
        private int jumpHeight = 3; // 몬스터의 점프 높이 설정
        private int initialY; // 몬스터의 초기 Y 좌표
        public Monster(string name, int x, int y, int speed, int Hp)  //string[] symbol
        {
            Name = name;
            X = x;
            Y = y;
            //Symbol = symbol;
            //Speed = speed;
            initialY = y;
            this.Hp = Hp;
        }

        public Monster getinfo()
        {
            return this;
        }

        public void SetDamage(int iAttack) {Hp -= iAttack;}
      
        public void DirectionSet(Player player)
        {
            if(player.playerX > X)
            {                
                dir = false;
            }
            else
            {               
                dir   = true;
            }
        }
       
        public void Render()
        {
            if(Hp > 0 && dir)
            {
                
                Console.SetCursorPosition(X, Y);
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine(monsterStr[j]);                   
                    Console.SetCursorPosition(X, Y + j + 1);
                }
                Console.SetCursorPosition(X-2, Y + 3);
                Console.WriteLine("몬스터 체력 : " + Hp);
            }
            else if(Hp > 0 && dir ==false)
            {
                Console.SetCursorPosition(X, Y);
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine(monsterStr2[j]);  //Symbol[j]
                    Console.SetCursorPosition(X, Y + j + 1);
                }
                Console.SetCursorPosition(X-2, Y + 3);
                Console.WriteLine("몬스터 체력 : " + Hp);
            }
        }
        
        public void JumpToPlayer(Player player)
        {
             int playerX = player.playerX;
             int playerFootPosition = player.GetPlayerFootPosition();

            if (playerX == X && Hp >0 && player.GetINFO().pHp >0) //플레이어나 몬스터가 죽으면 공격 멈춤
            {
                Jump();
                if (player.playerY == Y)
                {
                  player.SetDamage(this.monsterdamage); //몬스터랑 플레이어랑 좌표 같으면 플레이어 체력-20
                }
            }
            else
            {
                Y = initialY;
                JumpOX = true;

                prevX = X;
                prevY = Y;

                int DesX = Math.Abs(X - playerX);

                if (DesX < 15)
                {

                    if (playerX < X)
                    {
                        X--;
                        if(X < 3)
                        {
                            X = 3;
                        }
                        else if(X > 145)
                        {
                            X = 145;
                        }
                        // Thread.Sleep(100);
                    }
                    else if (playerX > X)
                    {
                        X++;
                        //Thread.Sleep(100);
                    }

                }
                /*if (playerFootPosition < Y)
                    Y--;
                else if (playerFootPosition > Y)
                    Y++;*/
            }
        }

        public bool JumpOX = true;
        public void Jump()
        {

            if (JumpOX)
            {
                Y--;
                JumpOX = false;
            }
            else
            {
                Y++;
                JumpOX = true;
            }
            //if (isJumping)
            //{
                
            //}
        }
        
        public void Progress(Player player)
        {
            DirectionSet(player);
            JumpToPlayer(player);

            // 나머지 로직을 추가로 처리
            // ...
        }

        
        public void PrintLocation()
        {
            Console.WriteLine($"Monster X: {X}, Y: {Y}");
        }
    }

}
