using Domain;

namespace Application.Specifications
{
    public class AdministrativeCostAccountSpecification : BaseSpecification<AdministrativeCostAccount>
    {
        public AdministrativeCostAccountSpecification()
        : base()
        {
            BaseInclude();
        }
        public AdministrativeCostAccountSpecification(string nAdministrativeCost) 
            : base(x=>x.NAdministrativeCost == nAdministrativeCost)
        {
            BaseInclude();
        }
        public AdministrativeCostAccountSpecification(int id) 
            : base(x=>x.Id == id)
        {
            BaseInclude();
        }
        public AdministrativeCostAccountSpecification(int id, string space) 
            : base(x=>x.Id == id)
        {
            BaseInclude();
        }

        public void BaseInclude()
        {
            AddInclude(x=>x.BankAccount);
            AddInclude(x=>x.AdministrativeCost);
        }
    }
}