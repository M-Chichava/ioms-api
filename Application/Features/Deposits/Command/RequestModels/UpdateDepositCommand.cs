using Domain;
using MediatR;

namespace Application.Features.Deposits.Command.RequestModels
{
    public class UpdateDepositCommand : IRequest<DepositAccount>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public long AccountNumber { get; set; }
    }
}