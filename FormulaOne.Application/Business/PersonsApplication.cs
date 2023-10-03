using AutoMapper;
using FormulaOne.Application.Interfaces;
using FormulaOne.Application.Validations;
using FormulaOne.Core.Response;
using FormulaOne.Domain.DTO;
using FormulaOne.Presistence.Interfaces;

namespace FormulaOne.Application.Business
{
    public class PersonsApplication : IPersonsApplication
    {
        private readonly IPersonsRepository _personsRepository;
        private readonly IMapper _mapper;
        private readonly DriversDtoValidator _driversDtoValidator;

        public PersonsApplication(IPersonsRepository personsRepository, IMapper iMapper, DriversDtoValidator driversDtoValidator)
        {
            _personsRepository = personsRepository;
            _mapper = iMapper;
            _driversDtoValidator = driversDtoValidator;
        }

        public async Task<Response<List<PersonDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var response = new Response<List<PersonDto>>();
            try
            {
                var persons = await _personsRepository.GetAllAsync(cancellationToken);
                response.Data = _mapper.Map<List<PersonDto>>(persons);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}
