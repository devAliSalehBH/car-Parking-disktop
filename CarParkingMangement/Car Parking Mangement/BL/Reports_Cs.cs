using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Car_Parking_Mangement.BL
{
    class Reports_Cs
    {
        DAL.DataAccessLayer dal = new DAL.DataAccessLayer();





        public DataTable DisplayReports()
        {
            dal.Open();
            DataTable dt = dal.SelectData("select * from Reports");
            

            dal.Close();
            return dt;
        }

    }
    


}
