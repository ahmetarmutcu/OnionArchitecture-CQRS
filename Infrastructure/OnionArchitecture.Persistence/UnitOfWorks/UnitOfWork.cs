using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Application.Interfaces.Repositories;
using OnionArchitecture.Application.Interfaces.UnitOfWorks;
using OnionArchitecture.Persistence.Context;
using OnionArchitecture.Persistence.Repositories;

namespace OnionArchitecture.Persistence.UnitOfWorks
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_dbContext);

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(_dbContext);

        public Task<int> SaveAsync() => _dbContext.SaveChangesAsync();
        public int Save() => _dbContext.SaveChanges();
        public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();
        
    }
}
