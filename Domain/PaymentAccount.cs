namespace Domain
{
    public class PaymentAccount
    {
        public int Id { get; set; }
        public Payment Payment { get; set; }
        public Account Account { get; set; }
    }
}