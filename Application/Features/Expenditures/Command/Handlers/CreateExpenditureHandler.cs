using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.Expenditures.Command.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.Expenditures.Command.Handlers
{
    public class CreateExpenditureHandler : IRequestHandler<CreateExpenditureCommand, ExpenditureAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateExpenditureHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ExpenditureAccount> Handle(CreateExpenditureCommand request, CancellationToken cancellationToken)
        {
            var accountSpecification = new BankAccountSpecification(request.AccountNumber);
            var bankAccount = await _unitOfWork.Repository<BankAccount>().GetEntityWithSpecAsync(accountSpecification);

            if (bankAccount is null)
            {
                throw new ApiException(HttpStatusCode.Found,
                    "The specific bank account with entered account number doesn't exist on data base");

            }
            
            bankAccount.Balance += request.Amount;
            
            var expenditureDateTime = DateTime.Now;
            var expenditureDate = expenditureDateTime.ToString("yyyy-MM-dd hh:mm:ss");
            var auxNumber = new Random().Next(1000, 9999);
            
            var nExpenditure = "PYT" + expenditureDateTime.Year + ""+ expenditureDateTime.Month+""+expenditureDateTime.Day+""+auxNumber;

            
            var expenditure = new Expenditure
            {
                Description = request.Description,
                Amount = request.Amount
            };
            
            var expenditureBank = new ExpenditureAccount
            { 
                Expenditure = expenditure,
                NExpenditure = nExpenditure,
                ExpenditureDate = expenditureDate,
                BankAccount = bankAccount
            };
            _unitOfWork.Repository<Expenditure>().AddAsync(expenditure);
            _unitOfWork.Repository<ExpenditureAccount>().AddAsync(expenditureBank);
            
            var result = await _unitOfWork.Complete();
            
            if (result <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to add new bank account");
            }

            return expenditureBank;
        }
    }
}