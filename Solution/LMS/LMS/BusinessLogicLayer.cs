using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    public class BusinessLogicLayer
    {
        public static int AddCustomerDetails(Shipments shipments)
        {
            return DataAccessLayer.InsertShipmentDetails(shipments);
        }

        public static List<Shipments> ViewShipmentDetails()
        {
            DataTable shipmentsTable = DataAccessLayer.ViewShipments();
            List<Shipments> shipmentsList = new List<Shipments>();
            foreach (DataRow dr in shipmentsTable.Rows)
            {
                Shipments shipmentObject = new Shipments();
                shipmentObject.ShipmentId = dr[0].ToString();
                shipmentObject.CustomerName = dr[1].ToString();
                shipmentObject.StartLocation = dr[2].ToString();
                shipmentObject.EndLocation = dr[3].ToString();
                shipmentObject.ExpectedStartDate = DateTime.Parse(dr[4].ToString());
                shipmentObject.ActualStartDate = DateTime.Parse(dr[5].ToString());
                shipmentObject.ExpectedEndDate = DateTime.Parse(dr[6].ToString());
                shipmentObject.ActualEndDate = DateTime.Parse(dr[7].ToString());
                shipmentsList.Add(shipmentObject);
            }
            return shipmentsList;
        }

        public static List<Shipments> ViewShipmentsByCustomerName(string customerName)
        {
            DataTable customerShipmentsTable = DataAccessLayer.ViewShipmentsByCustomerName(customerName);
            List<Shipments> customerShipmentsList = new List<Shipments>();
            foreach (DataRow dr in customerShipmentsTable.Rows)
            {
                Shipments shipmentObject = new Shipments();
                shipmentObject.ShipmentId = dr[0].ToString();
                shipmentObject.CustomerName = dr[1].ToString();
                shipmentObject.StartLocation = dr[2].ToString();
                shipmentObject.EndLocation = dr[3].ToString();
                shipmentObject.ExpectedStartDate = DateTime.Parse(dr[4].ToString());
                shipmentObject.ActualStartDate = DateTime.Parse(dr[5].ToString());
                shipmentObject.ExpectedEndDate = DateTime.Parse(dr[6].ToString());
                shipmentObject.ActualEndDate = DateTime.Parse(dr[7].ToString());
                customerShipmentsList.Add(shipmentObject);
            }
            return customerShipmentsList;
        }
    }
}
