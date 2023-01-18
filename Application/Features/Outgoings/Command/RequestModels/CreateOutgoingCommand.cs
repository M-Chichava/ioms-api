using MediatR;
using Domain;

namespace Application.Features.Outgoings.Command.RequestModels
{
    public class CreateOutgoingCommand : IRequest<OutgoingAccount>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public long AccountNumber { get; set; }
        
    }
}