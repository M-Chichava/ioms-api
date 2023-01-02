namespace Domain
{
    public class LateInterestAccount
    {
        public int Id { get; set; }
        public LateInterest LateInterest { get; set; }
        public Account Account { get; set; }
        
    }
}