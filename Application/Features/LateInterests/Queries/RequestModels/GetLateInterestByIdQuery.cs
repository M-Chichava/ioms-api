using Domain;
using MediatR;

namespace Application.Features.LateInterests.Queries.RequestModels
{
    public class GetLateInterestByIdQuery : IRequest<LateInterestAccount>
    {
        public string NLateInterest { get; set; }
    }
}