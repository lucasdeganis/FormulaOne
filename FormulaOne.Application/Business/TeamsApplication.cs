using AutoMapper;
using FormulaOne.Application.Interfaces;
using FormulaOne.Application.Validations;
using FormulaOne.Core.Response;
using FormulaOne.Domain.DTO;
using FormulaOne.Presistence.Interfaces;

namespace FormulaOne.Application.Business
{
    public class TeamsApplication : ITeamsApplication
    {
        private readonly ITeamsRepository _teamsRepository;
        private readonly IMapper _mapper;
        private readonly DriversDtoValidator _driversDtoValidator;

        public TeamsApplication(ITeamsRepository teamsRepository, IMapper iMapper, DriversDtoValidator driversDtoValidator)
        {
            _teamsRepository = teamsRepository;
            _mapper = iMapper;
            _driversDtoValidator = driversDtoValidator;
        }
        public async Task<Response<List<TeamDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var response = new Response<List<TeamDto>>();
            try
            {
                var persons = await _teamsRepository.GetAllAsync(cancellationToken);
                response.Data = _mapper.Map<List<TeamDto>>(persons);
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
