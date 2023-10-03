using FormulaOne.Domain.Entities;
using FormulaOne.Presistence.Contexts;
using FormulaOne.Presistence.Interfaces;
using FormulaOne.Presistence.Interfaces.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace FormulaOne.Presistence.Repositories
{
    public class DriversRepository : IDriversRepository 
    {
        protected readonly ApplicationDbContext _applicationDbContext;

        public DriversRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        
        #region Metodos Sincronicos
        public int Count()
        {
            throw new NotImplementedException();
        }
        public Driver Get(Guid id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Driver> GetAll()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Driver> GetAllWithPagination(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
        public bool Insert(Driver driver)
        {
            throw new NotImplementedException();
        }
        public bool Update(Driver driver)
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
        public async Task<Driver> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.Drivers
                                .Include(x => x.Person)
                                .Include(x => x.Team)
                                .AsNoTracking()
                                .SingleAsync(x => x.Id.Equals(id), cancellationToken);
        }
        public async Task<IEnumerable<Driver>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _applicationDbContext.Drivers
                                .Include(x => x.Person)
                                .Include(x => x.Team)
                                .AsNoTracking()
                                .ToListAsync(cancellationToken);
        }
        public Task<IEnumerable<Driver>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> InsertAsync(Driver driver)
        {
            _applicationDbContext.Add(driver);

            _applicationDbContext.Entry(driver.Person).State = EntityState.Modified;
            _applicationDbContext.Entry(driver.Team).State = EntityState.Modified;
            _applicationDbContext.Entry(driver).State = EntityState.Added;
            //await _applicationDbContext.Drivers.AddAsync(driver);
            return await Task.FromResult(true);
        }
        public async Task<bool> UpdateAsync(Driver driver)
        {
            var entity = await _applicationDbContext.Set<Driver>().AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(driver.Id));
            if (entity == null)
            {
                return await Task.FromResult(false);
            }

            entity.Points = driver.Points;

            _applicationDbContext.Update(entity);
            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _applicationDbContext.Set<Driver>()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id.Equals(id));

            if (entity == null)
            {
                return await Task.FromResult(false);
            }

            _applicationDbContext.Remove(entity);
            return await Task.FromResult(true);
        }
        #endregion

        public async Task<int> Save(CancellationToken cancellationToken)
        {
            return await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
