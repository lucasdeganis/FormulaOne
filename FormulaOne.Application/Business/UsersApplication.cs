using AutoMapper;
using FormulaOne.Application.Interfaces;
using FormulaOne.Application.Validations;
using FormulaOne.Core.Response;
using FormulaOne.Domain.DTO;
using FormulaOne.Presistence.Interfaces;

namespace FormulaOne.Application.Business
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        private readonly UsersDtoValidator _usersDtoValidator;

        public UsersApplication(IUsersRepository usersRepository, IMapper iMapper, UsersDtoValidator usersDtoValidator)
        {
            _usersRepository = usersRepository;
            _mapper = iMapper;
            _usersDtoValidator = usersDtoValidator;
        }
        public Response<UserDto> Authenticate(UserDto userDto)
        {
            var response = new Response<UserDto>();
            var validation = _usersDtoValidator.Validate(userDto);

            if (!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Errors = validation.Errors;
                return response;
            }
            try
            {
                var user = _usersRepository.Authenticate(userDto.UserName, userDto.Password);
                response.Data = _mapper.Map<UserDto>(user);
                response.IsSuccess = true;
                response.Message = "Autenticación Exitosa!!!";
            }
            catch (InvalidOperationException)
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}
