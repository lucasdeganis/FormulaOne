using FluentValidation;
using FormulaOne.Domain.DTO;

namespace FormulaOne.Application.Validations
{
    public class DriversDtoValidator : AbstractValidator<DriverDto>
    {
        public DriversDtoValidator()
        {
            RuleFor(u => u.Season).NotNull().NotEmpty();
            RuleFor(u => u.Category).NotNull().NotEmpty();
            RuleFor(u => u.NumberCar).NotNull().NotEmpty();
            RuleFor(u => u.Team).NotNull().NotEmpty();
            RuleFor(u => u.Person).NotNull().NotEmpty();
        }
    }
}
