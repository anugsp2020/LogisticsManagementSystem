using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    public class Shipments
    {
        public string ShipmentId { get; set; }
        public string CustomerName { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime ExpectedStartDate { get; set; }
        public DateTime ActualStartDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public DateTime ActualEndDate { get; set; }
    }
}
