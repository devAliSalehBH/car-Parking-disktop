using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Car_Parking_Mangement.BL
{
    class Account
    {
        protected DAL.DataAccessLayer dal = new DAL.DataAccessLayer();

        public DataTable Login(string UserName ,string Password)
        {
            
            dal.Open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectData($@"select * from AdminInfo where User_Name = '{UserName}' AND Password ='{Password}' ");
            return Dt;
        }

       



    }
    class Admin_Account : Account
    {


        

        public void Greate_NewLogin(string UserName, string Password)
        {

            dal.Open();
            dal.ExecuteCommand($@"INSERT INTO Accounts VALUES ('{UserName}','{Password}','User')");

        }

        public void Delet_UserLogins(int code)
        {
            dal.ExecuteCommand($@"DELETE FROM UserLogins where Code  = {code}");

        }
        public void EditCost(double NewCost)
        {
            dal.ExecuteCommand($"UPDATE AdminInfo SET Money = {NewCost}");

        }
        public void EditProfile(string UserName , string Pasword)
        {
            dal.ExecuteCommand($"UPDATE AdminInfo SET User_Name = {UserName} , Password = {Pasword}");

        }


    }
}
