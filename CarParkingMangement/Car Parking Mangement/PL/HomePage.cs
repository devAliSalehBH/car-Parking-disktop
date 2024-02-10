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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(activeForm);
            childForm.BringToFront();
            childForm.Show();

        }

        private void HomePage_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new PL.Remove_Car());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new PL.Add_Reserve());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new PL.Reports());
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            Login_Form f1 = new Login_Form();
            f1.Show();
        }

        private void HomePage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            label4.Text = DateTime.Now.ToString("T");
            label6.Text = DateTime.Now.ToString("D");
        }
    }
}
