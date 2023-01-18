using Domain;

namespace Application.Specifications
{
    public class OutgoingSpecification : BaseSpecification<Outgoing>
    {
        public OutgoingSpecification()
        : base()
        {
            
        }
        public OutgoingSpecification(long account) 
            : base(x=>x.Amount == account)
        {
            
        }
        public OutgoingSpecification(int id) 
            : base(x=>x.Id == id)
        {
            
        }
    }
}