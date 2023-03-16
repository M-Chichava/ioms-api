using Domain;
using MediatR;

namespace Application.Features.AdministrativeCosts.Command.RequestModels
{
    public class UpdateAdministrativeCostCommand : IRequest<AdministrativeCostAccount>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public long AccountNumber { get; set; }
    }
}