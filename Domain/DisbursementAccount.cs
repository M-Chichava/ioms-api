namespace Domain
{
    public class DisbursementAccount
    {
        public int Id { get; set; }
        public Disbursement Disbursement { get; set; }
        public Account Account { get; set; }
        
    }
}