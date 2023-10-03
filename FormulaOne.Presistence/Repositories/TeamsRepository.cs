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
    public class TeamsRepository : ITeamsRepository
    {
        protected readonly ApplicationDbContext _applicationDbContext;

        public TeamsRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        #region Metodos Sincronicos
        public int Count()
        {
            throw new NotImplementedException();
        }
        public Team Get(Guid id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Team> GetAll()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Team> GetAllWithPagination(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
        public bool Insert(Team team)
        {
            throw new NotImplementedException();
        }
        public bool Update(Team team)
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
        public async Task<Team> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.
                Set<Team>().AsNoTracking().
                SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        }
        public async Task<IEnumerable<Team>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _applicationDbContext.Set<Team>().AsNoTracking().ToListAsync(cancellationToken);
        }
        public async Task<IEnumerable<Team>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> InsertAsync(Team team)
        {
            _applicationDbContext.Add(team);
            return await Task.FromResult(true);
        }
        public async Task<bool> UpdateAsync(Team team)
        {
            var entity = await _applicationDbContext.Set<Team>().AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(team.Id));
            if (entity == null)
            {
                return await Task.FromResult(false);
            }
                        
            entity.TeamChief = team.TeamChief;
            entity.TechnicalChief = team.TechnicalChief;
            entity.Chassis = team.Chassis;
            entity.PowerUnit = team.PowerUnit;
            entity.FirstTeamEntry = team.FirstTeamEntry;
            entity.WorldChampionships = team.WorldChampionships;
            entity.HighestRaceFinish = team.HighestRaceFinish;
            entity.PolePositions = team.PolePositions;
            entity.FastestLaps = team.FastestLaps;

            _applicationDbContext.Update(entity);
            return await Task.FromResult(true);
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _applicationDbContext.Set<Team>()
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
