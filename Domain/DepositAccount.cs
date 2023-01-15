using System;

namespace Domain
{
    public class DepositAccount
    {
        public int Id { get; set; }
        public string NDeposit { get; set; }
        public string DepositDate { get; set; }
        public Deposit Deposit { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}