using Application.Features.Deposits.Command.RequestModels;
using FluentValidation;

namespace Application.Features.Deposits.Command.Validators
{
    public class CreateDepositValidator : AbstractValidator<CreateDepositCommand>
    {
        public CreateDepositValidator()
        {
            RuleFor(x => x.Amount).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.AccountNumber).NotEmpty();
        }
    }
}