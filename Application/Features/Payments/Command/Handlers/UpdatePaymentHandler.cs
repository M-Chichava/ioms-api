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
    public class UpdatePaymentHandler : IRequestHandler<UpdatePaymentCommand, PaymentAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePaymentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaymentAccount> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {

            var paymentAccountSpecification = new PaymentAccountSpecification(request.Id);
            var paymentAccount = await _unitOfWork.Repository<PaymentAccount>().GetEntityWithSpecAsync(paymentAccountSpecification);
            var payment = paymentAccount.Payment;

            var oldBankAccountSpecification = new BankAccountSpecification(paymentAccount.BankAccount.AccountNumber);
            var oldbankAccount = await _unitOfWork.Repository<BankAccount>().GetEntityWithSpecAsync(oldBankAccountSpecification);
            
            if (request.AccountNumber > 0 && request.AccountNumber.ToString().Length >= 8)
            {
                paymentAccount.BankAccount.AccountNumber = request.AccountNumber;
                
                oldbankAccount.Balance -= payment.Amount;

            }
            
            if (request.Description is not null)
            {
                payment.Description = request.Description;
            }
            
            paymentAccount.BankAccount.Balance += request.Amount + payment.Amount;
            if (request.Amount > 0)
            {
                payment.Amount = request.Amount;
            }
                
            
            _unitOfWork.Repository<Payment>().Update(payment);
            _unitOfWork.Repository<PaymentAccount>().Update(paymentAccount);

            var response = await _unitOfWork.Complete();

            if (response <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to Update Payment");
            }

            return paymentAccount;
        }
    }
}