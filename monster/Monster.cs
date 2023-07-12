using System;
using System.Threading;

namespace TeamRPG
{

   

    public class INFO
    {
        public int pHp;
        public int pAttack;
        public string pName;
        public int pX;
        public int pY;
    }

    public class Player
    {
        Skill[] skill = null;
        public INFO m_player = null;

        public bool sWeapon = false;
        public bool lWeapon = false;

        int skillIndex = 0;

        public void Select() //직업 선택
        {
            m_player = new INFO();
            Console.WriteLine("직업을 선택하시오 1.전사 2.마법사");

            int Input = 0;
            Input = int.Parse(Console.ReadLine());

            switch (Input)
            {
                case 1:
                    m_player.pName = "전사";
                    m_player.pHp = 100;
                    m_player.pAttack = 100;
                    sWeapon = true;
                    break;
                case 2:
                    m_player.pName = "마법사";
                    m_player.pHp = 80;
                    m_player.pAttack = 120;
                    lWeapon = true;
                    break;
            }
        }

        public void Initialize()
        {
            Select();

            skill = new Skill[20];

            for (int i = 0; i < skill.Length; i++)
            {
                skill[i] = new Skill();
                skill[i].SkillX = m_player.pX + 5;
                skill[i].SkillY = m_player.pY;
                skill[i].isActive = false;
            }

            m_player.pX = 0;
            m_player.pY = Console.WindowHeight - 4; // 화면 하단에 위치하도록 조정
        }

        public void Progress()
        {
            KeyControl();

            for (int i = 0; i < skill.Length; i++)
            {
                skill[i].Progress();
            }

            if (m_player.pX < 0)
            {
                m_player.pX = 0;
            }
            if (m_player.pX > Console.WindowWidth - 2) // 화면 우측 경계에 도달하면 멈추도록 조정
            {
                m_player.pX = Console.WindowWidth - 2;
            }
        }

        public void Render()
        {
            DrawPlayer();

            for (int i = 0; i < skill.Length; i++)
            {
                skill[i].Render();
            }
        }

        private void DrawPlayer()
        {
            string[] player = new string[]
            {
                "  ●",
                "↙┃ ↘",
                " ┃ ┃",
                " ┘ └",
            };

            for (int i = 0; i < player.Length; i++)
            {
                Console.SetCursorPosition(m_player.pX, m_player.pY + i);
                Console.WriteLine(player[i]);
            }
        }

        public void KeyControl()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey pressKey = Console.ReadKey(true).Key;

                switch (pressKey)
                {
                    case ConsoleKey.RightArrow:
                        m_player.pX += 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        m_player.pX -= 1;
                        break;
                    case ConsoleKey.Spacebar:
                        if (lWeapon)
                        {
                            if (skillIndex < skill.Length && skill[skillIndex].isActive == false)
                            {
                                skill[skillIndex].sSkill = true;
                                skill[skillIndex].Activate(m_player.pX, m_player.pY);
                                skillIndex++;
                            }
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (lWeapon)
                        {
                            if (skillIndex < skill.Length && skill[skillIndex].isActive == false)
                            {
                                skill[skillIndex].sSkill = true;
                                skill[skillIndex].Activate(m_player.pX, m_player.pY);
                                skillIndex++;
                            }
                        }
                        break;
                }
            }
        }

        public int GetPlayerFootPosition()
        {
            return m_player.pY + 3; // 플레이어의 발 위치
        }
    }


    public class Skill
    {
        public int SkillX { get; set; }
        public int SkillY { get; set; }
        public bool isActive { get; set; }
        public bool nSkill { get; set; }
        public bool sSkill { get; set; }

        public Skill()
        {
            SkillX = 0;
            SkillY = 0;
            isActive = false;
            nSkill = false;
            sSkill = false;
        }

        public void Activate(int playerX, int playerY)
        {
            SkillX = playerX + 5;
            SkillY = playerY;
            isActive = true;
        }

        public void Progress()
        {
            if (isActive)
            {
                if (nSkill)
                {
                    SkillY--;
                }
                else if (sSkill)
                {
                    SkillX += 2;
                    SkillY -= 2;
                }

                if (SkillY <= 0)
                {
                    isActive = false;
                    nSkill = false;
                    sSkill = false;
                }
            }
        }

        public void Render()
        {
            if (isActive)
            {
                Console.SetCursorPosition(SkillX, SkillY);
                Console.WriteLine("*");
            }
        }
    }


    public class Monster
    {
        public string Name { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public string Symbol { get; private set; }
        //public int Speed { get; private set; }

        private int prevX;
        private int prevY;

        private bool isJumping = false;
        //private int jumpDistance = 0;
        private int jumpHeight = 3; // 몬스터의 점프 높이 설정
        private int initialY; // 몬스터의 초기 Y 좌표

        public Monster(string name, int x, int y, string symbol, int speed)
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
            Console.WriteLine(Symbol);
        }

        public void JumpToPlayer(Player player)
        {
            int playerX = player.m_player.pX;
            int playerFootPosition = player.GetPlayerFootPosition();

            if (playerX == X && playerFootPosition == Y)
            {
                Jump();
            }
            else
            {
                prevX = X;
                prevY = Y;

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
                if (playerFootPosition < Y)
                    Y--;
                else if (playerFootPosition > Y)
                    Y++;
            }
        }

        private void Jump()
        {
            if (isJumping)
            {
                Y--;

                if (Y == prevY)
                {
                    Y = initialY;
                    isJumping = false;
                }
            }
            else
            {
                if (Y > initialY - jumpHeight)
                {
                    Y--;
                    if (X > prevX)
                        X--;
                    else if (X < prevX)
                        X++;
                }
                else if (Y == initialY - jumpHeight)
                {
                    isJumping = true;
                }
            }
        }

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


    public class Program
    {
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Player player = new Player();
            player.Initialize();

            Monster monster = new Monster("Monster", 40, 29, "☆", 1); // 몬스터의 위치 조정

            Thread monsterThread = new Thread(() =>
            {
                while (true)
                {
                    monster.Progress(player);
                    Thread.Sleep(6000); // 몬스터의 이동 속도를 조절
                }
            });
            monsterThread.Start();

            while (true)
            {
                Console.Clear();
                player.Render();
                monster.Render();
                monster.PrintLocation();

                player.Progress();
                monster.Progress(player);

                Thread.Sleep(100);
            }
        }
    }
}



/*using System;
using System.Threading;

class Monster
{
    public string Name { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public char Character { get; set; }
    public int MinX { get; set; }
    public int MaxX { get; set; }
    public bool IsJumping { get; set; }
    public bool JumpFinished { get; set; }

    public Monster(string name, int x, int y, char character, int minX, int maxX)
    {
        Name = name;
        X = x;
        Y = y;
        Character = character;
        MinX = minX;
        MaxX = maxX;
        IsJumping = false;
        JumpFinished = true;
    }

    public void Jump()
    {
        if (!IsJumping && JumpFinished)
        {
            JumpFinished = false;
            int initialX = X;
            int initialY = Y;

            for (int i = 1; i <= 3; i++)
            {
                ClearLocation();
                X = initialX + i;
                Y = initialY + i;
                PrintLocation();
                Thread.Sleep(100);
            }

            for (int i = 1; i <= 2; i++)
            {
                ClearLocation();
                X = initialX + 3 + i;
                Y = initialY + 3 - i;
                PrintLocation();
                Thread.Sleep(100);
            }

            ClearLocation();
            X = initialX + 6;
            Y = initialY;
            PrintLocation();

            JumpFinished = true;
        }
    }

    public void PrintLocation()
    {
        Console.SetCursorPosition(X, Console.WindowHeight - Y - 1);
        Console.Write(Character);
    }

    public void ClearLocation()
    {
        Console.SetCursorPosition(X, Console.WindowHeight - Y - 1);
        Console.Write(' ');
    }
}

class MonsterName
{
    static void Main(string[] args)
    {
        // Create player
        Monster player = new Monster("Player", 0, 0, 'P', 0, 10);

        // Create monsters
        Monster monster1 = new Monster("Monster 1", 0, 0, 'M', 0, 10);
        Monster monster2 = new Monster("Monster 2", 9, 0, 'W', 0, 10);

        while (true)
        {
            Console.Clear();

            // Jump player
            player.Jump();

            // Print updated locations
            player.PrintLocation();
            monster1.PrintLocation();
            monster2.PrintLocation();

            Thread.Sleep(500); // Delay for better visualization

            // Move player forward
            player.X += 6;
            player.Y = 0;
        }
    }
}*/