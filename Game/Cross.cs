using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSokobanFinal.Game
{
    class Cross
    {
        #region [Fields]
        public int x;
        public int y;
        const int size = 50;

        public Image crossImage;
        private string stringImage = "C:\\Users\\4859554\\source\\repos\\GameSokobanFinal\\GameSokobanFinal\\bin\\Debug\\Image\\ChristmasTreeWhite.png";
        #endregion
        public Cross(int x, int y)
        {
            crossImage = new Bitmap(stringImage);
            this.x = x;
            this.y = y;
        }
    }
}
