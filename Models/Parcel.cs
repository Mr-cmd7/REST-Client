using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_Client.Models
{
    public class Parcel
    {
        public int Id { get; set; }
        public string SenderFullName { get; set; }
        public string DepartureCode { get; set; }
        public decimal Weight { get; set; }
        public string Destination { get; set; }
        public decimal Cost { get; set; }
    }
}
