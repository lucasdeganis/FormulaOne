using FormulaOne.Domain.Entities;
using FormulaOne.Presistence.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Presistence.Interfaces
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        User Authenticate(string userName, string password);
    }
}
