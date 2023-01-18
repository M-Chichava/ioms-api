using Application.Features.Outgoings.Command.RequestModels;
using FluentValidation;

namespace Application.Features.Outgoings.Command.Validators
{
    public class CreateOutgoingValidator : AbstractValidator<CreateOutgoingCommand>
    {
        public CreateOutgoingValidator()
        {
            RuleFor(x => x.Amount).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.AccountNumber).NotEmpty();
        }
    }
}