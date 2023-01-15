using Domain;
using MediatR;

namespace Application.Features.Deposits.Queries.RequestModels
{
    public class GetDepositByIdQuery : IRequest<DepositAccount>
    {
        public string NDeposit { get; set; }
    }
}