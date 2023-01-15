using System;

namespace Domain
{
    public class AdministrativeCostAccount
    {
        public int Id { get; set; }
        public string NAdministrativeCost { get; set; }
        public string AdministrativeCostDate { get; set; }
        public AdministrativeCost AdministrativeCost { get; set; }
        public BankAccount BankAccount { get; set; }
        
    }
}