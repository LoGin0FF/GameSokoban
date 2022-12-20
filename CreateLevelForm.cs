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
    public partial class CreateLevelForm : Form
    {
        public CreateLevelForm()
        {
            InitializeComponent();
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            string filename = "C:\\Users\\4859554\\source\\repos\\GameSokobanFinal\\GameSokobanFinal\\bin\\Debug\\Levels\\MyLevel.dat";
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(textBox.Text);
            sw.Close();
            fs.Close();
        }
        private void PressTextBox(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 'X' && e.KeyChar != 'P' && e.KeyChar != 'C' && e.KeyChar != 'E' && e.KeyChar != (char)Keys.Enter && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
            }
        }
        private void ButtonLevel_4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
