using System;

namespace Domain
{
    public class DisbursementAccount
    {
        public int Id { get; set; }
        public string NDisbursement { get; set; }
        public string DisbursementDate { get; set; }
        public Disbursement Disbursement { get; set; }
        public BankAccount BankAccount { get; set; }
        
    }
}