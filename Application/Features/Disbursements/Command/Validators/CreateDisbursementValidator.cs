using Application.Features.Disbursements.Command.RequestModels;
using FluentValidation;

namespace Application.Features.Disbursements.Command.Validators
{
    public class CreateDisbursementValidator : AbstractValidator<CreateDisbursementCommand>
    {
        public CreateDisbursementValidator()
        {
            RuleFor(x => x.Amount).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.AccountNumber).NotEmpty();
        }
    }
}