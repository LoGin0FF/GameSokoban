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
    public partial class FormName : Form
    {
        public string Name;
        public FormName()
        {
            InitializeComponent();
            Name = textBoxName.Text;
        }

        private void buttonOkName_Click(object sender, EventArgs e)
        {
            LevelMenu gameWindow = new LevelMenu();
            gameWindow.Show();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
