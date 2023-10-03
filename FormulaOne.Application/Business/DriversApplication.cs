using AutoMapper;
using FormulaOne.Application.Interfaces;
using FormulaOne.Application.Validations;
using FormulaOne.Core.Response;
using FormulaOne.Domain.DTO;
using FormulaOne.Domain.Entities;
using FormulaOne.Presistence.Interfaces;

namespace FormulaOne.Application.Business
{
    public class DriversApplication : IDriversApplication
    {
        private readonly IDriversRepository _driversRepository;
        private readonly IMapper _mapper;
        private readonly DriversDtoValidator _driversDtoValidator;

        public DriversApplication(IDriversRepository driversRepository, IMapper iMapper, DriversDtoValidator driversDtoValidator)
        {
            _driversRepository = driversRepository;
            _mapper = iMapper;
            _driversDtoValidator = driversDtoValidator;
        }

        public async Task<Response<DriverDto>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var response = new Response<DriverDto>();
            
            try
            {
                var driverDto = await _driversRepository.GetAsync(id, cancellationToken);
                if (driverDto is null)
                {
                    response.IsSuccess = true;
                    response.Message = "Driver no existe...";
                    return response;
                }

                response.Data = _mapper.Map<DriverDto>(driverDto);
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!!!";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<Response<List<DriverDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var response = new Response<List<DriverDto>>();
            try
            {
                var divrers = await _driversRepository.GetAllAsync(cancellationToken);
                response.Data = _mapper.Map<List<DriverDto>>(divrers);
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

        public async Task<Response<bool>> InsertAsync(DriverDto driverDto, CancellationToken cancellationToken = default)
        {
            var response = new Response<bool>();
            try
            {
                var validation = _driversDtoValidator.Validate(driverDto);
                if (!validation.IsValid)
                {
                    response.Message = "Errores de Validación";
                    response.Errors = validation.Errors;
                    return response;
                }
                Driver driver = _mapper.Map<Driver>(driverDto);
                await _driversRepository.InsertAsync(driver);

                response.Data = await _driversRepository.Save(cancellationToken) > 0;
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!!";
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
