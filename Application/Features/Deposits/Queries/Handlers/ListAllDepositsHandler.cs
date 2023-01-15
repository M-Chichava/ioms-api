using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.BankAccounts.Queries.RequestModels;
using Application.Features.Deposits.Queries.RequestModels;
using Application.Features.Users.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Deposits.Queries.Handlers
{
    public class ListAllDepositsHandler : IRequestHandler<ListAllDepositsQuery, IReadOnlyList<DepositAccount>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public ListAllDepositsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper; 
        }
        public async Task<IReadOnlyList<DepositAccount>> Handle(ListAllDepositsQuery request, CancellationToken cancellationToken)
        {
            var depositAccountSpecification = new DepositAccountSpecification();
            var depositAccounts = await _unitOfWork.Repository<DepositAccount>()
                .ListAllWithSpecAsync(depositAccountSpecification);
            var depositAccountsList =  new List<DepositAccount>();

            foreach (var depositAccount in depositAccounts)
            {
                depositAccountsList.Add(depositAccount);
                
            }
            return depositAccountsList;
        }
    }
}