using Domain;

namespace Application.Specifications
{
    public class ReinforcementAccountSpecification : BaseSpecification<ReinforcementAccount>
    {
        public ReinforcementAccountSpecification()
        : base()
        {
            BaseInclude();
        }
        public ReinforcementAccountSpecification(string nReinforcement) 
            : base(x=>x.NReinforcement == nReinforcement)
        {
            BaseInclude();
        }
        public ReinforcementAccountSpecification(int id) 
            : base(x=>x.Id == id)
        {
            BaseInclude();
        }
        public ReinforcementAccountSpecification(int id, string space) 
            : base(x=>x.Id == id)
        {
            BaseInclude();
        }

        public void BaseInclude()
        {
            AddInclude(x=>x.BankAccount);
            AddInclude(x=>x.Reinforcement);
        }
    }
}