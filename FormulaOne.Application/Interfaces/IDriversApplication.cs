using FormulaOne.Core.Response;
using FormulaOne.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Application.Interfaces
{
    public interface IDriversApplication
    {
        Task<Response<List<DriverDto>>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Response<DriverDto>> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Response<bool>> InsertAsync(DriverDto driverDto, CancellationToken cancellationToken = default);
    }
}
