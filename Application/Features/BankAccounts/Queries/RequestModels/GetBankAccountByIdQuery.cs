using Domain;
using MediatR;

namespace Application.Features.BankAccounts.Queries.RequestModels
{
    public class GetBankAccountByIdQuery : IRequest<BankAccount>
    {
        public int Id { get; set; }
    }
}