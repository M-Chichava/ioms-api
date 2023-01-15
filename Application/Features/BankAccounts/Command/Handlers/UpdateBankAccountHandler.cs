using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.BankAccounts.Command.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.BankAccounts.Command.Handlers
{
    public class UpdateBankAccountHandler : IRequestHandler<UpdateBankAccountCommand, BankAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBankAccountHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BankAccount> Handle(UpdateBankAccountCommand request, CancellationToken cancellationToken)
        {
            var bankAccountSpec = new BankAccountSpecification(request.Id);
            var bankAccount =   await _unitOfWork.Repository<BankAccount>().GetEntityWithSpecAsync(bankAccountSpec);

            if (bankAccount is null)
            {
                throw new ApiException(HttpStatusCode.NotFound, "Bank Account not exists");
            }

            if (request.AccountNumber != 0)
            {
                bankAccount.AccountNumber = request.AccountNumber;
            }
            if (request.Name is not null)
            {
                bankAccount.Name = request.Name;
            }

            bankAccount.Balance += request.Balance;
           
            
            _unitOfWork.Repository<BankAccount>().Update(bankAccount);

            var response = await _unitOfWork.Complete();

            if (response <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to Update Bank Account");
            }

            return bankAccount;
        }
    }
}