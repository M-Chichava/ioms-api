using MediatR;
using Domain;

namespace Application.Features.AdministrativeCosts.Command.RequestModels
{
    public class CreateAdministrativeCostCommand : IRequest<AdministrativeCostAccount>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public long AccountNumber { get; set; }
        
    }
}