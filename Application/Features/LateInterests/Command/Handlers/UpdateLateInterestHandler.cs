using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.Deposits.Command.RequestModels;
using Application.Features.LateInterests.Command.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.LateInterests.Command.Handlers
{
    public class UpdateLateInterestHandler : IRequestHandler<UpdateLateInterestCommand, LateInterestAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateLateInterestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<LateInterestAccount> Handle(UpdateLateInterestCommand request, CancellationToken cancellationToken)
        {

            var lateInterestAccountSpecification = new LateInterestAccountSpecification(request.Id);
            var lateInterestAccount = await _unitOfWork.Repository<LateInterestAccount>().GetEntityWithSpecAsync(lateInterestAccountSpecification);
            var lateInterest = lateInterestAccount.LateInterest;

            var oldBankAccountSpecification = new BankAccountSpecification(lateInterestAccount.BankAccount.AccountNumber);
            var oldbankAccount = await _unitOfWork.Repository<BankAccount>().GetEntityWithSpecAsync(oldBankAccountSpecification);
            
            if (request.AccountNumber > 0 && request.AccountNumber.ToString().Length >= 8)
            {
                lateInterestAccount.BankAccount.AccountNumber = request.AccountNumber;
                
                oldbankAccount.Balance -= lateInterest.Amount;

            }
            
            if (request.Description is not null)
            {
                lateInterest.Description = request.Description;
            }
            
            lateInterestAccount.BankAccount.Balance += request.Amount + lateInterest.Amount;
            if (request.Amount > 0)
            {
                lateInterest.Amount = request.Amount;
            }
                
            
            _unitOfWork.Repository<LateInterest>().Update(lateInterest);
            _unitOfWork.Repository<LateInterestAccount>().Update(lateInterestAccount);

            var response = await _unitOfWork.Complete();

            if (response <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to Update Deposit");
            }

            return lateInterestAccount;
        }
    }
}