using Domain;

namespace Application.Specifications
{
    public class DepositSpecification : BaseSpecification<Deposit>
    {
        public DepositSpecification()
        : base()
        {
            
        }
        public DepositSpecification(long account) 
            : base(x=>x.Amount == account)
        {
            
        }
        public DepositSpecification(int id) 
            : base(x=>x.Id == id)
        {
            
        }
    }
}