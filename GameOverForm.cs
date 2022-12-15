using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameSokobanFinal.Game;

namespace GameSokobanFinal
{
    public partial class GameOverForm : Form
    {
        public GameOverForm(ref int count_Move)
        {
            InitializeComponent();
            labelCountMove.Text = "Ты прошел уровень за " + count_Move + " шагов!";
        }

        private void buttonNextLevel_Click(object sender, EventArgs e)
        {
            this.Close();
            LevelMenu gameform = new LevelMenu();
            gameform.Show();
        }
    }
}
