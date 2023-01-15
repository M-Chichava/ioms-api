using Domain;
using MediatR;

namespace Application.Features.BankAccounts.Command.RequestModels
{
    public class DeleteBankAccountCommand : IRequest<BankAccount>
    {
        public int Id { get; set; }
    }
}