using Domain;
using MediatR;

namespace Application.Features.Reinforcements.Command.RequestModels
{
    public class DeleteReinforcementCommand : IRequest<ReinforcementAccount>
    {
        public int Id { get; set; }
    }
}