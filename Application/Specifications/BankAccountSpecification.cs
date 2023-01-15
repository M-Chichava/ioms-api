using Domain;

namespace Application.Specifications
{
    public class BankAccountSpecification : BaseSpecification<BankAccount>
    {
        public BankAccountSpecification()
        : base()
        {
            
        }
        public BankAccountSpecification(long account) 
            : base(x=>x.AccountNumber == account)
        {
            
        }
        public BankAccountSpecification(int id) 
            : base(x=>x.Id == id)
        {
            
        }
    }
}