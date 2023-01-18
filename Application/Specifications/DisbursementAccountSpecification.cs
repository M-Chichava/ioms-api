using Domain;

namespace Application.Specifications
{
    public class DisbursementAccountSpecification : BaseSpecification<DisbursementAccount>
    {
        public DisbursementAccountSpecification()
        : base()
        {
            BaseInclude();
        }
        public DisbursementAccountSpecification(string nDisbursement) 
            : base(x=>x.NDisbursement == nDisbursement)
        {
            BaseInclude();
        }
        public DisbursementAccountSpecification(int id) 
            : base(x=>x.Id == id)
        {
            BaseInclude();
        }
        public DisbursementAccountSpecification(int id, string space) 
            : base(x=>x.Id == id)
        {
            BaseInclude();
        }

        public void BaseInclude()
        {
            AddInclude(x=>x.BankAccount);
            AddInclude(x=>x.Disbursement);
        }
    }
}