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
    public class CreateBankAccountHandler : IRequestHandler<CreateBankAccountCommand, BankAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBankAccountHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BankAccount> Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
        {
            var bankAccountSpec = new BankAccountSpecification(request.AccountNumber);
            var bankAccountCheck = await _unitOfWork.Repository<BankAccount>().GetEntityWithSpecAsync(bankAccountSpec);

            if (bankAccountCheck is not null)
            {
                throw new ApiException(HttpStatusCode.Found,
                    "The specific bank account with entered account number already exist on data base");
            }

            var bankAccount = new BankAccount
            {
                Name = request.Name,
                AccountNumber = request.AccountNumber,
                Balance = request.Balance
            };
            
            _unitOfWork.Repository<BankAccount>().AddAsync(bankAccount);
            var result = await _unitOfWork.Complete();
            if (result <= 0)
            {
                
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to add new bank account");
            }

            return bankAccount;
        }
    }
}