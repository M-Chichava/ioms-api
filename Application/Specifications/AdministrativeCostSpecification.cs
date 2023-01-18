using Domain;

namespace Application.Specifications
{
    public class AdministrativeCostSpecification : BaseSpecification<AdministrativeCost>
    {
        public AdministrativeCostSpecification()
        : base()
        {
            
        }
        public AdministrativeCostSpecification(long account) 
            : base(x=>x.Amount == account)
        {
            
        }
        public AdministrativeCostSpecification(int id) 
            : base(x=>x.Id == id)
        {
            
        }
    }
}