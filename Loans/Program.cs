using Newtonsoft.Json;

namespace Loans
{
    public class Program
    {
        static public int Main()
        {
            // Illustrate a customer entry
            Customer customer = new Customer()
            {
                FirstName = "John",
                LastName = "Doe",
                CustomerAccountNumber = "CUST00000001",
                DateOfBirth = new DateOnly(1980, 1, 15),
                NationalId = "NI123456789",
                PhoneNumber = "078912328934",
                CreatedAtUtc = DateTime.UtcNow,
                LastUpdatedAtUtc = DateTime.UtcNow
            };
            Dump(nameof(customer), customer);

            // Illustrate a new loan
            CustomerLoans customerLoans = new CustomerLoans()
            {
                CustomerAccountNumber = customer.CustomerAccountNumber,
                CreatedAtUtc = DateTime.UtcNow,
                LastUpdatedAtUtc = DateTime.UtcNow
            };
            customerLoans.Loans.Add(new Loan()
            {
                LoanId = "S0001",
                ProductId = "SOLAR",
                ShopId = "Bob's Solar Panels",
                LoanStartDate = DateOnly.FromDateTime(DateTime.Today.Date),
                PaidOffAt = null,
                TotalLoanAmount = 130M,
                PeriodicPaymentAmount = 0.50M
            });
            Dump(nameof(customerLoans), customerLoans);

            // Illustrate new payment received
            InwardPayment inwardPayment = new InwardPayment()
            {
                PaymentId = "078912328934/2023-06-10T11:50:12.12345/CUST00000001",
                AccountNumber = "CUST00000001",
                PhoneNumber = "078912328934",
                PaymentAmount = 1.50M,
                SenderReference = null,
                PaymentArrivedAtUtc = DateTime.UtcNow
            };
            Dump(nameof(inwardPayment), inwardPayment);

            // Payment allocated to customers loan
            AllocatedPayment allocatedPayment = new AllocatedPayment()
            {
                CustomerAccountNumber = customer.CustomerAccountNumber,
                LoanId = "S001",
                InwardPaymentId = inwardPayment.PaymentId,
                AllocatedPaymentId = inwardPayment.PaymentId + "/" + customer.CustomerAccountNumber,
                AmountAllocated = 1.50M,
                CreatedAtUtc = DateTime.UtcNow
            };
            Dump(nameof(allocatedPayment), allocatedPayment);

            // Customers Loans Projection updated
            CustomerLoansProjection loansProjection = new CustomerLoansProjection()
            {
                CustomerAccountNumber = customer.CustomerAccountNumber,
                CreatedAtUtc = DateTime.UtcNow,
                LastUpdatedAtUtc = DateTime.UtcNow
            };
            loansProjection.Entries.Add(new CustomerLoansProjectionEntry()
            {
                LoanId = "S001",
                LastAllocatedPaymentId = allocatedPayment.AllocatedPaymentId,
                PaymentToDate = 1.50M
            });
            Dump(nameof(loansProjection), loansProjection);

            // Another payment
            InwardPayment inwardPayment2 = new InwardPayment()
            {
                PaymentId = "078912328934/2023-06-12T18:00:00.00000/CUST00000001",
                AccountNumber = "CUST00000001",
                PhoneNumber = "078912328934",
                PaymentAmount = 0.35M,
                SenderReference = null,
                PaymentArrivedAtUtc = DateTime.UtcNow
            };
            Dump(nameof(inwardPayment2), inwardPayment2);

            // Second Payment allocated to customers loan
            AllocatedPayment allocatedPayment2 = new AllocatedPayment()
            {
                CustomerAccountNumber = customer.CustomerAccountNumber,
                LoanId = "S001",
                InwardPaymentId = inwardPayment2.PaymentId,
                AllocatedPaymentId = inwardPayment2.PaymentId + "/" + customer.CustomerAccountNumber,
                AmountAllocated = 0.35M,
                CreatedAtUtc = DateTime.UtcNow
            };
            Dump(nameof(allocatedPayment2), allocatedPayment2);

            // Projection updated
            loansProjection.Entries[0].LastAllocatedPaymentId = allocatedPayment2.AllocatedPaymentId;
            loansProjection.Entries[0].PaymentToDate += allocatedPayment2.AmountAllocated;
            loansProjection.LastUpdatedAtUtc = DateTime.UtcNow;

            Dump(nameof(loansProjection), loansProjection);


            return 0;
        }

        private static void Dump(string name, object target)
        {
            Console.WriteLine(name);
            Console.WriteLine(JsonConvert.SerializeObject(target, Formatting.Indented));
        }
    }
}