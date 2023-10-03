using Dapper;
using FormulaOne.Domain.DTO;
using FormulaOne.Domain.Entities;
using FormulaOne.Presistence.Contexts;
using FormulaOne.Presistence.Interfaces;
using System.Data;

namespace FormulaOne.Presistence.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        protected readonly DapperContext _context;
        public UsersRepository(DapperContext context)
        {
            _context = context;
        }
        
        public User Authenticate(string userName, string password)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "GetUsersByUserAndPassword";
                var parameters = new DynamicParameters();
                parameters.Add("UserName", userName);
                parameters.Add("Password", password);

                var user = connection.QuerySingle<User>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return user;
            }
        }
        
        #region Metodos Sincronicos
        public int Count()
        {
            throw new NotImplementedException();
        }
        public User Get(Guid id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<User> GetAllWithPagination(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
        public bool Insert(User entity)
        {
            throw new NotImplementedException();
        }
        public bool Update(User entity)
        {
            throw new NotImplementedException();
        }
        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Metodos Asincronicos
        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }
        public Task<User> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<User>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
        public Task<bool> InsertAsync(User entity)
        {
            throw new NotImplementedException();
        }
        public Task<bool> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
