using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.BankAccounts.Command.RequestModels;
using Application.Features.BankAccounts.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Features.BankAccounts.Command.Handlers
{
    public class GetBankAccountByIdHandler : IRequestHandler<GetBankAccountByIdQuery, BankAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBankAccountByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BankAccount> Handle(GetBankAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var bankAccountSpec = new BankAccountSpecification(request.Id);
            var bankAccount =   await _unitOfWork.Repository<BankAccount>().GetEntityWithSpecAsync(bankAccountSpec);
            
            if (bankAccount is null)
            {
                throw new ApiException(HttpStatusCode.NotFound,"Bank Account not Found in data base");
            }

            return bankAccount; 
        }
    }
}