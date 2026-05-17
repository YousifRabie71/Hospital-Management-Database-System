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
    public partial class Labs : Form
    {
        public Labs()
        {
            InitializeComponent();
        }

        private void LabData()
        {
            string query = "select * from lab";
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


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int LabID = int.Parse(textBox1.Text);
            string LabManager = textBox2.Text;
            string LabWorknights = textBox3.Text;
            int DoctorID = int.Parse(textBox4.Text);

            string query = "insert into lab (LabID, LabManager, LabWorknights, DoctorID) " +
                           "values (@LabID, @LabManager, @LabWorknights, @DoctorID)";

            using (MySqlConnection conn = new DatabaseConnention().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LabID", LabID);
                    cmd.Parameters.AddWithValue("@LabManager", LabManager);
                    cmd.Parameters.AddWithValue("@LabWorknights", LabWorknights);
                    cmd.Parameters.AddWithValue("@DoctorID", DoctorID);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Lab record inserted successfully");
            LabData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int LabID = int.Parse(textBox1.Text);
            string LabManager = textBox2.Text;
            string LabWorknights = textBox3.Text;
            int DoctorID = int.Parse(textBox4.Text);

            string query = "update lab set LabManager=@LabManager, LabWorknights=@LabWorknights, DoctorID=@DoctorID " +
                           "where LabID=@LabID";

            using (MySqlConnection conn = new DatabaseConnention().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LabID", LabID);
                    cmd.Parameters.AddWithValue("@LabManager", LabManager);
                    cmd.Parameters.AddWithValue("@LabWorknights", LabWorknights);
                    cmd.Parameters.AddWithValue("@DoctorID", DoctorID);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Lab record updated successfully");
            LabData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int LabID = int.Parse(textBox1.Text);

            string query = "delete from lab where LabID=@LabID";

            using (MySqlConnection conn = new DatabaseConnention().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LabID", LabID);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Lab record deleted successfully");
            LabData();
        }

        private void Labs_Load(object sender, EventArgs e)
        {
            LabData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Homepage home = new Homepage();
            home.Show();
            this.Hide();
        }
    }
}
