using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.BankAccounts.Command.RequestModels;
using Application.Features.BankAccounts.Queries.RequestModels;
using Application.Features.Payments.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Features.Payments.Queries.Handlers
{
    public class GetPaymentByIdHandler : IRequestHandler<GetPaymentByIdQuery, PaymentAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPaymentByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaymentAccount> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            var paymentAccountSpecification = new PaymentAccountSpecification(request.NPayment);
            var paymentAccount =   await _unitOfWork.Repository<PaymentAccount>().GetEntityWithSpecAsync(paymentAccountSpecification);
            
            if (paymentAccount is null)
            {
                throw new ApiException(HttpStatusCode.NotFound,"Bank Account not Found in data base");
            }

            return paymentAccount; 
        }
    }
}