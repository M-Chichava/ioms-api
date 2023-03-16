using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.BankAccounts.Queries.RequestModels;
using Application.Features.AdministrativeCosts.Queries.RequestModels;
using Application.Features.Users.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.AdministrativeCosts.Queries.Handlers
{
    public class ListAllAdministrativeCostsHandler : IRequestHandler<ListAllAdministrativeCostsQuery, IReadOnlyList<AdministrativeCostAccount>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public ListAllAdministrativeCostsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper; 
        }
        public async Task<IReadOnlyList<AdministrativeCostAccount>> Handle(ListAllAdministrativeCostsQuery request, CancellationToken cancellationToken)
        {
            var administrativeCostAccountSpecification = new AdministrativeCostAccountSpecification();
            var administrativeCostAccounts = await _unitOfWork.Repository<AdministrativeCostAccount>()
                .ListAllWithSpecAsync(administrativeCostAccountSpecification);
            var administrativeCostAccountsList =  new List<AdministrativeCostAccount>();

            foreach (var administrativeCostAccount in administrativeCostAccounts)
            {
                administrativeCostAccountsList.Add(administrativeCostAccount);
                
            }
            return administrativeCostAccountsList;
        }
    }
}