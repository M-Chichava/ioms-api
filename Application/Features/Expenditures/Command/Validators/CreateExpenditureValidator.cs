using Application.Features.Expenditures.Command.RequestModels;
using FluentValidation;

namespace Application.Features.Expenditures.Command.Validators
{
    public class CreateExpenditureValidator : AbstractValidator<CreateExpenditureCommand>
    {
        public CreateExpenditureValidator()
        {
            RuleFor(x => x.Amount).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.AccountNumber).NotEmpty();
        }
    }
}