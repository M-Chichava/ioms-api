using System;

namespace Domain
{
    public class PaymentAccount
    {
        public int Id { get; set; }
        public Payment Payment { get; set; }
        public string NPayment { get; set; }
        public string PaymentDate { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}