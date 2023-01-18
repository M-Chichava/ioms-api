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
    public class UpdateDisbursementHandler : IRequestHandler<UpdateDisbursementCommand, DisbursementAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDisbursementHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<DisbursementAccount> Handle(UpdateDisbursementCommand request, CancellationToken cancellationToken)
        {

            var disbursementAccountSpecification = new DisbursementAccountSpecification(request.Id);
            var disbursementAccount = await _unitOfWork.Repository<DisbursementAccount>().GetEntityWithSpecAsync(disbursementAccountSpecification);
            var disbursement = disbursementAccount.Disbursement;

            var oldBankAccountSpecification = new BankAccountSpecification(disbursementAccount.BankAccount.AccountNumber);
            var oldbankAccount = await _unitOfWork.Repository<BankAccount>().GetEntityWithSpecAsync(oldBankAccountSpecification);
            
            if (request.AccountNumber > 0 && request.AccountNumber.ToString().Length >= 8)
            {
                disbursementAccount.BankAccount.AccountNumber = request.AccountNumber;
                
                oldbankAccount.Balance -= disbursement.Amount;

            }
            
            if (request.Description is not null)
            {
                disbursement.Description = request.Description;
            }
            
            disbursementAccount.BankAccount.Balance += request.Amount + disbursement.Amount;
            if (request.Amount > 0)
            {
                disbursement.Amount = request.Amount;
            }
                
            
            _unitOfWork.Repository<Disbursement>().Update(disbursement);
            _unitOfWork.Repository<DisbursementAccount>().Update(disbursementAccount);

            var response = await _unitOfWork.Complete();

            if (response <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to Update disbursement");
            }

            return disbursementAccount;
        }
    }
}