namespace Domain
{
    public class DepositAccount
    {
        public int Id { get; set; }
        public Deposit Deposit { get; set; }
        public Account Account { get; set; }
    }
}