using FluentValidation;
using FormulaOne.Domain.DTO;

namespace FormulaOne.Application.Validations
{
    public class UsersDtoValidator : AbstractValidator<UserDto>
    {
        public UsersDtoValidator()
        {
            RuleFor(u => u.UserName).NotNull().NotEmpty();
            RuleFor(u => u.Password).NotNull().NotEmpty();
        }
    }
}
