using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameSokobanFinal.Game;

namespace GameSokobanFinal
{
    struct Info
    {
        public int Count_Move; //кол-во ходов (для рекордов)
        public int Level; //запоминает уровень
        public string Name;
    }
    public partial class GameForm : Form
    {       
        const int size = 50;
        public new const int Width = 1560;
        public new const int Height = 1120;
        private readonly string LevelReference;

        Player player;
        List<Bricks> bricks = new List<Bricks>();
        List<Wall> wall = new List<Wall>();
        List<Cross> cross = new List<Cross>();
        Info info = new Info();

        bool flag = false; //для "анимации"
        int countFlag = 0;
        public GameForm(string Level, int lvl)
        {
            InitializeComponent();

            timer.Tick += new System.EventHandler(Update);

            KeyDown += new KeyEventHandler(Press);
            LevelReference = Level;
            info.Level = lvl;
            info.Name = "Kirill";

            Init(Level);
        }
        public GameForm(string Level)
        {
            InitializeComponent();

            timer.Tick += new System.EventHandler(Update);

            KeyDown += new KeyEventHandler(Press);

            Init(Level);
        }
        public void Init(string Level) //Инициализация игры, создание экземпляров класса
        {
            LoadLevels(Level);
            timer.Start();
        }
        private void OnPaint(object sender, PaintEventArgs e) //отрисовка
        {
            Graphics graphics = e.Graphics;

            graphics.DrawImage(player.playerImage, player.x, player.y, size, size); 

            foreach (var w in wall)
            {
                graphics.DrawImage(w.wallImage, w.x, w.y, size, size); 
            }
            foreach (var c in cross)
            {
                graphics.DrawImage(c.crossImage, c.x, c.y, size, size); 
            }
            foreach (var b in bricks)
            {
                graphics.DrawImage(b.bricksImage, b.x, b.y, size, size);
            }
        }

        private void Update(object sender, EventArgs e)
        {
            countFlag++;
            if (flag)
            {
                for (int i = 0; i < bricks.Count; i++)
                    bricks[i].bricksImage = new Bitmap("C:\\Users\\4859554\\source\\repos\\GameSokobanFinal\\GameSokobanFinal\\bin\\Debug\\Image\\ChristmasTree.png");
                if (countFlag > 10) { flag = false; countFlag = 0; }
            }  
            else
            {
                for (int i = 0; i < bricks.Count; i++)
                    bricks[i].bricksImage = new Bitmap("C:\\Users\\4859554\\source\\repos\\GameSokobanFinal\\GameSokobanFinal\\bin\\Debug\\Image\\CristmasTreeTwo.png");
                if (countFlag > 10) {flag = true; countFlag = 0; }
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
                    GameForm gameWindow = new GameForm(LevelReference);
                    this.Close();
                    gameWindow.Show();
                    break;
                default:
                    break;
            }
        }

        public int CheckMoveBox(char str)
        {
            int flagMove;
            switch (str)
            {
                case 'W':
                    int i;
                    int lengthWallCross = bricks.Count + wall.Count;
                    int flag = 0; //0 - ящик вообще не двигали, 1 - ящик подвинули, 2 - ящик подвинуть нельзя
                    for (i = 0; i < bricks.Count; i++) //проверка каждого ящика
                    {
                        if (player.y - 50 == bricks[i].y && player.x == bricks[i].x) //если игрок двигается "в ящик"
                        {
                            if (bricks[i].y == 0) { flag = 2; break; };
                            flagMove = 0;
                            for (int m = 0; m < bricks.Count; m++) //проверка ящика к другому ящику
                            {
                                if (bricks[i].y - 50 != bricks[m].y || bricks[m].x != bricks[i].x)
                                    flagMove++;
                                else break;
                            }
                            for (int c = 0; c < wall.Count; c++) //проверка ящика к стене
                            {
                                if (bricks[i].y - 50 != wall[c].y || wall[c].x != bricks[i].x)
                                    flagMove++;
                                else break;
                            }
                            if (flagMove == lengthWallCross)
                            {
                                bricks[i].Move(0, -50);
                                flag = 1; //ящик подвинут
                            }
                            else flag = -1;
                            break;
                        }
                    }
                    if (flag == 1) return i - 1; //возвращаем индекс ящика, который подвинули
                    else return flag;
                case 'S':
                    int iS;
                    int lengthWallCross_S = bricks.Count + wall.Count;
                    int flagS = 0;
                    for (iS = 0; iS < bricks.Count; iS++)
                    {
                        if (bricks[iS].y == Height) { flagS = 2; break; };
                        if (player.y + 50 == bricks[iS].y && player.x == bricks[iS].x)
                        {
                            flagMove = 0;
                            for (int m = 0; m < bricks.Count; m++)
                            {
                                if (bricks[iS].y + 50 != bricks[m].y || bricks[m].x != bricks[iS].x)
                                    flagMove++;
                                else break;
                            }
                            for (int c = 0; c < wall.Count; c++) //проверка ящика к стене
                            {
                                if (bricks[iS].y + 50 != wall[c].y || wall[c].x != bricks[iS].x)
                                    flagMove++;
                                else break;
                            }
                            if (flagMove == lengthWallCross_S)
                            {
                                bricks[iS].Move(0, 50);
                                flagS = 1; //ящик подвинут
                            }
                            else flagS = -1;
                        }
                    }
                    if (flagS == 1) return iS - 1; //возвращаем индекс ящика, который подвинули
                    else return flagS;
                case 'A':
                    int iA;
                    int lengthWallCross_A = bricks.Count + wall.Count;
                    int flagA = 0;
                    for (iA = 0; iA < bricks.Count; iA++)
                    {
                        if (bricks[iA].x == 0) { flagA = 2; break; };
                        if (player.x - 50 == bricks[iA].x && player.y == bricks[iA].y)
                        {
                            flagMove = 0;
                            for (int m = 0; m < bricks.Count; m++)
                            {
                                if (bricks[iA].x - 50 != bricks[m].x || bricks[m].y != bricks[iA].y)
                                    flagMove++;
                                else break;
                            }
                            for (int c = 0; c < wall.Count; c++) //проверка ящика к стене
                            {
                                if (bricks[iA].x - 50 != wall[c].x || wall[c].y != bricks[iA].y)
                                    flagMove++;
                                else break;
                            }
                            if (flagMove == lengthWallCross_A)
                            {
                                bricks[iA].Move(-50, 0);
                                flagA = 1; //ящик подвинут
                            }
                            else flagA = -1;
                        }
                    }
                    if (flagA == 1) return iA - 1; //возвращаем индекс ящика, который подвинули
                    else return flagA;
                case 'D':
                    int iD;
                    int lengthWallCross_D = bricks.Count + wall.Count;
                    int flagD = 0;
                    for (iD = 0; iD < bricks.Count; iD++)
                    {
                        if (bricks[iD].x == Width) { flagD = 2; break; };
                        if (player.x + 50 == bricks[iD].x && player.y == bricks[iD].y)
                        {
                            flagMove = 0;
                            for (int m = 0; m < bricks.Count; m++)
                            {
                                if (bricks[iD].x + 50 != bricks[m].x || bricks[m].y != bricks[iD].y)
                                    flagMove++;
                                else break;
                            }
                            for (int c = 0; c < wall.Count; c++) //проверка ящика к стене
                            {
                                if (bricks[iD].x + 50 != wall[c].x || wall[c].y != bricks[iD].y)
                                    flagMove++;
                                else break;
                            }
                            if (flagMove == lengthWallCross_D)
                            {
                                bricks[iD].Move(50, 0);
                                flagD = 1; //ящик подвинут
                            }
                            else flagD = -1;
                        }

                    }
                    if (flagD == 1) return iD - 1; //возвращаем индекс ящика, который подвинули
                    else return flagD;
            }
            return 0;
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
            if (flagWin == 1)//cross.Count)
            {
                RecordsForm rf = new RecordsForm();
                GameOverForm gameOver = new GameOverForm(ref info.Count_Move);
                RecordLevels();
                rf.AddCurrentScores();
                gameOver.Show();
            }
        }
        public void RecordLevels()
        {
            string filename = "recordsNew.dat";
            if (File.Exists(filename))
            {
                using (BinaryWriter write = new BinaryWriter(File.Open(filename, FileMode.OpenOrCreate)))
                {
                    write.Write(info.Level);
                    write.Write(info.Name);
                    write.Write(info.Count_Move);
                }
            }
        }
        public void Movement()
        {
            CountMove.Text = "Шагов: " + ++info.Count_Move;
        }
    }
}
