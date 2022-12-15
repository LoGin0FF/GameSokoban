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
    public partial class GameForm : Form
    {
        const string GitHub = "GitHub Hello";
        const int size = 50;
        List<Player> player = new List<Player>();
        List<Bricks> bricks = new List<Bricks>();
        List<Wall> wall = new List<Wall>();
        List<Cross> cross = new List<Cross>();
        public int count_Move = 0; //кол-во ходов (для рекордов)
        public char rememberMove = 'N';
        public int rememberBricks = -1;
        public bool CanBack = false;
        bool flag = false;
        int countFlag = 0;
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

            foreach (var p in player)
            {
                graphics.DrawImage(p.playerImage, p.x, p.y, size, size); //двигаемый объект
            }
            foreach (var w in wall)
            {
                graphics.DrawImage(w.wallImage, w.x, w.y, size, size); //двигаемый объект
            }
            foreach (var c in cross)
            {
                graphics.DrawImage(c.crossImage, c.x, c.y, size, size); //двигаемый объект
            }
            foreach (var b in bricks)
            {
                graphics.DrawImage(b.bricksImage, b.x, b.y, size, size); //двигаемый объект
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
                        if (player[0].Move(0, -50, bricks[W], wall))
                        {
                            Movement(ref count_Move, 1);
                            rememberMove = 'S';
                            rememberBricks = W;
                            CanBack = true;
                        }
                        GameOver();
                    }
                    break;
                case Keys.Down:
                    int S = CheckMoveBox('S');
                    if (S != -1)
                    {
                        if (player[0].Move(0, 50, bricks[S], wall))
                        {
                            Movement(ref count_Move, 1);
                            rememberMove = 'W';
                            rememberBricks = S;
                            CanBack = true;
                        }
                        GameOver();
                    }
                    break;
                case Keys.Left:
                    int A = CheckMoveBox('A');
                    if (A != -1)
                    {
                        if (player[0].Move(-50, 0, bricks[A], wall))
                        {
                            Movement(ref count_Move, 1);
                            rememberMove = 'D';
                            rememberBricks = A;
                            CanBack = true;
                        }
                        GameOver();
                    }
                    break;
                case Keys.Right:
                    int D = CheckMoveBox('D');
                    if (D != -1)
                    {
                        if (player[0].Move(50, 0, bricks[D], wall))
                        {
                            Movement(ref count_Move, 1);
                            rememberMove = 'A';
                            rememberBricks = D;
                            CanBack = true;
                        }
                        GameOver();
                    }
                    break;
                case Keys.Z:
                    if (CanBack)
                    {
                        switch (rememberMove)
                        {
                            case 'W':
                                player[0].Move(0, -50);
                                if (rememberBricks != 0 && rememberBricks != -1)
                                    bricks[rememberBricks].Move(0, -50);
                                break;
                            case 'S':
                                player[0].Move(0, 50);
                                if (rememberBricks != 0 && rememberBricks != -1)
                                    bricks[rememberBricks].Move(0, 50);
                                break;
                            case 'A':
                                player[0].Move(-50, 0);
                                if (rememberBricks != 0 && rememberBricks != -1)
                                    bricks[rememberBricks].Move(-50, 0);
                                break;
                            case 'D':
                                player[0].Move(50, 0);
                                if (rememberBricks != 0 && rememberBricks != -1)
                                    bricks[rememberBricks].Move(50, 0);
                                break;
                            default: break;
                        }
                        Movement(ref count_Move, -1);
                        CanBack = false;
                        break;
                    }
                    else break;
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
                        if (player[0].y - 50 == bricks[i].y && player[0].x == bricks[i].x) //если игрок двигается "в ящик"
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
                        if (bricks[iS].y == 3000) { flagS = 2; break; };
                        if (player[0].y + 50 == bricks[iS].y && player[0].x == bricks[iS].x)
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
                        if (player[0].x - 50 == bricks[iA].x && player[0].y == bricks[iA].y)
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
                        if (bricks[iD].x == 3000) { flagD = 2; break; };
                        if (player[0].x + 50 == bricks[iD].x && player[0].y == bricks[iD].y)
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
                            player.Add(new Player(x, y));
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
                GameOverForm gameOver = new GameOverForm(ref count_Move);
                RecordLevels(ref count_Move);
                gameOver.Show();
            }
        }
        public void RecordLevels(ref int count_Move)
        {
            bool flag = false;
            string filename = "records.dat";
            if (File.Exists(filename))
            {
                using (BinaryReader read = new BinaryReader(File.Open(filename, FileMode.Open)))
                {
                    int count_Move_Ref = int.MaxValue;
                    while (read.PeekChar() != -1)
                        count_Move_Ref = read.ReadInt32();    
                    if (count_Move_Ref > count_Move) flag = true;
                }
                if (flag) using (BinaryWriter write = new BinaryWriter(File.Open(filename, FileMode.Open)))
                {
                    write.Write(count_Move);
                }
            }
        }

        public void Movement(ref int count_move, int plus)
        {
            count_Move += plus;
            CountMove.Text = "Шагов: " + count_Move;
        }
    }
}
