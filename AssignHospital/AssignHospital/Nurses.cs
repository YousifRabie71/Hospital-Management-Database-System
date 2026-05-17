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
    public partial class Nurses : Form
    {
        public Nurses()
        {
            InitializeComponent();

        }


        private void NurseData()
        {
            string query = "select * from nurse";
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

        private void label7_Click(object sender, EventArgs e)
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int NurseID = int.Parse(textBox1.Text);
            string NurseName = textBox2.Text;
            int NurseAge = int.Parse(textBox3.Text);
            int NurseWorknights = int.Parse(textBox4.Text);
            int NurseSalary = int.Parse(textBox5.Text);
            int RoomID = int.Parse(textBox6.Text);

            string query = "insert into nurse (NurseID, NurseName, NurseAge, NurseWorknights, NurseSalary, RoomID) " +
                           "values (@NurseID, @NurseName, @NurseAge, @NurseWorknights, @NurseSalary, @RoomID)";

            using (MySqlConnection conn = new DatabaseConnention().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NurseID", NurseID);
                    cmd.Parameters.AddWithValue("@NurseName", NurseName);
                    cmd.Parameters.AddWithValue("@NurseAge", NurseAge);
                    cmd.Parameters.AddWithValue("@NurseWorknights", NurseWorknights);
                    cmd.Parameters.AddWithValue("@NurseSalary", NurseSalary);
                    cmd.Parameters.AddWithValue("@RoomID", RoomID);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Nurse record inserted successfully");
            NurseData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int NurseID = int.Parse(textBox1.Text);
            string NurseName = textBox2.Text;
            int NurseAge = int.Parse(textBox3.Text);
            int NurseWorknights = int.Parse(textBox4.Text);
            int NurseSalary = int.Parse(textBox5.Text);
            int RoomID = int.Parse(textBox6.Text);

            string query = "update nurse set NurseName=@NurseName, NurseAge=@NurseAge, NurseWorknights=@NurseWorknights, " +
                           "NurseSalary=@NurseSalary, RoomID=@RoomID where NurseID=@NurseID";

            using (MySqlConnection conn = new DatabaseConnention().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NurseID", NurseID);
                    cmd.Parameters.AddWithValue("@NurseName", NurseName);
                    cmd.Parameters.AddWithValue("@NurseAge", NurseAge);
                    cmd.Parameters.AddWithValue("@NurseWorknights", NurseWorknights);
                    cmd.Parameters.AddWithValue("@NurseSalary", NurseSalary);
                    cmd.Parameters.AddWithValue("@RoomID", RoomID);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Nurse record updated successfully");
            NurseData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int NurseID = int.Parse(textBox1.Text);

            string query = "delete from nurse where NurseID=@NurseID";

            using (MySqlConnection conn = new DatabaseConnention().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NurseID", NurseID);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Nurse record deleted successfully");
            NurseData();
        }

        private void Nurses_Load(object sender, EventArgs e)
        {
            NurseData();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Homepage home = new Homepage();
            home.Show();
            this.Hide();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                textBox6.Text = row.Cells[5].Value.ToString();
            }
        }
    }
}
