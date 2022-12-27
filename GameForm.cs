using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GameSokobanFinal.Game;
using System.Text.Json;
namespace GameSokobanFinal
{
    struct Info
    {
        public int CountMove; //кол-во ходов (для рекордов)
        public int Level; //запоминает уровень
        public string Name;
    }
    public partial class GameForm : Form
    {
        Info info = new Info();

        const int SIZE = 50;
        public const int WIDTH = 1560;
        public const int HEIGHT = 1120;
        private readonly string p_LevelReference;

        Player player;
        List<Bricks> bricks = new List<Bricks>();
        List<Wall> wall = new List<Wall>();
        List<Cross> cross = new List<Cross>();

        //для "анимации"
        bool animationFlag = false; 
        int countFlag = 0;
        public GameForm(string levelStringFile, int level, string Name)
        {
            InitializeComponent();

            timer.Tick += new System.EventHandler(Update);

            KeyDown += new KeyEventHandler(Press);

            p_LevelReference = levelStringFile;
            info.Level = level;
            info.Name = Name;
            info.CountMove = 0;

            Init(levelStringFile);
        }
        public void Init(string levelStringFile) //Инициализация игры, создание экземпляров класса
        {
            LoadLevels(levelStringFile);
            timer.Start();
        }
        private void OnPaint(object sender, PaintEventArgs e) //отрисовка
        {
            Graphics graphics = e.Graphics;

            graphics.DrawImage(player.playerImage, player.x, player.y, SIZE, SIZE);

            foreach (var w in wall)
            {
                graphics.DrawImage(w.wallImage, w.x, w.y, SIZE, SIZE); 
            }
            foreach (var c in cross)
            {
                graphics.DrawImage(c.crossImage, c.x, c.y, SIZE, SIZE); 
            }
            foreach (var b in bricks)
            {
                graphics.DrawImage(b.bricksImage, b.x, b.y, SIZE, SIZE);
            }
        }

        private void Update(object sender, EventArgs e)
        {
            countFlag++;
            if (animationFlag)
            {
                for (int i = 0; i < bricks.Count; i++)
                    bricks[i].bricksImage = new Bitmap("C:\\Users\\4859554\\source\\repos\\GameSokobanFinal\\GameSokobanFinal\\bin\\Debug\\Image\\ChristmasTree.png");
                if (countFlag > 10) { animationFlag = false; countFlag = 0; }
            }  
            else
            {
                for (int i = 0; i < bricks.Count; i++)
                    bricks[i].bricksImage = new Bitmap("C:\\Users\\4859554\\source\\repos\\GameSokobanFinal\\GameSokobanFinal\\bin\\Debug\\Image\\CristmasTreeTwo.png");
                if (countFlag > 10) {animationFlag = true; countFlag = 0; }
            }

            Invalidate();
        }
        public void Press(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    int W = CheckMoveBox('W');
                    if (W != -1)
                    {
                        if (player.Move(0, -50, bricks[W], wall))
                        {
                            Movement(); 
                        }
                        GameOver();
                    }
                    break;
                case Keys.Down:
                    int S = CheckMoveBox('S');
                    if (S != -1)
                    {
                        if (player.Move(0, 50, bricks[S], wall))
                        {
                            Movement();
                        }
                        GameOver();
                    }
                    break;
                case Keys.Left:
                    int A = CheckMoveBox('A');
                    if (A != -1)
                    {
                        if (player.Move(-50, 0, bricks[A], wall))
                        {
                            Movement();
                        }
                        GameOver();
                    }
                    break;
                case Keys.Right:
                    int D = CheckMoveBox('D');
                    if (D != -1)
                    {
                        if (player.Move(50, 0, bricks[D], wall))
                        {
                            Movement();
                        }
                        GameOver();
                    }
                    break;
                case Keys.Escape:
                    GameForm gameWindow = new GameForm(p_LevelReference, info.Level, Name);
                    this.Close();
                    gameWindow.Show();
                    break;
                default:
                    break;
            }
        }

        public int CheckMoveBox(char str)
        {
            switch (str)
            {
                case 'W':
                    return CheckingBricksY(-50);
                case 'S':
                    return CheckingBricksY(50);
                case 'A':
                    return CheckingBricksX(-50);
                case 'D':
                    return CheckingBricksX(50);
            }
            return 0;
        }

        public int CheckingBricksY(int yDir)
        {
            int i;
            int flagMove;
            int lengthBricksPlusWall = bricks.Count + wall.Count;
            int flagMoveBricks = 0;
            for (i = 0; i < bricks.Count; i++)
            {
                if (bricks[i].y == HEIGHT) { flagMoveBricks = 2; break; };
                if (player.y + yDir == bricks[i].y && player.x == bricks[i].x)
                {
                    flagMove = 0;
                    for (int j = 0; j < bricks.Count; j++)
                    {
                        if (bricks[i].y + yDir != bricks[j].y || bricks[j].x != bricks[i].x)
                            flagMove++;
                        else break;
                    }
                    for (int k = 0; k < wall.Count; k++) //проверка ящика к стене
                    {
                        if (bricks[i].y + yDir != wall[k].y || wall[k].x != bricks[i].x)
                            flagMove++;
                        else break;
                    }
                    if (flagMove == lengthBricksPlusWall)
                    {
                        bricks[i].Move(0, yDir);
                        flagMoveBricks = 1; //ящик подвинут
                    }
                    else flagMoveBricks = -1;
                }
            }
            if (flagMoveBricks == 1) return i - 1; //возвращаем индекс ящика, который подвинули
            else return flagMoveBricks;
        }
        public int CheckingBricksX(int xDir)
        {
            int i;
            int flagMove;
            int lengthBricksPlusWall = bricks.Count + wall.Count;
            int flagMoveBricks = 0;
            for (i = 0; i < bricks.Count; i++)
            {
                if (bricks[i].x == WIDTH) { flagMoveBricks = 2; break; };
                if (player.x + xDir == bricks[i].x && player.y == bricks[i].y)
                {
                    flagMove = 0;
                    for (int j = 0; j < bricks.Count; j++)
                    {
                        if (bricks[i].x + xDir != bricks[j].x || bricks[j].y != bricks[i].y)
                            flagMove++;
                        else break;
                    }
                    for (int k = 0; k < wall.Count; k++) //проверка ящика к стене
                    {
                        if (bricks[i].x + xDir != wall[k].x || wall[k].y != bricks[i].y)
                            flagMove++;
                        else break;
                    }
                    if (flagMove == lengthBricksPlusWall)
                    {
                        bricks[i].Move(xDir, 0);
                        flagMoveBricks = 1; //ящик подвинут
                    }
                    else flagMoveBricks = -1;
                }
            }
            if (flagMoveBricks == 1) return i - 1; //возвращаем индекс ящика, который подвинули
            else return flagMoveBricks;
        }
        public void LoadLevels(string filename)
        {
            if (File.Exists(filename))
            {
                using (BinaryReader read = new BinaryReader(File.Open(filename, FileMode.Open)))
                {
                    int x = 0, y = 0;
                    while (read.PeekChar() != -1)
                    {
                        char r = read.ReadChar();
                        if (r == 'X')
                        {
                            wall.Add(new Wall(x, y));
                        }
                        else if (r == 'E')
                        {
                            bricks.Add(new Bricks(x, y));
                        }
                        else if (r == 'C')
                        {
                            cross.Add(new Cross(x, y));
                        }
                        else if (r == 'P')
                        {
                            player = new Player(x, y);
                        }
                        x += 50;
                        if (r == '\n')
                        {
                            y += 50;
                            x = 0;
                        }
                    }
                }
            }
        }

        public void GameOver()
        {
            int flagWin = 0;
            for (int i = 0; i < cross.Count; i++)
            {
                for (int j = 0; j < bricks.Count; j++)
                {
                    if (cross[i].x == bricks[j].x && cross[i].y == bricks[j].y)
                    {
                        flagWin++;
                        break;
                    }
                }
            }
            if (flagWin == cross.Count)
            {
                RecordsForm recordForms = new RecordsForm();
                GameOverForm gameOver = new GameOverForm(info.CountMove, info.Name, info.Level);
                RecordLevels();
                recordForms.AddCurrentScores();
                gameOver.Show();
            }
        }
        public void RecordLevels()
        {
            string filename = "recordsNew.dat";
            if (File.Exists(filename))
            {
                using (BinaryWriter write = new BinaryWriter(File.Open(filename, FileMode.Open)))
                {
                    write.Write(info.Name);
                    write.Write(info.Level);
                    write.Write(info.CountMove);
                }
            }  
        }
        public void Movement()
        {
            CountMove.Text = "Шагов: " + ++info.CountMove;
        }
    }
}
