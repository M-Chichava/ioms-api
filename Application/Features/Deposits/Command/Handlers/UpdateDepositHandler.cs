using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.Deposits.Command.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.Deposits.Command.Handlers
{
    public class UpdateDepositHandler : IRequestHandler<UpdateDepositCommand, DepositAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDepositHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<DepositAccount> Handle(UpdateDepositCommand request, CancellationToken cancellationToken)
        {

            var depositAccountSpecification = new DepositAccountSpecification(request.Id);
            var depositAccount = await _unitOfWork.Repository<DepositAccount>().GetEntityWithSpecAsync(depositAccountSpecification);
            var deposit = depositAccount.Deposit;

            var oldBankAccountSpecification = new BankAccountSpecification(depositAccount.BankAccount.AccountNumber);
            var oldbankAccount = await _unitOfWork.Repository<BankAccount>().GetEntityWithSpecAsync(oldBankAccountSpecification);
            
            if (request.AccountNumber > 0 && request.AccountNumber.ToString().Length >= 8)
            {
                depositAccount.BankAccount.AccountNumber = request.AccountNumber;
                
                oldbankAccount.Balance -= deposit.Amount;

            }
            
            if (request.Description is not null)
            {
                deposit.Description = request.Description;
            }
            
            depositAccount.BankAccount.Balance += request.Amount + deposit.Amount;
            if (request.Amount > 0)
            {
                deposit.Amount = request.Amount;
            }
                
            
            _unitOfWork.Repository<Deposit>().Update(deposit);
            _unitOfWork.Repository<DepositAccount>().Update(depositAccount);

            var response = await _unitOfWork.Complete();

            if (response <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to Update Deposit");
            }

            return depositAccount;
        }
    }
}