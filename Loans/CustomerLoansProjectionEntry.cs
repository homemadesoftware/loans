using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans
{
    internal class CustomerLoansProjectionEntry
    {
        public string LoanId { get; set; }

        public decimal PaymentToDate { get; set; }

        public string LastAllocatedPaymentId { get; set; }
    }
}
