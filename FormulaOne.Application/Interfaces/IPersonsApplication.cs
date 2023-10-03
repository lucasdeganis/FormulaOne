using FormulaOne.Core.Response;
using FormulaOne.Domain.DTO;

namespace FormulaOne.Application.Interfaces
{
    public interface IPersonsApplication
    {
        Task<Response<List<PersonDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
