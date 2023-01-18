using Domain;
using MediatR;

namespace Application.Features.Outgoings.Command.RequestModels
{
    public class DeleteOutgoingCommand : IRequest<OutgoingAccount>
    {
        public int Id { get; set; }
    }
}