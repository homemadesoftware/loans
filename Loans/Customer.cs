using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans
{
    internal class Customer
    {
        public string CustomerAccountNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public string NationalId { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public DateTime LastUpdatedAtUtc { get; set; }
    }
}
