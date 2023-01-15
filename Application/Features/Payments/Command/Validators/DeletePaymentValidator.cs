using Domain;
using FluentValidation;

namespace Application.Features.Payments.Command.Validators
{
    public class DeletePaymentValidator : AbstractValidator<Payment>
    {
        public DeletePaymentValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}