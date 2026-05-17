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
    public partial class Departments : Form
    {
        public Departments()
        {
            InitializeComponent();
        }

        private void DepartmentData()
        {
            string query = "select * from department";
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

        private void label3_Click(object sender, EventArgs e)
        {

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

        private void Departments_Load(object sender, EventArgs e)
        {
            DepartmentData();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int DepaID = int.Parse(textBox1.Text);
            string DepaName = textBox2.Text;
            string DepaHead = textBox3.Text;

            string query = "insert into department (DepaID, DepaName, DepaHead) " +
                           "values (@DepaID, @DepaName, @DepaHead)";

            using (MySqlConnection conn = new DatabaseConnention().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DepaID", DepaID);
                    cmd.Parameters.AddWithValue("@DepaName", DepaName);
                    cmd.Parameters.AddWithValue("@DepaHead", DepaHead);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Department record inserted successfully");
            DepartmentData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int DepaID = int.Parse(textBox1.Text);
            string DepaName = textBox2.Text;
            string DepaHead = textBox3.Text;

            string query = "update department set DepaName=@DepaName, DepaHead=@DepaHead " +
                           "where DepaID=@DepaID";

            using (MySqlConnection conn = new DatabaseConnention().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DepaID", DepaID);
                    cmd.Parameters.AddWithValue("@DepaName", DepaName);
                    cmd.Parameters.AddWithValue("@DepaHead", DepaHead);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Department record updated successfully");
            DepartmentData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int DepaID = int.Parse(textBox1.Text);

            string query = "delete from department where DepaID=@DepaID";

            using (MySqlConnection conn = new DatabaseConnention().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DepaID", DepaID);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Department record deleted successfully");
            DepartmentData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Homepage home = new Homepage();
            home.Show();
            this.Hide();
        }
    }
}
