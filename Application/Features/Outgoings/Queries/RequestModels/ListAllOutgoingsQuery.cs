using System.Collections.Generic;
using Domain;
using MediatR;

namespace Application.Features.Outgoings.Queries.RequestModels
{
    public class ListAllOutgoingsQuery : IRequest<IReadOnlyList<OutgoingAccount>>
    {
        
    }
}