using Domain;
using MediatR;

namespace Application.Features.Payments.Command.RequestModels
{
    public class DeletePaymentCommand : IRequest<PaymentAccount>
    {
        public int Id { get; set; }
    }
}