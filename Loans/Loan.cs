using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans
{
    internal class Loan
    {
        public string LoanId { get; set; }

        public string ProductId { get; set; }

        public string ShopId { get; set; }

        public DateOnly LoanStartDate { get; set; }

        public decimal TotalLoanAmount { get; set; }

        /// <summary>
        /// aka: dailyRate
        /// </summary>
        public decimal PeriodicPaymentAmount { get; set; }

        
        /// <summary>
        /// The date that the loan was paid off, if it was paid off.
        /// </summary>
        public DateOnly? PaidOffAt { get; set; }


    }
}
