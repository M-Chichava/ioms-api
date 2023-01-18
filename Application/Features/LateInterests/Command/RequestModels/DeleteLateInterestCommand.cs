using Domain;
using MediatR;

namespace Application.Features.LateInterests.Command.RequestModels
{
    public class DeleteLateInterestCommand : IRequest<LateInterestAccount>
    {
        public int Id { get; set; }
    }
}