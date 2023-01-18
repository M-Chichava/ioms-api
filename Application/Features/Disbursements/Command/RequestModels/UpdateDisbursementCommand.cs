using Domain;
using MediatR;

namespace Application.Features.Disbursements.Command.RequestModels
{
    public class UpdateDisbursementCommand : IRequest<DisbursementAccount>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public long AccountNumber { get; set; }
    }
}