using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.BankAccounts.Queries.RequestModels;
using Application.Features.LateInterests.Queries.RequestModels;
using Application.Features.Users.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.LateInterests.Queries.Handlers
{
    public class ListAllLateInterestsHandler : IRequestHandler<ListAllLateInterestsQuery, IReadOnlyList<LateInterestAccount>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public ListAllLateInterestsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper; 
        }
        public async Task<IReadOnlyList<LateInterestAccount>> Handle(ListAllLateInterestsQuery request, CancellationToken cancellationToken)
        {
            var lateInterestAccountSpecification = new LateInterestAccountSpecification();
            var lateInterestAccounts = await _unitOfWork.Repository<LateInterestAccount>()
                .ListAllWithSpecAsync(lateInterestAccountSpecification);
            var lateInterestAccountsList =  new List<LateInterestAccount>();

            foreach (var lateInterestAccount in lateInterestAccounts)
            {
                lateInterestAccountsList.Add(lateInterestAccount);
                
            }
            return lateInterestAccountsList;
        }
    }
}