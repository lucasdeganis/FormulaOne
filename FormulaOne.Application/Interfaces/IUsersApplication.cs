using FormulaOne.Core.Response;
using FormulaOne.Domain.DTO;

namespace FormulaOne.Application.Interfaces
{
    public interface IUsersApplication
    {
        Response<UserDto> Authenticate(UserDto userDto);
    }
}
