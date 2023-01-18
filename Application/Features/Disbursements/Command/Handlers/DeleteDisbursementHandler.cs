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
    public class DeleteDisbursementHandler : IRequestHandler<DeleteDisbursementCommand, DisbursementAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDisbursementHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<DisbursementAccount> Handle(DeleteDisbursementCommand request, CancellationToken cancellationToken)
        {
           var disbursementSpecification = new DisbursementSpecification(request.Id);
            var disbursement = await _unitOfWork.Repository<Disbursement>().GetEntityWithSpecAsync(disbursementSpecification);

            var disbursementAccountSpecification = new DisbursementAccountSpecification(disbursement.Id, "");
            var disbursementAccount = await _unitOfWork.Repository<DisbursementAccount>().GetEntityWithSpecAsync(disbursementAccountSpecification);
            
            if (disbursement is null)
            {
                throw new ApiException(HttpStatusCode.NotFound, "The specified disbursement  was not found");
            }

            _unitOfWork.Repository<Disbursement>().Delete(disbursement);
            _unitOfWork.Repository<DisbursementAccount>().Delete(disbursementAccount);
            
            var response = await _unitOfWork.Complete();
            if (response <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to delete Bank Account");
            }
            return disbursementAccount;
        }
    }
}