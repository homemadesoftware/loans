using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans
{
    internal class CustomerLoans
    {
        public string CustomerAccountNumber { get; set; }

        public IList<Loan> Loans { get; } = new List<Loan>();

        public DateTime CreatedAtUtc { get; set; }

        public DateTime LastUpdatedAtUtc { get; set; }
    }
}
