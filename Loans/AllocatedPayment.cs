using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans
{
    internal class AllocatedPayment
    {
        public string AllocatedPaymentId { get; set; }

        public string InwardPaymentId { get; set; }

        public string CustomerAccountNumber { get; set; }

        public string LoanId { get; set; }

        public decimal AmountAllocated { get; set; }

        public DateTime CreatedAtUtc { get; set; }
    }
}
