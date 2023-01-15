using Domain;
using MediatR;

namespace Application.Features.Payments.Queries.RequestModels
{
    public class GetPaymentByIdQuery : IRequest<PaymentAccount>
    {
        public string NPayment { get; set; }
    }
}