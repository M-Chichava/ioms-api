using System.Collections.Generic;
using Domain;
using MediatR;

namespace Application.Features.Expenditures.Queries.RequestModels
{
    public class ListAllExpendituresQuery : IRequest<IReadOnlyList<ExpenditureAccount>>
    {
        
    }
}