using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Features.BankAccounts.Command.RequestModels;
using Application.Features.BankAccounts.Queries.RequestModels;
using Application.Features.AdministrativeCosts.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Features.AdministrativeCosts.Queries.Handlers
{
    public class GetAdministrativeCostByIdHandler : IRequestHandler<GetAdministrativeCostByIdQuery, AdministrativeCostAccount>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAdministrativeCostByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<AdministrativeCostAccount> Handle(GetAdministrativeCostByIdQuery request, CancellationToken cancellationToken)
        {
            var administrativeCostAccountSpecification = new AdministrativeCostAccountSpecification(request.NAdministrativeCost);
            var administrativeCostAccount =   await _unitOfWork.Repository<AdministrativeCostAccount>().GetEntityWithSpecAsync(administrativeCostAccountSpecification);
            
            if (administrativeCostAccount is null)
            {
                throw new ApiException(HttpStatusCode.NotFound,"Bank Account not Found in data base");
            }

            return administrativeCostAccount; 
        }
    }
}