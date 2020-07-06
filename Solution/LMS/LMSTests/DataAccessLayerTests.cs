using Microsoft.VisualStudio.TestTools.UnitTesting;
using LMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Transactions;
using NUnit.Framework.Interfaces;
using System.Data;

namespace LMS.Tests
{

    [TestFixture]
    public class DataAccessLayerTests
    {
        Shipments shipmentObject;
        [SetUp]
        public void SetUp()
        {
            shipmentObject = new Shipments();
        }
        [Test, Rollback]
        public void InsertShipmentDetails_CountOfRowsInserted_ReturnsRowsAffected()
        {
            int expected = 1;
            try
            {

                shipmentObject.ShipmentId = "2";
                shipmentObject.CustomerName = "James";
                shipmentObject.StartLocation = "Chennai";
                shipmentObject.EndLocation = "Pune";
                shipmentObject.ExpectedStartDate = DateTime.Parse("2020-07-01");
                shipmentObject.ActualStartDate = DateTime.Parse("2020-07-10");
                shipmentObject.ExpectedEndDate = DateTime.Parse("2020-07-15");
                shipmentObject.ActualEndDate = DateTime.Parse("2020-07-24");

                int actual = DataAccessLayer.InsertShipmentDetails(shipmentObject);
                NUnit.Framework.Assert.That(actual, Is.EqualTo(expected), "Shipment details does not get inserted");
            }
            catch (AssertionException)
            {


            }
            catch (Exception)
            {
                NUnit.Framework.Assert.Fail("Shipment details is not valid. Exception should not be thrown. Please check the input and application logic.");
            }
        }

        [Test, Rollback]
        public void ViewShipments_ShipmentsDataRetreival_ReturnsAllLogistics()
        {
            try
            {
                shipmentObject.ShipmentId = "2";
                shipmentObject.CustomerName = "James";
                shipmentObject.StartLocation = "Chennai";
                shipmentObject.EndLocation = "Pune";
                shipmentObject.ExpectedStartDate = DateTime.Parse("2020-07-01");
                shipmentObject.ActualStartDate = DateTime.Parse("2020-07-10");
                shipmentObject.ExpectedEndDate = DateTime.Parse("2020-07-15");
                shipmentObject.ActualEndDate = DateTime.Parse("2020-07-24");

                int rowsAffected = DataAccessLayer.InsertShipmentDetails(shipmentObject);
                if (rowsAffected > 0)
                {
                    DataTable dt = DataAccessLayer.ViewShipments();
                    foreach (DataRow dr in dt.Rows)
                    {
                        NUnit.Framework.Assert.That(dr[0].ToString(), Is.EqualTo(shipmentObject.ShipmentId), "Shipment id does not match");
                        NUnit.Framework.Assert.That(dr[1].ToString(), Is.EqualTo(shipmentObject.CustomerName), "Customer name does not match");
                        NUnit.Framework.Assert.That(dr[2].ToString(), Is.EqualTo(shipmentObject.StartLocation), "Start location does not match");
                        NUnit.Framework.Assert.That(dr[3].ToString(), Is.EqualTo(shipmentObject.EndLocation), "End location doesnot match");
                        NUnit.Framework.Assert.That(DateTime.Parse(dr[4].ToString()), Is.EqualTo(shipmentObject.ExpectedStartDate), "Expected Start date doesnot match");
                        NUnit.Framework.Assert.That(DateTime.Parse(dr[5].ToString()), Is.EqualTo(shipmentObject.ActualStartDate), "Actual Start date doesnot match");
                        NUnit.Framework.Assert.That(DateTime.Parse(dr[6].ToString()), Is.EqualTo(shipmentObject.ExpectedEndDate), "Expected End date doesnot match");
                        NUnit.Framework.Assert.That(DateTime.Parse(dr[7].ToString()), Is.EqualTo(shipmentObject.ActualEndDate), "Actual End daate doesnot match");
                    }
                }
            }
            catch (AssertionException)
            {


            }
            catch (Exception)
            {
                NUnit.Framework.Assert.Fail("Shipment details is not valid. Exception should not be thrown. Please check the input and application logic.");

            }
        }

        [Test, Rollback]
        public void ViewShipmentsByCustomerName_CustomerBasedLogistics_ReturnsCustomerLogistics()
        {

            try
            {
                shipmentObject.ShipmentId = "3";
                shipmentObject.CustomerName = "George";
                shipmentObject.StartLocation = "Mumbai";
                shipmentObject.EndLocation = "Kolkata";
                shipmentObject.ExpectedStartDate = DateTime.Parse("2020-08-10");
                shipmentObject.ActualStartDate = DateTime.Parse("2020-08-20");
                shipmentObject.ExpectedEndDate = DateTime.Parse("2020-08-24");
                shipmentObject.ActualEndDate = DateTime.Parse("2020-09-04");

                int rowsAffected = DataAccessLayer.InsertShipmentDetails(shipmentObject);
                if (rowsAffected > 0)
                {
                    DataTable dt = DataAccessLayer.ViewShipmentsByCustomerName(shipmentObject.CustomerName);
                    foreach (DataRow dr in dt.Rows)
                    {
                        NUnit.Framework.Assert.That(dr[0].ToString(), Is.EqualTo(shipmentObject.ShipmentId), "Shipment id does not match");
                        NUnit.Framework.Assert.That(dr[1].ToString(), Is.EqualTo(shipmentObject.CustomerName), "Customer name does not match");
                        NUnit.Framework.Assert.That(dr[2].ToString(), Is.EqualTo(shipmentObject.StartLocation), "Start location does not match");
                        NUnit.Framework.Assert.That(dr[3].ToString(), Is.EqualTo(shipmentObject.EndLocation), "End location doesnot match");
                        NUnit.Framework.Assert.That(DateTime.Parse(dr[4].ToString()), Is.EqualTo(shipmentObject.ExpectedStartDate), "Expected Start date doesnot match");
                        NUnit.Framework.Assert.That(DateTime.Parse(dr[5].ToString()), Is.EqualTo(shipmentObject.ActualStartDate), "Actual Start date doesnot match");
                        NUnit.Framework.Assert.That(DateTime.Parse(dr[6].ToString()), Is.EqualTo(shipmentObject.ExpectedEndDate), "Expected End date doesnot match");
                        NUnit.Framework.Assert.That(DateTime.Parse(dr[7].ToString()), Is.EqualTo(shipmentObject.ActualEndDate), "Actual End daate doesnot match");
                    }
                }
            }
            catch (AssertionException)
            {


            }
            catch (Exception)
            {
                NUnit.Framework.Assert.Fail("Shipment details is not valid. Exception should not be thrown. Please check the input and application logic.");

            }
        }
    }

    public class RollbackAttribute : Attribute, ITestAction
    {
        private TransactionScope transaction;

        public void BeforeTest(ITest test)
        {
            transaction = new TransactionScope();
        }
        public void AfterTest(ITest test)
        {
            transaction.Dispose();
        }
        public ActionTargets Targets
        {
            get { return ActionTargets.Test; }
        }
    }
}