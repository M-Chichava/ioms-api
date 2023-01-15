using Domain;

namespace Application.Specifications
{
    public class PaymentAccountSpecification : BaseSpecification<PaymentAccount>
    {
        public PaymentAccountSpecification()
        : base()
        {
            BaseInclude();
        }
        public PaymentAccountSpecification(string nPayment) 
            : base(x=>x.NPayment == nPayment)
        {
            BaseInclude();
        }
        public PaymentAccountSpecification(int id) 
            : base(x=>x.Id == id)
        {
            BaseInclude();
        }
        public PaymentAccountSpecification(int id, string space) 
            : base(x=>x.Id == id)
        {
            BaseInclude();
        }

        public void BaseInclude()
        {
            AddInclude(x=>x.BankAccount);
            AddInclude(x=>x.Payment);
        }
    }
}