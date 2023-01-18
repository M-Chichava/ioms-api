using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.BankAccounts.Queries.RequestModels;
using Application.Features.Reinforcements.Queries.RequestModels;
using Application.Features.Users.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Reinforcements.Queries.Handlers
{
    public class ListAllReinforcementsHandler : IRequestHandler<ListAllReinforcementsQuery, IReadOnlyList<ReinforcementAccount>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public ListAllReinforcementsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper; 
        }
        public async Task<IReadOnlyList<ReinforcementAccount>> Handle(ListAllReinforcementsQuery request, CancellationToken cancellationToken)
        {
            var reinforcementAccountSpecification = new ReinforcementAccountSpecification();
            var reinforcementAccounts = await _unitOfWork.Repository<ReinforcementAccount>()
                .ListAllWithSpecAsync(reinforcementAccountSpecification);
            var reinforcementAccountsList =  new List<ReinforcementAccount>();

            foreach (var reinforcementAccount in reinforcementAccounts)
            {
                reinforcementAccountsList.Add(reinforcementAccount);
                
            }
            return reinforcementAccountsList;
        }
    }
}