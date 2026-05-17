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
    public partial class Accounting : Form
    {
        public Accounting()
        {
            InitializeComponent();
        }

        private void AccountingData()
        {
            string query = "select * from accounting";
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
        private void Accounting_Load(object sender, EventArgs e)
        {
            AccountingData();
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
            int AccID = int.Parse(textBox1.Text);
            string AccountantName = textBox2.Text;
            int AccountantWorknights = int.Parse(textBox3.Text);
            string AcountantEmail = textBox4.Text;

            string query = "insert into accounting (AccID, AccountantName, AccountantWorknights, AcountantEmail) " +
                           "values (@AccID, @AccountantName, @AccountantWorknights, @AcountantEmail)";

            using (MySqlConnection conn = new DatabaseConnention().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AccID", AccID);
                    cmd.Parameters.AddWithValue("@AccountantName", AccountantName);
                    cmd.Parameters.AddWithValue("@AccountantWorknights", AccountantWorknights);
                    cmd.Parameters.AddWithValue("@AcountantEmail", AcountantEmail);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Accounting record inserted successfully");
            AccountingData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int AccID = int.Parse(textBox1.Text);
            string AccountantName = textBox2.Text;
            int AccountantWorknights = int.Parse(textBox3.Text);
            string AcountantEmail = textBox4.Text;

            string query = "update accounting set AccountantName=@AccountantName, " +
                           "AccountantWorknights=@AccountantWorknights, AcountantEmail=@AcountantEmail " +
                           "where AccID=@AccID";

            using (MySqlConnection conn = new DatabaseConnention().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AccID", AccID);
                    cmd.Parameters.AddWithValue("@AccountantName", AccountantName);
                    cmd.Parameters.AddWithValue("@AccountantWorknights", AccountantWorknights);
                    cmd.Parameters.AddWithValue("@AcountantEmail", AcountantEmail);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Accounting record updated successfully");
            AccountingData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int AccID = int.Parse(textBox1.Text);

            string query = "delete from accounting where AccID=@AccID";

            using (MySqlConnection conn = new DatabaseConnention().GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AccID", AccID);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Accounting record deleted successfully");
            AccountingData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Homepage home = new Homepage();
            home.Show();
            this.Hide();
        }
    }
}
