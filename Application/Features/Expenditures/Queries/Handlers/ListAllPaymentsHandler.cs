using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.BankAccounts.Queries.RequestModels;
using Application.Features.Expenditures.Queries.RequestModels;
using Application.Features.Users.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Expenditures.Queries.Handlers
{
    public class ListAllExpendituresHandler : IRequestHandler<ListAllExpendituresQuery, IReadOnlyList<ExpenditureAccount>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public ListAllExpendituresHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper; 
        }
        public async Task<IReadOnlyList<ExpenditureAccount>> Handle(ListAllExpendituresQuery request, CancellationToken cancellationToken)
        {
            var expenditureAccountSpecification = new ExpenditureAccountSpecification();
            var expenditureAccounts = await _unitOfWork.Repository<ExpenditureAccount>()
                .ListAllWithSpecAsync(expenditureAccountSpecification);
            var expenditureAccountsList =  new List<ExpenditureAccount>();

            foreach (var expenditureAccount in expenditureAccounts)
            {
                expenditureAccountsList.Add(expenditureAccount);
                
            }
            return expenditureAccountsList;
        }
    }
}