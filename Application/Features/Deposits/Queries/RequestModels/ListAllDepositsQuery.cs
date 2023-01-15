using System.Collections.Generic;
using Domain;
using MediatR;

namespace Application.Features.Deposits.Queries.RequestModels
{
    public class ListAllDepositsQuery : IRequest<IReadOnlyList<DepositAccount>>
    {
        
    }
}