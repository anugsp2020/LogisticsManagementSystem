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
            int rowsAffected = 0;
            using (sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = "insert into Shipments values(@shipmentId,@customername,@startLocation,@endLocation,@expectedStartDate,@actualStartDate,@expectedEndDate,@actualEndDate)";
                    sqlCommand.Parameters.AddWithValue("@shipmentId", shipmentObject.ShipmentId);
                    sqlCommand.Parameters.AddWithValue("@customername", shipmentObject.CustomerName);
                    sqlCommand.Parameters.AddWithValue("@startLocation", shipmentObject.StartLocation);
                    sqlCommand.Parameters.AddWithValue("@endLocation", shipmentObject.EndLocation);
                    sqlCommand.Parameters.AddWithValue("@expectedStartDate", shipmentObject.ExpectedStartDate);
                    sqlCommand.Parameters.AddWithValue("@actualStartDate", shipmentObject.ActualStartDate);
                    sqlCommand.Parameters.AddWithValue("@expectedEndDate", shipmentObject.ExpectedEndDate);
                    sqlCommand.Parameters.AddWithValue("@actualEndDate", shipmentObject.ActualEndDate);
                    rowsAffected = sqlCommand.ExecuteNonQuery();

                }
            }
            return rowsAffected;
        }
        public static DataTable ViewShipments()
        {
            DataTable shipmentDetails = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select * from Shipments";
                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                {
                    adapter.Fill(shipmentDetails);
                }


            }
            return shipmentDetails;
        }

        public static DataTable ViewShipmentsByCustomerName(string customerName)
        {

            DataTable customerShipmentDetails = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select * from Shipments where customername=@customerName";
                sqlCommand.Parameters.AddWithValue("@customerName", customerName);
                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                {
                    adapter.Fill(customerShipmentDetails);
                }


            }
            return customerShipmentDetails;
        }
    }
}
