using Domain;

namespace Application.Specifications
{
    public class DepositAccountSpecification : BaseSpecification<DepositAccount>
    {
        public DepositAccountSpecification()
        : base()
        {
            BaseInclude();
        }
        public DepositAccountSpecification(string nDeposit) 
            : base(x=>x.NDeposit == nDeposit)
        {
            BaseInclude();
        }
        public DepositAccountSpecification(int id) 
            : base(x=>x.Id == id)
        {
            BaseInclude();
        }
        public DepositAccountSpecification(int id, string space) 
            : base(x=>x.Id == id)
        {
            BaseInclude();
        }

        public void BaseInclude()
        {
            AddInclude(x=>x.BankAccount);
            AddInclude(x=>x.Deposit);
        }
    }
}