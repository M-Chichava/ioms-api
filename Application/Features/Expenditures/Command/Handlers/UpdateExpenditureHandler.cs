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
    public class UpdateExpenditureHandler : IRequestHandler<UpdateExpenditureCommand, ExpenditureAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateExpenditureHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ExpenditureAccount> Handle(UpdateExpenditureCommand request, CancellationToken cancellationToken)
        {

            var expenditureAccountSpecification = new ExpenditureAccountSpecification(request.Id);
            var expenditureAccount = await _unitOfWork.Repository<ExpenditureAccount>().GetEntityWithSpecAsync(expenditureAccountSpecification);
            var expenditure = expenditureAccount.Expenditure;

            var oldBankAccountSpecification = new BankAccountSpecification(expenditureAccount.BankAccount.AccountNumber);
            var oldbankAccount = await _unitOfWork.Repository<BankAccount>().GetEntityWithSpecAsync(oldBankAccountSpecification);
            
            if (request.AccountNumber > 0 && request.AccountNumber.ToString().Length >= 8)
            {
                expenditureAccount.BankAccount.AccountNumber = request.AccountNumber;
                
                oldbankAccount.Balance -= expenditure.Amount;

            }
            
            if (request.Description is not null)
            {
                expenditure.Description = request.Description;
            }
            
            expenditureAccount.BankAccount.Balance += request.Amount + expenditure.Amount;
            if (request.Amount > 0)
            {
                expenditure.Amount = request.Amount;
            }
                
            
            _unitOfWork.Repository<Expenditure>().Update(expenditure);
            _unitOfWork.Repository<ExpenditureAccount>().Update(expenditureAccount);

            var response = await _unitOfWork.Complete();

            if (response <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to Update Expenditure");
            }

            return expenditureAccount;
        }
    }
}