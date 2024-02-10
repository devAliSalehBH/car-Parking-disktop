using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Car_Parking_Mangement.DAL
{
    class DataAccessLayer
    {
        SqlConnection sqlconnection;

        public DataAccessLayer()
        {
            sqlconnection = new SqlConnection(@"Server =YOGA370\SQLEXPRESS; Database =CarParkingMangement;Integrated Security = true;  ");

        }


        //Method to open connection 
        public void Open()
        {
            if(sqlconnection.State != ConnectionState.Open)
            {
                sqlconnection.Open();
            }
        }
        //Method to close connection
        public void Close()
        {
            if(sqlconnection.State == ConnectionState.Open)
            {
                sqlconnection.Close();
            }
        }

        //Method to read Date from Database = CarParkingMangement

        public DataTable SelectData(string command)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandText = command;
            sqlcmd.Connection = sqlconnection;
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public object One_SelectData(string command)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandText = command;
            sqlcmd.Connection = sqlconnection;
            
            return sqlcmd.ExecuteScalar();
        }



        public void ExecuteCommand(string command)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandText = command;
            sqlcmd.Connection = sqlconnection;

            sqlcmd.ExecuteNonQuery();
            sqlcmd.Connection.Close();
        }


    }
}
