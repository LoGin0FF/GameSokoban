using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSokobanFinal.Game
{
    class Wall
    {
        #region [Fields]
        public int x;
        public int y;

        public Image wallImage;
        private readonly string stringImage = "C:\\Users\\4859554\\source\\repos\\GameSokobanFinal\\GameSokobanFinal\\bin\\Debug\\Image\\Snowdrift.png";
        #endregion
        public Wall(int x, int y)
        {
            wallImage = new Bitmap(stringImage);
            this.x = x;
            this.y = y;
        }
    }
}
