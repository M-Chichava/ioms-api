using Domain;
using MediatR;

namespace Application.Features.Outgoings.Queries.RequestModels
{
    public class GetOutgoingByIdQuery : IRequest<OutgoingAccount>
    {
        public string NOutgoing { get; set; }
    }
}