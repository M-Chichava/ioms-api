using Domain;
using MediatR;

namespace Application.Features.Disbursements.Queries.RequestModels
{
    public class GetDisbursementByIdQuery : IRequest<DisbursementAccount>
    {
        public string NDisbursement { get; set; }
    }
}