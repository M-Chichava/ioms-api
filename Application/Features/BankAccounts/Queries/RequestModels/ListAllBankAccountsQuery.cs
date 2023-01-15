using System.Collections.Generic;
using Domain;
using MediatR;

namespace Application.Features.BankAccounts.Queries.RequestModels
{
    public class ListAllBankAccountsQuery : IRequest<IReadOnlyList<BankAccount>>
    {
        
    }
}