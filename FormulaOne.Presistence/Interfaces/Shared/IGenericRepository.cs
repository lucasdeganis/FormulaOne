using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Presistence.Interfaces.Shared
{
    public interface IGenericRepository<T> where T : class
    {
        #region Métodos Síncronos
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(Guid id);
        T Get(Guid id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllWithPagination(int pageNumber, int pageSize);
        int Count();
        #endregion

        #region Métodos Asíncronos
        Task<bool> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
        Task<T> GetAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        Task<int> CountAsync();
        #endregion
    }
}
