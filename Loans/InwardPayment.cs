using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans
{
    internal class InwardPayment
    {
        public string PaymentId { get; set; }

        public string PhoneNumber { get; set; }

        public string AccountNumber { get; set; }

        public string SenderReference { get; set; }

        public decimal PaymentAmount { get; set; }

        public DateTime PaymentArrivedAtUtc { get; set; }
    }
}
