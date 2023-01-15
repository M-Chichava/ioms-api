using Domain;

namespace Application.Specifications
{
    public class PaymentSpecification : BaseSpecification<Payment>
    {
        public PaymentSpecification()
        : base()
        {
            
        }
        public PaymentSpecification(long account) 
            : base(x=>x.Amount == account)
        {
            
        }
        public PaymentSpecification(int id) 
            : base(x=>x.Id == id)
        {
            
        }
    }
}