using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Car_Parking_Mangement.BL
{
    class Add__Reserve
    {
        DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
        public static int code = int.Parse(DateTime.Now.Year + "1211");
        
        public Add__Reserve()
        {
            try
            {
                dal.Open();
                code = int.Parse(dal.One_SelectData($@"select max(Code) from ReservedPark").ToString()) +1;
                dal.Close();
             }
            
            catch
            {
                dal.Open();
                code = int.Parse(dal.One_SelectData($@"select max(Code) from Reports").ToString()) + 1;
                dal.Close();
            }
            finally
            {
                
            }

        }

        public void GetParking(DateTime TimeIn,string CarName ,string PlateNum ,string ParkingName,string CarCompenyName)
        {


            dal.Open();
            int CarCompID = Convert.ToInt32(dal.One_SelectData($@"select Crc_Id from CarCompany where Cname = '{CarCompenyName}'").ToString());
            int ParkID = Convert.ToInt32(dal.One_SelectData($@"select P_Id from Parkings where ParName  = '{ParkingName}'").ToString());
            dal.ExecuteCommand($@"INSERT INTO ReservedPark VALUES ({code},'{TimeIn}','{CarName}','{PlateNum}',{ParkID},{CarCompID})");
            code++;
            dal.Close();
            
        }

        public void ShowDeitals()
        {
            

        }

      
    }
}
