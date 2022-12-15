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
        private void ButtonNextLevel_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "GameMenuForm")
                {
                    Application.OpenForms[i].Close();
                }
            }
            LevelMenu gameform = new LevelMenu();
            gameform.Show();
        }
    }
}
