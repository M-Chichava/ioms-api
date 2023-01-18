using Domain;
using FluentValidation;

namespace Application.Features.Disbursements.Command.Validators
{
    public class DeleteDisbursementValidator : AbstractValidator<Disbursement>
    {
        public DeleteDisbursementValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}