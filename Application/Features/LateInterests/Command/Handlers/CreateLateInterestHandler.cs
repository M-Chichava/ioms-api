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
    public class CreateLateInterestHandler : IRequestHandler<CreateLateInterestCommand, LateInterestAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateLateInterestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<LateInterestAccount> Handle(CreateLateInterestCommand request, CancellationToken cancellationToken)
        {
            var accountSpecification = new BankAccountSpecification(request.AccountNumber);
            var bankAccount = await _unitOfWork.Repository<BankAccount>().GetEntityWithSpecAsync(accountSpecification);

            if (bankAccount is null)
            {
                throw new ApiException(HttpStatusCode.Found,
                    "The specific bank account with entered account number doesn't exist ondata base");

            }
            
            bankAccount.Balance += request.Amount;
            
            var lateInterestDateTime = DateTime.Now;
            var lateInterestDate = lateInterestDateTime.ToString("yyyy-MM-dd hh:mm:ss");
            var auxNumber = new Random().Next(1000, 9999);
            
            var nLateInterest = "PYT" + lateInterestDateTime.Year + ""+ lateInterestDateTime.Month+""+ lateInterestDateTime.Day+""+auxNumber;

            
            var lateInterest = new LateInterest
            {
                Description = request.Description,
                Amount = request.Amount
            };
            
            var lateInterestBank = new LateInterestAccount
            { 
                LateInterest = lateInterest,
                NLateInterest = nLateInterest,
                LateInterestDate = lateInterestDate,
                BankAccount = bankAccount
            };
            _unitOfWork.Repository<LateInterest>().AddAsync(lateInterest);
            _unitOfWork.Repository<LateInterestAccount>().AddAsync( lateInterestBank);
            
            var result = await _unitOfWork.Complete();
            
            if (result <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to add new bank account");
            }

            return lateInterestBank;
        }
    }
}