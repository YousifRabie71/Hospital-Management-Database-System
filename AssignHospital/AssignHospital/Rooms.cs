using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssignHospital
{
    public partial class Rooms : Form
    {
        public Rooms()
        {
            InitializeComponent();
        }

        private void RoomData()
        {
            string query = "select * from rooms";
            using (MySqlConnection conn = new DatabaseConnention().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }



        private void Rooms_Load(object sender, EventArgs e)
        {
            RoomData();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int RoomID = int.Parse(textBox1.Text);
            int RoomNo = int.Parse(textBox2.Text);
            string RoomFloor = textBox3.Text;
            int RoomSize = int.Parse(textBox4.Text);

            string query = "update rooms set RoomNo=@RoomNo, RoomFloor=@RoomFloor, RoomSize=@RoomSize " +
                           "where RoomID=@RoomID";

            using (MySqlConnection conn = new DatabaseConnention().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoomID", RoomID);
                    cmd.Parameters.AddWithValue("@RoomNo", RoomNo);
                    cmd.Parameters.AddWithValue("@RoomFloor", RoomFloor);
                    cmd.Parameters.AddWithValue("@RoomSize", RoomSize);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Room record updated successfully");
            RoomData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int RoomID = int.Parse(textBox1.Text);

            string query = "delete from rooms where RoomID=@RoomID";

            using (MySqlConnection conn = new DatabaseConnention().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoomID", RoomID);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Room record deleted successfully");
            RoomData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int RoomID = int.Parse(textBox1.Text);
            int RoomNo = int.Parse(textBox2.Text);
            string RoomFloor = textBox3.Text;
            int RoomSize = int.Parse(textBox4.Text);

            string query = "insert into rooms (RoomID, RoomNo, RoomFloor, RoomSize) " +
                           "values (@RoomID, @RoomNo, @RoomFloor, @RoomSize)";

            using (MySqlConnection conn = new DatabaseConnention().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoomID", RoomID);
                    cmd.Parameters.AddWithValue("@RoomNo", RoomNo);
                    cmd.Parameters.AddWithValue("@RoomFloor", RoomFloor);
                    cmd.Parameters.AddWithValue("@RoomSize", RoomSize);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Room record inserted successfully");
            RoomData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Homepage home = new Homepage();
            home.Show();
            this.Hide();
        }
    }
}
