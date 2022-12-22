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

namespace GameSokobanFinal
{
    public partial class FormInputName : Form
    {
        public new string Name;
        public FormInputName()
        {
            InitializeComponent();
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            LevelMenu gameWindow = new LevelMenu(this.Name);
            this.Close();
            gameWindow.Show();
        }

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            Name = textBoxName.Text;
            if (Name == "FormInputName") Name = "Guest";
        }

        private void PressTextBox(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                LevelMenu gameWindow = new LevelMenu(this.Name);
                this.Close();
                gameWindow.Show();
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
