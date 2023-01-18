using Domain;

namespace Application.Specifications
{
    public class DisbursementSpecification : BaseSpecification<Disbursement>
    {
        public DisbursementSpecification()
        : base()
        {
            
        }
        public DisbursementSpecification(long account) 
            : base(x=>x.Amount == account)
        {
            
        }
        public DisbursementSpecification(int id) 
            : base(x=>x.Id == id)
        {
            
        }
    }
}