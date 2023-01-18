using System.Collections.Generic;
using Domain;
using MediatR;

namespace Application.Features.Disbursements.Queries.RequestModels
{
    public class ListAllDisbursementsQuery : IRequest<IReadOnlyList<DisbursementAccount>>
    {
        
    }
}