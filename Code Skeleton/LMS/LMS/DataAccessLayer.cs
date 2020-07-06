using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    public class DataAccessLayer
    {
        public static SqlConnection sqlConnection = null;
        public static SqlCommand sqlCommand = null;
        public static SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        public static DataSet dataset = new DataSet();
        public static DataTable dataTable;
        static readonly string connection = ConfigurationManager.ConnectionStrings["LogisticsManagement"].ConnectionString;
        public static int InsertShipmentDetails(Shipments shipmentObject)
        {
           
           /*
		Please fill your code here
	   */             
        }
        public static DataTable ViewShipments()
        {
            
           /*
		Please fill your code here
	   */            
        }

        public static DataTable ViewShipmentsByCustomerName(string customerName)
        {

           /*
		Please fill your code here
	   */            
        }
    }
}
