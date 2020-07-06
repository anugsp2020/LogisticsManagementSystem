using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {

                    Console.WriteLine("\n Enter Your Choice \n");
                    Console.WriteLine(" 1. Insert Logistics Details\n 2. View All Logistics Details \n 3. View Logistics details of a customer \n 4. Exit");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            {
                                Shipments shipmentObject = new Shipments();
                                Console.WriteLine("Enter the Shipment Id");
                                string shipmentId = Console.ReadLine();
                                shipmentObject.ShipmentId = shipmentId;

                                Console.WriteLine("Enter the Customer Name");
                                string customerName = Console.ReadLine();
                                shipmentObject.CustomerName = customerName;

                                Console.WriteLine("Enter the Start Location");
                                string startLocation = Console.ReadLine();
                                shipmentObject.StartLocation = startLocation;

                                Console.WriteLine("Enter the End Location");
                                string endLocation = Console.ReadLine();
                                shipmentObject.EndLocation = endLocation;

                                Console.WriteLine("Enter the ExpectedStartDate");
                                string expectedStartDate = Console.ReadLine();
                                shipmentObject.ExpectedStartDate = DateTime.Parse(expectedStartDate);

                                Console.WriteLine("Enter the ActualStartDate");
                                string actualStartDate = Console.ReadLine();
                                shipmentObject.ActualStartDate = DateTime.Parse(actualStartDate);

                                Console.WriteLine("Enter the ExpectedEndDate");
                                string expectedEndDate = Console.ReadLine();
                                shipmentObject.ExpectedEndDate = DateTime.Parse(expectedEndDate);

                                Console.WriteLine("Enter the ActualEndDate");
                                string actualEndDate = Console.ReadLine();
                                shipmentObject.ActualEndDate = DateTime.Parse(actualEndDate);

                                int rowsAffected = BusinessLogicLayer.AddCustomerDetails(shipmentObject);
                                if (rowsAffected > 0)
                                {
                                    Console.WriteLine("Shipment Items inserted successfully");
                                }
                                else
                                {
                                    Console.WriteLine("An error occurred");
                                }

                                break;
                            }
                        case 2:
                            {
                                List<Shipments> shipmentDetails = BusinessLogicLayer.ViewShipmentDetails();
                                foreach (var item in shipmentDetails)
                                {
                                    Console.WriteLine(item.ShipmentId + "\t" + item.CustomerName + "\t" + item.StartLocation + "\t" + item.EndLocation + "\t" + item.ExpectedStartDate + "\t" + item.ActualStartDate + "\t" + item.ExpectedEndDate + "\t" + item.ActualEndDate);
                                }
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Enter the customer name");
                                string customerName = Console.ReadLine();
                                List<Shipments> shipmentDetails = BusinessLogicLayer.ViewShipmentsByCustomerName(customerName);
                                foreach (var item in shipmentDetails)
                                {
                                    Console.WriteLine(item.ShipmentId + "\t" + item.CustomerName + "\t" + item.StartLocation + "\t" + item.EndLocation + "\t" + item.ExpectedStartDate + "\t" + item.ActualStartDate + "\t" + item.ExpectedEndDate + "\t" + item.ActualEndDate);
                                }
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("Exiting the application");
                                Environment.Exit(0);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Please enter a valid Choice");
                                break;
                            }
                    }

                    Console.ReadLine();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
