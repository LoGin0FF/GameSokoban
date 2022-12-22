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
    public partial class GameMenuForm : Form
    {
        public GameMenuForm()
        {
            InitializeComponent();
        }
        private void ButtonStartGame_Click(object sender, EventArgs e)
        {
            FormInputName gameWindow = new FormInputName();
            gameWindow.Show();
        }
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ButtonHelp_Click(object sender, EventArgs e)
        {
            HelpGameMenu gameWindow = new HelpGameMenu();
            gameWindow.Show();
        }
        private void ButtonRecords_Click(object sender, EventArgs e)
        {
            RecordsForm gameWindow = new RecordsForm();
            gameWindow.Show();
        }
        private void ButtonCreateLevel_Click(object sender, EventArgs e)
        {
            CreateLevelForm gameWindow = new CreateLevelForm();
            gameWindow.Show();
        }
    }
}
