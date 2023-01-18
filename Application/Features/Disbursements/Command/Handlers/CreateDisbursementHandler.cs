using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.Disbursements.Command.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.Disbursements.Command.Handlers
{
    public class CreateDisbursementHandler : IRequestHandler<CreateDisbursementCommand, DisbursementAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDisbursementHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<DisbursementAccount> Handle(CreateDisbursementCommand request, CancellationToken cancellationToken)
        {
            var accountSpecification = new BankAccountSpecification(request.AccountNumber);
            var bankAccount = await _unitOfWork.Repository<BankAccount>().GetEntityWithSpecAsync(accountSpecification);

            if (bankAccount is null)
            {
                throw new ApiException(HttpStatusCode.Found,
                    "The specific bank account with entered account number doesn't exist on data base");

            }
            
            bankAccount.Balance += request.Amount;
            
            var disbursementDateTime = DateTime.Now;
            var disbursementDate = disbursementDateTime.ToString("yyyy-MM-dd hh:mm:ss");
            var auxNumber = new Random().Next(1000, 9999);
            
            var nDisbursement = "PYT" + disbursementDateTime.Year + ""+ disbursementDateTime.Month+""+disbursementDateTime.Day+""+auxNumber;

            
            var disbursement = new Disbursement
            {
                Description = request.Description,
                Amount = request.Amount
            };
            
            var disbursementBank = new DisbursementAccount
            { 
                Disbursement = disbursement,
                NDisbursement = nDisbursement,
                DisbursementDate = disbursementDate,
                BankAccount = bankAccount
            };
            _unitOfWork.Repository<Disbursement>().AddAsync(disbursement);
            _unitOfWork.Repository<DisbursementAccount>().AddAsync(disbursementBank);
            
            var result = await _unitOfWork.Complete();
            
            if (result <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to add new bank account");
            }

            return disbursementBank;
        }
    }
}