using System;

namespace Domain
{
    public class LateInterestAccount
    {
        public int Id { get; set; }
        public string NLateInterest { get; set; }
        public string LateInterestDate { get; set; }
        public LateInterest LateInterest { get; set; }
        public BankAccount BankAccount { get; set; }
        
    }
}