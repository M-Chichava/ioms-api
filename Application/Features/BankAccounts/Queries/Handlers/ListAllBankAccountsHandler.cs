using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.BankAccounts.Queries.RequestModels;
using Application.Features.Users.Queries.RequestModels;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.BankAccounts.Queries.Handlers
{
    public class ListAllBankAccountsHandler : IRequestHandler< ListAllBankAccountsQuery, IReadOnlyList<BankAccount>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public ListAllBankAccountsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper; 
        }
        public async Task<IReadOnlyList<BankAccount>> Handle(ListAllBankAccountsQuery request, CancellationToken cancellationToken)
        { 
            var bankAccounts = await _unitOfWork.Repository<BankAccount>()
                .GetAllAsync();
            var bankAccountsList = new List<BankAccount>();

            foreach (var bankAccount in bankAccounts)
            {
                bankAccountsList.Add(bankAccount);
                
            }
            return bankAccountsList;
        }
    }
}