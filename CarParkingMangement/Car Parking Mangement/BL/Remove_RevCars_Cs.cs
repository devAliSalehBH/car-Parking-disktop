using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace Car_Parking_Mangement.BL
{
    class Remove_RevCars_Cs
    {
        DAL.DataAccessLayer dal = new DAL.DataAccessLayer();

        private DateTime TimeIn;
        private int TotalTime;       
        private double TotalCost;
        
        public Remove_RevCars_Cs()
        {
          
        }
        
        
        public List<string> Remove_ResevedCar(int code)
        {
            
           
            dal.Open();
         
            TotalCost = CollcteCost(code);
            TimeIn = Convert.ToDateTime((dal.One_SelectData("select TimeIn from ReservedPark where Code = " + code)));
            string[] _buffer = { DateTime.Now.ToString(), TotalTime.ToString(), TotalCost.ToString() };
            List<string> str = GetRemoveInfo(code);
            str.AddRange(_buffer);

            UpdateOnReport(str);

            dal.Close();

            return str;
        }

       
        private double CollcteCost(int code)
        {

            DateTime _TimeIn  = Convert.ToDateTime((dal.One_SelectData("select TimeIn from ReservedPark where Code = " + code)));

            DateTime D2 = DateTime.Now;
            var D3 = (_TimeIn < D2) ? (D2 - _TimeIn) : (_TimeIn - D2);
            TotalTime = (int) D3.TotalHours;

            double Cost = (double)dal.One_SelectData("select Money from AdminInfo");

            TotalCost = TotalTime * Cost;


            return TotalCost;
        }

        private List<string> GetRemoveInfo(int Code)
        {
            
            DataTable dt = dal.SelectData($@"select Code,TimeIn, CarName,Cname,PlateNum,ParName from ReservedPark inner join CarCompany on CarCompID = Crc_Id inner join Parkings on P_Id=ParkID where Code = {Code}");

            List<string> str = new List<string>();
            foreach(DataRow var in dt.Rows)
            {
                str.Add(var.Field<int>(0).ToString());
                str.Add(var.Field<string>(1));
                str.Add(var.Field<string>(2));
                str.Add(var.Field<string>(3));
                str.Add(var.Field<string>(4));
                str.Add(var.Field<string>(5));
            }

            return str;
        }

        private void UpdateOnReport(List<string> str)
        {
          
                
            dal.ExecuteCommand($@"DELETE FROM ReservedPark where Code  = {str[0]}");
            dal.Open();
        

                dal.ExecuteCommand($@"INSERT INTO Reports VALUES ({str[0]},'{str[1]}','{str[2]}','{str[3]}','{str[4]}','{str[5]}','{str[6]}',{str[7]},{str[8]})");
            
            
            
                dal.Close();
            

           
           
        }
















    }
}
