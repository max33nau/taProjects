using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.DTO
{
    public class OrderCopy
    {
        public System.Guid OrderId { get; set; }
        public Enums.SizeType Size { get; set; }
        public Enums.Crust Crust { get; set; }
        public bool Sausage { get; set; }
        public bool Pepperoni { get; set; }
        public bool Onions { get; set; }
        public bool Green_Peppers { get; set; }
        public double TotalCost { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Zip { get; set; }
        public string Phone { get; set; }
        public Enums.Payment PaymentType { get; set; }
        public string Notes { get; set; }
        public bool Completed { get; set; }
    }
}
