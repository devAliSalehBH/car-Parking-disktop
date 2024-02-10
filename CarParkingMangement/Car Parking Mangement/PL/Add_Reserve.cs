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
    public partial class Add_Reserve : Form
    {
        BL.Add__Reserve AD = new BL.Add__Reserve();
        
        public Add_Reserve()
        {
            InitializeComponent();
        }

        private void Add_Reserve_Load(object sender, EventArgs e)
        {
            DAL.DataAccessLayer Dt = new DAL.DataAccessLayer();

            DataTable dt1 =  Dt.SelectData("select Cname from CarCompany");

            comboBox1.DataSource = dt1;
            comboBox1.DisplayMember = "Cname";
            

            DataTable dt2 = Dt.SelectData("select ParName from Parkings");

            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "ParName";
            Dt.Close();
            label5.Text = BL.Add__Reserve.code.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text !="" && textBox2.Text != "" && comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                try
                {
                    DateTime TimeGet = DateTime.Now;
                    string CarName = textBox1.Text;
                    textBox1.Text = "";
                    string PlateNum = textBox2.Text;
                    textBox2.Text = "";
                    string ParkingName = comboBox2.GetItemText(comboBox2.SelectedItem);
                    string CarCompenyName = comboBox1.GetItemText(comboBox1.SelectedItem);

                    AD.GetParking(TimeGet, CarName, PlateNum, ParkingName, CarCompenyName);

                    label5.Text = BL.Add__Reserve.code.ToString();
                    MessageBox.Show("Code :" + (BL.Add__Reserve.code - 1) + "\n" + "Park Number :" + ParkingName + "\n" + "Time In :" + TimeGet.ToShortTimeString() + "\n" + "Date :" + TimeGet.ToShortDateString());
                }
                catch
                {
                    MessageBox.Show("Wrong input");
                }

            }
            else
            {
                MessageBox.Show("Please fill all fields");
            }
           

            }
            
    }
}
