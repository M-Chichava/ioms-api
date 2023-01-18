using Application.Features.LateInterests.Command.RequestModels;
using FluentValidation;

namespace Application.Features.LateInterests.Command.Validators
{
    public class CreateLateInterestValidator : AbstractValidator<CreateLateInterestCommand>
    {
        public CreateLateInterestValidator()
        {
            RuleFor(x => x.Amount).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.AccountNumber).NotEmpty();
        }
    }
}