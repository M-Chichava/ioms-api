using Domain;
using MediatR;

namespace Application.Features.Expenditures.Command.RequestModels
{
    public class DeleteExpenditureCommand : IRequest<ExpenditureAccount>
    {
        public int Id { get; set; }
    }
}