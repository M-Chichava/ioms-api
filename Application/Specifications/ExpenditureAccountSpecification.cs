using Domain;

namespace Application.Specifications
{
    public class ExpenditureAccountSpecification : BaseSpecification<ExpenditureAccount>
    {
        public ExpenditureAccountSpecification()
        : base()
        {
            BaseInclude();
        }
        public ExpenditureAccountSpecification(string nExpenditure) 
            : base(x=>x.NExpenditure == nExpenditure)
        {
            BaseInclude();
        }
        public ExpenditureAccountSpecification(int id) 
            : base(x=>x.Id == id)
        {
            BaseInclude();
        }
        public ExpenditureAccountSpecification(int id, string space) 
            : base(x=>x.Id == id)
        {
            BaseInclude();
        }

        public void BaseInclude()
        {
            AddInclude(x=>x.BankAccount);
            AddInclude(x=>x.Expenditure);
        }
    }
}