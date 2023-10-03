using FormulaOne.Domain.Entities;
using FormulaOne.Presistence.Contexts;
using FormulaOne.Presistence.Interfaces;
using FormulaOne.Presistence.Interfaces.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Presistence.Repositories
{
    public class PersonsRepository : IPersonsRepository
    {
        protected readonly ApplicationDbContext _applicationDbContext;

        public PersonsRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        #region Metodos Sincronicos
        public int Count()
        {
            throw new NotImplementedException();
        }
        public Person Get(Guid id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Person> GetAll()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Person> GetAllWithPagination(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
        public bool Insert(Person person)
        {
            throw new NotImplementedException();
        }
        public bool Update(Person person)
        {
            throw new NotImplementedException();
        }
        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Metodos Asincronicos
        public async Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<Person> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.
                Set<Person>().AsNoTracking().
                SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        }
        public async Task<IEnumerable<Person>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _applicationDbContext.Set<Person>().AsNoTracking().ToListAsync(cancellationToken);
        }
        public async Task<IEnumerable<Person>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> InsertAsync(Person person)
        {
            _applicationDbContext.Add(person);
            return await Task.FromResult(true);
        }
        public async Task<bool> UpdateAsync(Person person)
        {
            var entity = await _applicationDbContext.Set<Person>().AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(person.Id));
            if (entity == null)
            {
                return await Task.FromResult(false);
            }

            entity.Name = person.Name;
            entity.LastName = person.LastName;
            entity.CountryCode = person.CountryCode;
            entity.DateOfBirth = person.DateOfBirth;
            entity.PlaceOfBirth = person.PlaceOfBirth;

            _applicationDbContext.Update(entity);
            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _applicationDbContext.Set<Person>()
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
