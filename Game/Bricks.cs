using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSokobanFinal.Game
{
    class Bricks
    {
        #region [Fields]
        public int x;
        public int y;
        private const int size = 50;

        public Image bricksImage;
        private string stringImage = "C:\\Users\\4859554\\source\\repos\\GameSokobanFinal\\GameSokobanFinal\\bin\\Debug\\Image\\ChristmasTree.png";
        #endregion
        public Bricks(int x, int y)
        {
            bricksImage = new Bitmap(stringImage);
            this.x = x;
            this.y = y;
        }
        public void Move(int dirX, int dirY)
        {
            int xTemp = x + dirX;
            int yTemp = y + dirY;
            if (xTemp <= 1200 && xTemp >= 0)
                x += dirX;
            if (yTemp <= 850 && yTemp >= 0)
                y += dirY;
        }
    }
}
