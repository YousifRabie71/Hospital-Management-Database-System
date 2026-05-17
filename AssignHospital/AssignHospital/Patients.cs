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
    public partial class Patients : Form
    {
        public Patients()
        {
            InitializeComponent();
        }


        private void Patientdata()
        {
            string query = "select * from patient";
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

        private void Patients_Load(object sender, EventArgs e)
        {
            Patientdata();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int PatientID = int.Parse(textBox1.Text);
            string PatientName = textBox2.Text;
            string PatientTelphone = textBox3.Text;
            string PatientAddress = textBox4.Text;
            int PatientAge = int.Parse(textBox5.Text);
            string PatientGender = textBox6.Text;
            string PatientBloodgrp = textBox7.Text;
            int DeparmentID = int.Parse(textBox8.Text);
            int DoctorID = int.Parse(textBox9.Text);
            int RoomID = int.Parse(textBox10.Text);
            int NurseID = int.Parse(textBox11.Text);

            string query = "insert into patient (PatientID, PatientName, PatientTelphone, PatientAddress, PatientAge, PatientGender, PatientBloodgrp, DeparmentID, DoctorID, RoomID, NurseID) " +
                           "values (@PatientID, @PatientName, @PatientTelphone, @PatientAddress, @PatientAge, @PatientGender, @PatientBloodgrp, @DeparmentID, @DoctorID, @RoomID, @NurseID)";

            using (MySqlConnection conn = new DatabaseConnention().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientID", PatientID);
                    cmd.Parameters.AddWithValue("@PatientName", PatientName);
                    cmd.Parameters.AddWithValue("@PatientTelphone", PatientTelphone);
                    cmd.Parameters.AddWithValue("@PatientAddress", PatientAddress);
                    cmd.Parameters.AddWithValue("@PatientAge", PatientAge);
                    cmd.Parameters.AddWithValue("@PatientGender", PatientGender);
                    cmd.Parameters.AddWithValue("@PatientBloodgrp", PatientBloodgrp);
                    cmd.Parameters.AddWithValue("@DeparmentID", DeparmentID);
                    cmd.Parameters.AddWithValue("@DoctorID", DoctorID);
                    cmd.Parameters.AddWithValue("@RoomID", RoomID);
                    cmd.Parameters.AddWithValue("@NurseID", NurseID);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Patient record inserted successfully");
            Patientdata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int PatientID = int.Parse(textBox1.Text);
            string PatientName = textBox2.Text;
            string PatientTelphone = textBox3.Text;
            string PatientAddress = textBox4.Text;
            int PatientAge = int.Parse(textBox5.Text);
            string PatientGender = textBox6.Text;
            string PatientBloodgrp = textBox7.Text;
            int DeparmentID = int.Parse(textBox8.Text);
            int DoctorID = int.Parse(textBox9.Text);
            int RoomID = int.Parse(textBox10.Text);
            int NurseID = int.Parse(textBox11.Text);

            string query = "update patient set PatientName=@PatientName, PatientTelphone=@PatientTelphone, PatientAddress=@PatientAddress, " +
                           "PatientAge=@PatientAge, PatientGender=@PatientGender, PatientBloodgrp=@PatientBloodgrp, DeparmentID=@DeparmentID, " +
                           "DoctorID=@DoctorID, RoomID=@RoomID, NurseID=@NurseID where PatientID=@PatientID";

            using (MySqlConnection conn = new DatabaseConnention().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientID", PatientID);
                    cmd.Parameters.AddWithValue("@PatientName", PatientName);
                    cmd.Parameters.AddWithValue("@PatientTelphone", PatientTelphone);
                    cmd.Parameters.AddWithValue("@PatientAddress", PatientAddress);
                    cmd.Parameters.AddWithValue("@PatientAge", PatientAge);
                    cmd.Parameters.AddWithValue("@PatientGender", PatientGender);
                    cmd.Parameters.AddWithValue("@PatientBloodgrp", PatientBloodgrp);
                    cmd.Parameters.AddWithValue("@DeparmentID", DeparmentID);
                    cmd.Parameters.AddWithValue("@DoctorID", DoctorID);
                    cmd.Parameters.AddWithValue("@RoomID", RoomID);
                    cmd.Parameters.AddWithValue("@NurseID", NurseID);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Patient record updated successfully");
            Patientdata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int PatientID = int.Parse(textBox1.Text);

            string query = "delete from patient where PatientID=@PatientID";

            using (MySqlConnection conn = new DatabaseConnention().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PatientID", PatientID);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Patient record deleted successfully");
            Patientdata();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Homepage home = new Homepage();
            home.Show();
            this.Hide();
        }
    }
}
