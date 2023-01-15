using MediatR;
using Domain;

namespace Application.Features.BankAccounts.Command.RequestModels
{
    public class CreateBankAccountCommand : IRequest<BankAccount>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Balance { get; set; }
        public long AccountNumber { get; set; }
        
    }
}