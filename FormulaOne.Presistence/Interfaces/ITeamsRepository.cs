using FormulaOne.Domain.Entities;
using FormulaOne.Presistence.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Presistence.Interfaces
{
    public interface ITeamsRepository : IGenericRepository<Team>
    {
        Task<int> Save(CancellationToken cancellationToken);
    }
}
