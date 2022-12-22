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

namespace GameSokobanFinal
{
    public partial class RecordsForm : Form
    {
        static string path = Path.GetFullPath(Environment.CurrentDirectory);
        static string dataBaseName = "data.mdf";
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=" + path + @"\" + dataBaseName + "; Integrated Security=True;";
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

        public void AddCurrentScores()
        {
            string filename = "recordsNew.dat";
            int Level = 0;
            string Name = "User";
            int Scores = 0;

            using (BinaryReader read = new BinaryReader(File.Open(filename, FileMode.Open)))
            {
                while (read.PeekChar() != -1)
                {
                    Name = read.ReadString();
                    Level = read.ReadInt32();
                    Scores = read.ReadInt32();
                }
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
    }
}
