using FormulaOne.Core.Response;
using FormulaOne.Domain.DTO;

namespace FormulaOne.Application.Interfaces
{
    public interface ITeamsApplication
    {
        Task<Response<List<TeamDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
