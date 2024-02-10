using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Parking_Mangement.PL
{
    public partial class Login_Form : Form
    {
        BL.Account log = new BL.Account();
        public Login_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
       
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Form_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable Dt = log.Login(textBox4.Text, textBox3.Text);
            if (Dt.Rows.Count > 0)
            {
                MessageBox.Show("welcome " + textBox4.Text);
                this.Hide();
                HomePage hp1 = new HomePage();
                hp1.Show();
            }
            else
                MessageBox.Show("fail login !");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
