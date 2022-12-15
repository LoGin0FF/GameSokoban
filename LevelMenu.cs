using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameSokobanFinal
{
    public partial class LevelMenu : Form
    {
        public LevelMenu()
        {
            InitializeComponent();
        }
        private void ButtonLevel_1_Click(object sender, EventArgs e)
        {
            GameForm gameform = new GameForm("C:\\Users\\4859554\\source\\repos\\GameSokobanFinal\\GameSokobanFinal\\bin\\Debug\\Levels\\Level_1.dat");
            this.Close();
            gameform.Show();
        }
        private void ButtonLevel_2_Click(object sender, EventArgs e)
        {
            GameForm gameform = new GameForm("C:\\Users\\4859554\\source\\repos\\GameSokobanFinal\\GameSokobanFinal\\bin\\Debug\\Levels\\Level_2.dat");
            this.Close();
            gameform.Show();
        }
        private void ButtonLevel_3_Click(object sender, EventArgs e)
        {
            GameForm gameform = new GameForm("C:\\Users\\4859554\\source\\repos\\GameSokobanFinal\\GameSokobanFinal\\bin\\Debug\\Levels\\Level_3.dat");
            this.Close();
            gameform.Show();
        }
        private void ButtonLevel_4_Click(object sender, EventArgs e)
        {
            GameForm gameform = new GameForm("C:\\Users\\4859554\\source\\repos\\GameSokobanFinal\\GameSokobanFinal\\bin\\Debug\\Levels\\Level_4.dat");
            this.Close();
            gameform.Show();
        }
        private void ButtonMyLevel_Click(object sender, EventArgs e)
        {
            GameForm gameform = new GameForm("C:\\Users\\4859554\\source\\repos\\GameSokobanFinal\\GameSokobanFinal\\bin\\Debug\\Levels\\MyLevel.dat");
            this.Close();
            gameform.Show();
        }
        private void ButtonExit(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
