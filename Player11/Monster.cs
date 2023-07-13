using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRPG;

namespace ConsoleRPG
{
    public class Monster
    {
        public string Name { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public string[] Symbol { get; private set; }
        //public int Speed { get; private set; }

        public static string[] monsterStr =
        {
           "o  o /￣＼",
            " )( ｜   ｜",
           " 〓〓〓〓",
        };

        private int prevX;
        private int prevY;

        private bool isJumping = false;
        //private int jumpDistance = 0;
        private int jumpHeight = 3; // 몬스터의 점프 높이 설정
        private int initialY; // 몬스터의 초기 Y 좌표

        public Monster(string name, int x, int y, string[] symbol, int speed)
        {
            Name = name;
            X = x;
            Y = y;
            Symbol = symbol;
            //  Speed = speed;
            initialY = y;
        }

        public void Render()
        {
            Console.SetCursorPosition(X, Y);
            for (int j = 0; j < 3; j++)
            {
                Console.Write(Symbol[j]);
                Console.SetCursorPosition(X, Y+j+1);
            }
        }
        
        public void JumpToPlayer(Player player)
        {
            int playerX = player.playerX;
            int playerFootPosition = player.GetPlayerFootPosition();

            if (playerX == X)
            {
                Jump();
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

        //private void Jump()
        //{
        //    if (isJumping)
        //    {
        //        Y--;

        //        if (Y == prevY)
        //        {
        //            Y = initialY;
        //            isJumping = false;
        //        }
        //    }
        //    else
        //    {
        //        if (Y > initialY - jumpHeight)
        //        {
        //            Y--;
        //            if (X > prevX)
        //                X--;
        //            else if (X < prevX)
        //                X++;
        //        }
        //        else if (Y == initialY - jumpHeight)
        //        {
        //            isJumping = true;
        //        }
        //    }
        //}
        
        public void Progress(Player player)
        {
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
