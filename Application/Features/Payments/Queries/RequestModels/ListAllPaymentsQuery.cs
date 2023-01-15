using System.Collections.Generic;
using Domain;
using MediatR;

namespace Application.Features.Payments.Queries.RequestModels
{
    public class ListAllPaymentsQuery : IRequest<IReadOnlyList<PaymentAccount>>
    {
        
    }
}