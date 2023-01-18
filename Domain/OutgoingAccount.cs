namespace Domain
{
    public class OutgoingAccount
    {
        public int Id { get; set; }
        public string NOutgoing { get; set; }
        public string OutgoingDate { get; set; }
        public Outgoing Outgoing { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}