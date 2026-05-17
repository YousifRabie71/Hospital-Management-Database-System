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
    public partial class Appointment : Form
    {
        public Appointment()
        {
            InitializeComponent();
        }

        private void AppointmentData()
        {
            string query = "select * from appointment";
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Appointment_Load(object sender, EventArgs e)
        {
            AppointmentData();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int AppointmentID = int.Parse(textBox1.Text);
            int AppNo = int.Parse(textBox2.Text);
            DateTime AppDate = DateTime.Parse(textBox3.Text);
            int AppFees = int.Parse(textBox4.Text);
            int DoctorID = int.Parse(textBox5.Text);
            int PatientID = int.Parse(textBox6.Text);

            string query = "insert into appointment (AppointmentID, AppNo, AppDate, AppFees, DoctorID, PatientID) " +
                           "values (@AppointmentID, @AppNo, @AppDate, @AppFees, @DoctorID, @PatientID)";

            using (MySqlConnection conn = new DatabaseConnention().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AppointmentID", AppointmentID);
                    cmd.Parameters.AddWithValue("@AppNo", AppNo);
                    cmd.Parameters.AddWithValue("@AppDate", AppDate);
                    cmd.Parameters.AddWithValue("@AppFees", AppFees);
                    cmd.Parameters.AddWithValue("@DoctorID", DoctorID);
                    cmd.Parameters.AddWithValue("@PatientID", PatientID);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Appointment record inserted successfully");
            AppointmentData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int AppointmentID = int.Parse(textBox1.Text);
            int AppNo = int.Parse(textBox2.Text);
            DateTime AppDate = DateTime.Parse(textBox3.Text);
            int AppFees = int.Parse(textBox4.Text);
            int DoctorID = int.Parse(textBox5.Text);
            int PatientID = int.Parse(textBox6.Text);

            string query = "update appointment set AppNo=@AppNo, AppDate=@AppDate, AppFees=@AppFees, " +
                           "DoctorID=@DoctorID, PatientID=@PatientID where AppointmentID=@AppointmentID";

            using (MySqlConnection conn = new DatabaseConnention().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AppointmentID", AppointmentID);
                    cmd.Parameters.AddWithValue("@AppNo", AppNo);
                    cmd.Parameters.AddWithValue("@AppDate", AppDate);
                    cmd.Parameters.AddWithValue("@AppFees", AppFees);
                    cmd.Parameters.AddWithValue("@DoctorID", DoctorID);
                    cmd.Parameters.AddWithValue("@PatientID", PatientID);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Appointment record updated successfully");
            AppointmentData();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int AppointmentID = int.Parse(textBox1.Text);

            string query = "delete from appointment where AppointmentID=@AppointmentID";

            using (MySqlConnection conn = new DatabaseConnention().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AppointmentID", AppointmentID);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Appointment record deleted successfully");
            AppointmentData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Homepage home = new Homepage();
            home.Show();
            this.Hide();
        }
    }
    }


    