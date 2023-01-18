using Domain;

namespace Application.Specifications
{
    public class ReinforcementSpecification : BaseSpecification<Reinforcement>
    {
        public ReinforcementSpecification()
        : base()
        {
            
        }
        public ReinforcementSpecification(long account) 
            : base(x=>x.Amount == account)
        {
            
        }
        public ReinforcementSpecification(int id) 
            : base(x=>x.Id == id)
        {
            
        }
    }
}