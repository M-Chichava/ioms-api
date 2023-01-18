using Domain;

namespace Application.Specifications
{
    public class OutgoingAccountSpecification : BaseSpecification<OutgoingAccount>
    {
        public OutgoingAccountSpecification()
        : base()
        {
            BaseInclude();
        }
        public OutgoingAccountSpecification(string nOutgoing) 
            : base(x=>x.NOutgoing == nOutgoing)
        {
            BaseInclude();
        }
        public OutgoingAccountSpecification(int id) 
            : base(x=>x.Id == id)
        {
            BaseInclude();
        }
        public OutgoingAccountSpecification(int id, string space) 
            : base(x=>x.Id == id)
        {
            BaseInclude();
        }

        public void BaseInclude()
        {
            AddInclude(x=>x.BankAccount);
            AddInclude(x=>x.Outgoing);
        }
    }
}