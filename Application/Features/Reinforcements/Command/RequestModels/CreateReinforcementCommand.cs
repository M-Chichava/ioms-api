using MediatR;
using Domain;

namespace Application.Features.Reinforcements.Command.RequestModels
{
    public class CreateReinforcementCommand : IRequest<ReinforcementAccount>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public long AccountNumber { get; set; }
        
    }
}