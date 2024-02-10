using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace Car_Parking_Mangement.PL
{
    public partial class Remove_Car : Form
    {
        BL.Remove_RevCars_Cs RE = new BL.Remove_RevCars_Cs();
        public Remove_Car()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

          

        }

        private void Remove_Car_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string Information = "";
                List<string> Info = RE.Remove_ResevedCar(int.Parse(textBox2.Text));
                foreach (var item in Info)
                {
                    Information += (item + "\n");
                }
                MessageBox.Show(Information);
        



            }
            catch
            {
                MessageBox.Show("Inviald Code");
            }
            textBox2.Text = "";
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
