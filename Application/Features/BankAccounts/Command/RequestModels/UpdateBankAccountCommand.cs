using Domain;
using MediatR;

namespace Application.Features.BankAccounts.Command.RequestModels
{
    public class UpdateBankAccountCommand : IRequest<BankAccount>
    {
        public int Id { get; set; }
        public long AccountNumber { get; set; }
        public float Balance { get; set; }
        public string Name { get; set; }
    }
}