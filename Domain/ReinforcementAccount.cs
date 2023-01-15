using System;

namespace Domain
{
    public class ReinforcementAccount
    {
        public int Id { get; set; }
        public string NReinforcement { get; set; }
        public string ReinforcementDate { get; set; }
        public Reinforcement Reinforcement { get; set; }
        public BankAccount BankAccount { get; set; }
        
    }
}