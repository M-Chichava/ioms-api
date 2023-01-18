using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.BankAccounts.Queries.RequestModels;
using Application.Features.Disbursements.Queries.RequestModels;
using Application.Features.Users.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Disbursements.Queries.Handlers
{
    public class ListAllDisbursementsHandler : IRequestHandler<ListAllDisbursementsQuery, IReadOnlyList<DisbursementAccount>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public ListAllDisbursementsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper; 
        }
        public async Task<IReadOnlyList<DisbursementAccount>> Handle(ListAllDisbursementsQuery request, CancellationToken cancellationToken)
        {
            var disbursementAccountSpecification = new DisbursementAccountSpecification();
            var disbursementAccounts = await _unitOfWork.Repository<DisbursementAccount>()
                .ListAllWithSpecAsync(disbursementAccountSpecification);
            var disbursementAccountsList =  new List<DisbursementAccount>();

            foreach (var disbursementAccount in disbursementAccounts)
            {
                disbursementAccountsList.Add(disbursementAccount);
                
            }
            return disbursementAccountsList;
        }
    }
}