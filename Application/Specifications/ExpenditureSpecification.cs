using Domain;

namespace Application.Specifications
{
    public class ExpenditureSpecification : BaseSpecification<Expenditure>
    {
        public ExpenditureSpecification()
        : base()
        {
            
        }
        public ExpenditureSpecification(long account) 
            : base(x=>x.Amount == account)
        {
            
        }
        public ExpenditureSpecification(int id) 
            : base(x=>x.Id == id)
        {
            
        }
    }
}