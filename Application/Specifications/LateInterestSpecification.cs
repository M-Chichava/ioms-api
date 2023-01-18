using Domain;

namespace Application.Specifications
{
    public class LateInterestSpecification : BaseSpecification<LateInterest>
    {
        public LateInterestSpecification()
        : base()
        {
            
        }
        public LateInterestSpecification(long account) 
            : base(x=>x.Amount == account)
        {
            
        }
        public LateInterestSpecification(int id) 
            : base(x=>x.Id == id)
        {
            
        }
    }
}