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
    public class DeleteLateInterestHandler : IRequestHandler<DeleteLateInterestCommand, LateInterestAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLateInterestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<LateInterestAccount> Handle(DeleteLateInterestCommand request, CancellationToken cancellationToken)
        {
           var lateInterestSpecification = new LateInterestSpecification(request.Id);
            var lateInterest = await _unitOfWork.Repository<LateInterest>().GetEntityWithSpecAsync(lateInterestSpecification);

            var lateInterestAccountSpecification = new LateInterestAccountSpecification(lateInterest.Id, "");
            var lateInterestAccount = await _unitOfWork.Repository<LateInterestAccount>().GetEntityWithSpecAsync(lateInterestAccountSpecification);
            
            if (lateInterest is null)
            {
                throw new ApiException(HttpStatusCode.NotFound, "The specified lateInterest  was not found");
            }

            _unitOfWork.Repository<LateInterest>().Delete(lateInterest);
            _unitOfWork.Repository<LateInterestAccount>().Delete(lateInterestAccount);
            
            var response = await _unitOfWork.Complete();
            if (response <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to delete Bank Account");
            }
            return lateInterestAccount;
        }
    }
}