using MediatR;
using Domain;

namespace Application.Features.Payments.Command.RequestModels
{
    public class CreatePaymentCommand : IRequest<PaymentAccount>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public long AccountNumber { get; set; }
        
    }
}