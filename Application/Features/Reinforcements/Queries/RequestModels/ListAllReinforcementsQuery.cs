using System.Collections.Generic;
using Domain;
using MediatR;

namespace Application.Features.Reinforcements.Queries.RequestModels
{
    public class ListAllReinforcementsQuery : IRequest<IReadOnlyList<ReinforcementAccount>>
    {
        
    }
}