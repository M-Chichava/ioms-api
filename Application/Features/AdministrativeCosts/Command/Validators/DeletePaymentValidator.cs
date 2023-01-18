using Domain;
using FluentValidation;

namespace Application.Features.AdministrativeCosts.Command.Validators
{
    public class DeleteAdministrativeCostValidator : AbstractValidator<AdministrativeCost>
    {
        public DeleteAdministrativeCostValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}