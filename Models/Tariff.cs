using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_Client.Models
{
    public class Tariff
    {
        public int Id { get; set; }
        public string DepartureCode { get; set; }
        public string DepartureName { get; set; }
        public decimal PricePerWeightUnit { get; set; }
    }
}
