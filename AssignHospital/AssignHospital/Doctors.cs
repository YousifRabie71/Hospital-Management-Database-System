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
    public partial class Doctors : Form
    {
        public Doctors()
        {
            InitializeComponent();
        }

        private void Doctor_Load(object sender, EventArgs e)
        {
            DoctorData();
        }


        private void DoctorData()
        {
            string query = "select * from doctors";
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

        private void button1_Click(object sender, EventArgs e)
          
        {
            int DoctorID = int.Parse(textBox1.Text);
            string DoctorName = textBox2.Text;
            int DoctorAge = int.Parse(textBox3.Text);
            string DoctorEmail = textBox7.Text; 
            int DoctorSalary = int.Parse(textBox4.Text);
            int DoctorOfficesHrs = int.Parse(textBox5.Text);
            int DepaID = int.Parse(textBox6.Text);


            string query = "INSERT INTO doctors (DoctorID, DoctorName, DoctorAge, DoctorEmail, DoctorSalary, DoctorOfficesHrs, DepaID) " +
               "VALUES (@DoctorID, @DoctorName, @DoctorAge, @DoctorEmail, @DoctorSalary, @DoctorOfficesHrs, @DepaID)";
            using (MySqlConnection conn = new DatabaseConnention().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DoctorID", DoctorID);
                    cmd.Parameters.AddWithValue("@DoctorName", DoctorName);
                    cmd.Parameters.AddWithValue("@DoctorAge", DoctorAge);
                    cmd.Parameters.AddWithValue("@DoctorEmail", DoctorEmail);
                    cmd.Parameters.AddWithValue("@DoctorSalary", DoctorSalary);
                    cmd.Parameters.AddWithValue("@DoctorOfficesHrs", DoctorOfficesHrs);
                    cmd.Parameters.AddWithValue("@DepaID", DepaID);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Doctor record inserted successfully");
            DoctorData();
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int DoctorID = int.Parse(textBox1.Text);

            string query = "delete from doctors where DoctorID=@DoctorID";

            using (MySqlConnection conn = new DatabaseConnention().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DoctorID", DoctorID);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Doctor record deleted successfully");
            DoctorData();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int DoctorID = int.Parse(textBox1.Text);
            string DoctorName = textBox2.Text;
            int DoctorAge = int.Parse(textBox3.Text);
            string DoctorEmail = textBox7.Text;
            int DoctorSalary = int.Parse(textBox4.Text);
            int DoctorOfficesHrs = int.Parse(textBox5.Text);
            int DepaID = int.Parse(textBox6.Text);

            string query = "update doctors set DoctorName=@DoctorName, DoctorAge=@DoctorAge, DoctorEmail=@DoctorEmail, " +
                           "DoctorSalary=@DoctorSalary, DoctorOfficesHrs=@DoctorOfficesHrs, DepaID=@DepaID where DoctorID=@DoctorID";

            using (MySqlConnection conn = new DatabaseConnention().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DoctorID", DoctorID);
                    cmd.Parameters.AddWithValue("@DoctorName", DoctorName);
                    cmd.Parameters.AddWithValue("@DoctorAge", DoctorAge);
                    cmd.Parameters.AddWithValue("@DoctorEmail", DoctorEmail);
                    cmd.Parameters.AddWithValue("@DoctorSalary", DoctorSalary);
                    cmd.Parameters.AddWithValue("@DoctorOfficesHrs", DoctorOfficesHrs);
                    cmd.Parameters.AddWithValue("@DepaID", DepaID);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Doctor record updated successfully");
            DoctorData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Homepage home = new Homepage();
            home.Show();
            this.Hide();
        }
    }
    }
    

