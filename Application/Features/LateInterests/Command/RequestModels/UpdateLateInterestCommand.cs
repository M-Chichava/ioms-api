using Domain;
using MediatR;

namespace Application.Features.LateInterests.Command.RequestModels
{
    public class UpdateLateInterestCommand : IRequest<LateInterestAccount>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public long AccountNumber { get; set; }
    }
}