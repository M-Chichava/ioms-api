namespace Domain
{
    public class AdministrativeCostAccount
    {
        public int Id { get; set; }
        public AdministrativeCost AdministrativeCost { get; set; }
        public Account Account { get; set; }
        
    }
}