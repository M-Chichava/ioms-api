using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.BankAccounts.Queries.RequestModels;
using Application.Features.Outgoings.Queries.RequestModels;
using Application.Features.Users.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Outgoings.Queries.Handlers
{
    public class ListAllOutgoingsHandler : IRequestHandler<ListAllOutgoingsQuery, IReadOnlyList<OutgoingAccount>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public ListAllOutgoingsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper; 
        }
        public async Task<IReadOnlyList<OutgoingAccount>> Handle(ListAllOutgoingsQuery request, CancellationToken cancellationToken)
        {
            var outgoingAccountSpecification = new OutgoingAccountSpecification();
            var outgoingAccounts = await _unitOfWork.Repository<OutgoingAccount>()
                .ListAllWithSpecAsync(outgoingAccountSpecification);
            var outgoingAccountsList =  new List<OutgoingAccount>();

            foreach (var outgoingAccount in outgoingAccounts)
            {
                outgoingAccountsList.Add(outgoingAccount);
                
            }
            return outgoingAccountsList;
        }
    }
}