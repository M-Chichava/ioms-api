using System.Collections.Generic;
using Domain;
using MediatR;

namespace Application.Features.AdministrativeCosts.Queries.RequestModels
{
    public class ListAllAdministrativeCostsQuery : IRequest<IReadOnlyList<AdministrativeCostAccount>>
    {
        
    }
}