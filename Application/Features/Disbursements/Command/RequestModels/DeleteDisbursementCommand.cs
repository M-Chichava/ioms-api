using Domain;
using MediatR;

namespace Application.Features.Disbursements.Command.RequestModels
{
    public class DeleteDisbursementCommand : IRequest<DisbursementAccount>
    {
        public int Id { get; set; }
    }
}