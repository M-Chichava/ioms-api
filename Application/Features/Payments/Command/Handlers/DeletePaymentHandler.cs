using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.Payments.Command.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.Payments.Command.Handlers
{
    public class DeletePaymentHandler : IRequestHandler<DeletePaymentCommand, PaymentAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePaymentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaymentAccount> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
           var paymentSpecification = new PaymentSpecification(request.Id);
            var payment = await _unitOfWork.Repository<Payment>().GetEntityWithSpecAsync(paymentSpecification);

            var paymentAccountSpecification = new PaymentAccountSpecification(payment.Id, "");
            var paymentAccount = await _unitOfWork.Repository<PaymentAccount>().GetEntityWithSpecAsync(paymentAccountSpecification);
            
            if (payment is null)
            {
                throw new ApiException(HttpStatusCode.NotFound, "The specified Payment  was not found");
            }

            _unitOfWork.Repository<Payment>().Delete(payment);
            _unitOfWork.Repository<PaymentAccount>().Delete(paymentAccount);
            
            var response = await _unitOfWork.Complete();
            if (response <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to delete Bank Account");
            }
            return paymentAccount;
        }
    }
}