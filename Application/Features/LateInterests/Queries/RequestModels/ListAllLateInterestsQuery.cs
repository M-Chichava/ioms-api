using System.Collections.Generic;
using Domain;
using MediatR;

namespace Application.Features.LateInterests.Queries.RequestModels
{
    public class ListAllLateInterestsQuery : IRequest<IReadOnlyList<LateInterestAccount>>
    {
        
    }
}