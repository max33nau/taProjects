using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.Domain
{
    public class PaymentTypes
    {
        public List<PaymentType> Types { get; private set; }

        public PaymentTypes()
        {
            Types = new List<PaymentType>()
            {
                new PaymentType() { Payment = DTO.Enums.Payment.Card },
                new PaymentType() { Payment = DTO.Enums.Payment.Cash }
            };
        }

    }

    public class PaymentType
    {
        public Enum Payment { get; set; }
    }

}
