using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GameSokobanFinal;
namespace GameSokobanFinal.Game
{
    class Player
    {
        #region [Fields]
        public int x;
        public int y;

        public Image playerImage;
        private readonly string stringImage = "C:\\Users\\4859554\\source\\repos\\GameSokobanFinal\\GameSokobanFinal\\bin\\Debug\\Image\\FatherChristmas.png";
        #endregion
        public Player(int x, int y)
        {
            playerImage = new Bitmap(stringImage);
            this.x = x;
            this.y = y;
        }
        public bool Move(int dirX, int dirY, Bricks bricks, List<Wall> wall)
        {
            int xTemp = x + dirX;
            int yTemp = y + dirY;
            bool flag = true;
            if (xTemp <= GameForm.WIDTH && xTemp >= 0 && (xTemp != bricks.x || yTemp != bricks.y))
            {
                for (int i = 0; i < wall.Count; i++)
                {
                    if (xTemp == wall[i].x && yTemp == wall[i].y)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag) x = xTemp;
            }
            if (yTemp <= GameForm.HEIGHT && yTemp >= 0 && (xTemp != bricks.x || yTemp != bricks.y))
            {
                for (int i = 0; i < wall.Count; i++)
                {
                    if (yTemp == wall[i].y && xTemp == wall[i].x)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag) y = yTemp;
            }
            return flag;
        }

        public void Move(int dirX, int dirY)
        {
            x += dirX;
            y += dirY;
        }
    }
}