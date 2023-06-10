using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans
{
    internal class CustomerLoansProjection
    {
        public string CustomerAccountNumber { get; set; }

        public IList<CustomerLoansProjectionEntry> Entries { get; } = new List<CustomerLoansProjectionEntry>();

        public DateTime CreatedAtUtc { get; set; }

        public DateTime LastUpdatedAtUtc { get; set; }
    }
}
