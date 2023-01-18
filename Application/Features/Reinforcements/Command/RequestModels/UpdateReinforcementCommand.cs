using Domain;
using MediatR;

namespace Application.Features.Reinforcements.Command.RequestModels
{
    public class UpdateReinforcementCommand : IRequest<ReinforcementAccount>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public long AccountNumber { get; set; }
    }
}