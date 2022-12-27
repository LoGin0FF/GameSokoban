using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using static GameSokobanFinal.GameForm;

namespace GameSokobanFinal
{
    public partial class RecordsForm : Form
    {
        string password;
        static readonly string path = Path.GetFullPath(Environment.CurrentDirectory);
        static readonly string dataBaseName = "data.mdf";
        static readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=" + path + @"\" + dataBaseName + "; Integrated Security=True;";
        public RecordsForm()
        {
            InitializeComponent();
            UpdateScoreBoard();
        }
        private void ButtonExitRecords_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void UpdateScoreBoard()
        {
            string query = "SELECT * FROM scores ORDER BY Scores ASC";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);

                var ds = new DataSet();
                adapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Sort(this.dataGridView1.Columns[1], ListSortDirection.Descending);
            }
        }

        public void AddCurrentScores(string FILENAME)
        {
            string Name;
            int Level;
            int Scores;

            using (FileStream fs = new FileStream(FILENAME, FileMode.Open))
            {
                Info info2 = JsonSerializer.Deserialize<Info>(fs);
                Level = info2.Level;
                Name = info2.Name;
                Scores = info2.CountMove;
            }
            string query = "INSERT INTO scores(Date,Level,Name,Scores) VALUES(@Date,@Level,@Name,@Scores);";

            using(SqlConnection con = new SqlConnection(connectionString))
            using(SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@Level", SqlDbType.Int).Value = Level;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
                cmd.Parameters.Add("@Scores", SqlDbType.Int).Value = Scores;
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        private void ButtonDeleteRecords_Click(object sender, EventArgs e)
        {
            textBoxDelete.Show();
            dataGridView1.Visible = false;
        }
        private void TextBoxDelete_TextChanged(object sender, EventArgs e)
        {
            password = textBoxDelete.Text;
        }
        private void PressTextBox(object sender, KeyPressEventArgs e)
        {
            if (password == "Введите пароль:15052003")
            {
                string query = "DELETE FROM scores";
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                MessageBox.Show("Рекорды успешно удалены!");
                this.Close();
            }
        }
    }
}
