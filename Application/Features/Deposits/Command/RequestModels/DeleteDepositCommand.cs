using Domain;
using MediatR;

namespace Application.Features.Deposits.Command.RequestModels
{
    public class DeleteDepositCommand : IRequest<DepositAccount>
    {
        public int Id { get; set; }
    }
}