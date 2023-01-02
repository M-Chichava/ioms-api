namespace Domain
{
    public class ExpenditureAccount
    {
        public int Id { get; set; }
        public Expenditure Expenditure { get; set; }
        public Account Account { get; set; }
        
    }
}