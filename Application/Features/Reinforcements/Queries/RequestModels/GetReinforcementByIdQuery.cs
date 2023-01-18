using Domain;
using MediatR;

namespace Application.Features.Reinforcements.Queries.RequestModels
{
    public class GetReinforcementByIdQuery : IRequest<ReinforcementAccount>
    {
        public string NReinforcement { get; set; }
    }
}