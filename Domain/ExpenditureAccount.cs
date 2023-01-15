using System;

namespace Domain
{
    public class ExpenditureAccount
    {
        public int Id { get; set; }
        public string NExpenditure { get; set; }
        public string ExpenditureDate { get; set; }
        public Expenditure Expenditure { get; set; }
        public BankAccount BankAccount { get; set; }
        
    }
}