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
    public class CreateDepositHandler : IRequestHandler<CreateDepositCommand, DepositAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDepositHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<DepositAccount> Handle(CreateDepositCommand request, CancellationToken cancellationToken)
        {
            var accountSpecification = new BankAccountSpecification(request.AccountNumber);
            var bankAccount = await _unitOfWork.Repository<BankAccount>().GetEntityWithSpecAsync(accountSpecification);

            if (bankAccount is null)
            {
                throw new ApiException(HttpStatusCode.Found,
                    "The specific bank account with entered account number doesn't exist ondata base");

            }
            
            bankAccount.Balance += request.Amount;
            
            var depositDateTime = DateTime.Now;
            var depositDate = depositDateTime.ToString("yyyy-MM-dd hh:mm:ss");
            var auxNumber = new Random().Next(1000, 9999);
            
            var nDeposit = "PYT" + depositDateTime.Year + ""+ depositDateTime.Month+""+ depositDateTime.Day+""+auxNumber;

            
            var deposit = new Deposit
            {
                Description = request.Description,
                Amount = request.Amount
            };
            
            var depositBank = new DepositAccount
            { 
                Deposit = deposit,
                NDeposit = nDeposit,
                DepositDate = depositDate,
                BankAccount = bankAccount
            };
            _unitOfWork.Repository<Deposit>().AddAsync(deposit);
            _unitOfWork.Repository<DepositAccount>().AddAsync( depositBank);
            
            var result = await _unitOfWork.Complete();
            
            if (result <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to add new bank account");
            }

            return depositBank;
        }
    }
}