using Domain;

namespace Application.Specifications
{
    public class LateInterestAccountSpecification : BaseSpecification<LateInterestAccount>
    {
        public LateInterestAccountSpecification()
        : base()
        {
            BaseInclude();
        }
        public LateInterestAccountSpecification(string nLateInterest) 
            : base(x=>x.NLateInterest == nLateInterest)
        {
            BaseInclude();
        }
        public LateInterestAccountSpecification(int id) 
            : base(x=>x.Id == id)
        {
            BaseInclude();
        }
        public LateInterestAccountSpecification(int id, string space) 
            : base(x=>x.Id == id)
        {
            BaseInclude();
        }

        public void BaseInclude()
        {
            AddInclude(x=>x.BankAccount);
            AddInclude(x=>x.LateInterest);
        }
    }
}