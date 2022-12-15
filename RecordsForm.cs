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
    public partial class RecordsForm : Form
    {
        public RecordsForm()
        {
            InitializeComponent();
            if (File.Exists("records.dat"))
            {
                using (BinaryReader read = new BinaryReader(File.Open("records.dat", FileMode.Open)))
                {
                    int Text = read.ReadInt32();
                    labelRecords.Text = "Топ (кол-во шагов): \n" + Text;
                }
            }
        }

        private void buttonExitRecords_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
