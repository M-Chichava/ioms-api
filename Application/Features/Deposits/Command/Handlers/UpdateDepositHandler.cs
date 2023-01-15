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

            var DepositAccountSpecification = new DepositAccountSpecification(request.Id);
            var DepositAccount = await _unitOfWork.Repository<DepositAccount>().GetEntityWithSpecAsync(DepositAccountSpecification);
            var Deposit = DepositAccount.Deposit;

            var oldBankAccountSpecification = new BankAccountSpecification(DepositAccount.BankAccount.AccountNumber);
            var oldbankAccount = await _unitOfWork.Repository<BankAccount>().GetEntityWithSpecAsync(oldBankAccountSpecification);
            
            if (request.AccountNumber > 0 && request.AccountNumber.ToString().Length >= 8)
            {
                DepositAccount.BankAccount.AccountNumber = request.AccountNumber;
                
                oldbankAccount.Balance -= Deposit.Amount;

            }
            
            if (request.Description is not null)
            {
                Deposit.Description = request.Description;
            }
            
            DepositAccount.BankAccount.Balance += request.Amount + Deposit.Amount;
            if (request.Amount > 0)
            {
                Deposit.Amount = request.Amount;
            }
                
            
            _unitOfWork.Repository<Deposit>().Update(Deposit);
            _unitOfWork.Repository<DepositAccount>().Update(DepositAccount);

            var response = await _unitOfWork.Complete();

            if (response <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to Update Deposit");
            }

            return DepositAccount;
        }
    }
}