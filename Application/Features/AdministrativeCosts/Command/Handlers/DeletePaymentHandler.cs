using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.AdministrativeCosts.Command.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Features.AdministrativeCosts.Command.Handlers
{
    public class DeleteAdministrativeCostHandler : IRequestHandler<DeleteAdministrativeCostCommand, AdministrativeCostAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAdministrativeCostHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<AdministrativeCostAccount> Handle(DeleteAdministrativeCostCommand request, CancellationToken cancellationToken)
        {
           var administrativeCostSpecification = new AdministrativeCostSpecification(request.Id);
            var administrativeCost = await _unitOfWork.Repository<AdministrativeCost>().GetEntityWithSpecAsync(administrativeCostSpecification);

            var administrativeCostAccountSpecification = new AdministrativeCostAccountSpecification(administrativeCost.Id, "");
            var administrativeCostAccount = await _unitOfWork.Repository<AdministrativeCostAccount>().GetEntityWithSpecAsync(administrativeCostAccountSpecification);
            
            if (administrativeCost is null)
            {
                throw new ApiException(HttpStatusCode.NotFound, "The specified AdministrativeCost  was not found");
            }

            _unitOfWork.Repository<AdministrativeCost>().Delete(administrativeCost);
            _unitOfWork.Repository<AdministrativeCostAccount>().Delete(administrativeCostAccount);
            
            var response = await _unitOfWork.Complete();
            if (response <= 0)
            {
                throw new ApiException(HttpStatusCode.InternalServerError, "Failed to delete Bank Account");
            }
            return administrativeCostAccount;
        }
    }
}