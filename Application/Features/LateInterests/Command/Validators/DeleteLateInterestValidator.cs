using Domain;
using FluentValidation;

namespace Application.Features.Deposits.Command.Validators
{
    public class DeleteLateInterestValidator : AbstractValidator<LateInterest>
    {
        public DeleteLateInterestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}