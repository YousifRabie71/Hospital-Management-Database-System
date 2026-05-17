using AssignHospital;
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
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Appointment home = new Appointment();
            home.Show();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Doctors home = new Doctors();
            home.Show();
  

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Patients home = new Patients();
            home.Show();
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Nurses home = new Nurses();
            home.Show();
       
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Accounting home = new Accounting();
            home.Show();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Departments home = new Departments();
            home.Show();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Rooms home = new Rooms();
            home.Show();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Labs home = new Labs();
            home.Show();
      
        }


        private void Homepage_Load(object sender, EventArgs e)
        {

        }
    }
}
