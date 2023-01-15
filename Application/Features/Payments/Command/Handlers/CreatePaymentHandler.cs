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
    public class CreatePaymentHandler : IRequestHandler<CreatePaymentCommand, PaymentAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePaymentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaymentAccount> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var accountSpecification = new BankAccountSpecification(request.AccountNumber);
            var bankAccount = await _unitOfWork.Repository<BankAccount>().GetEntityWithSpecAsync(accountSpecification);

            if (bankAccount is null)
            {
                throw new ApiException(HttpStatusCode.Found,
                    "The specific bank account with entered account number doesn't exist on data base");

            }
            
            bankAccount.Balance += request.Amount;
            
            var paymentDateTime = DateTime.Now;
            var paymentDate = paymentDateTime.ToString("yyyy-MM-dd hh:mm:ss");
            var auxNumber = new Random().Next(1000, 9999);
            
            var nPayment = "PYT" + paymentDateTime.Year + ""+ paymentDateTime.Month+""+paymentDateTime.Day+""+auxNumber;

            
            var payment = new Payment
            {
                Description = request.Description,
                Amount = request.Amount
            };
            
            var paymentBank = new PaymentAccount
            { 
                Payment = payment,
                NPayment = nPayment,
                PaymentDate = paymentDate,
                BankAccount = bankAccount
            };
            _unitOfWork.Repository<Payment>().AddAsync(payment);
            _unitOfWork.Repository<PaymentAccount>().AddAsync(paymentBank);
            
            var result = await _unitOfWork.Complete();
            
            if (result <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to add new bank account");
            }

            return paymentBank;
        }
    }
}