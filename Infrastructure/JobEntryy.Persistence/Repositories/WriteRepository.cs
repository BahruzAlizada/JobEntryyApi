using JobEntryy.Application.Repositories;
using JobEntryy.Domain.Common;
using JobEntryy.Persistence.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace JobEntryy.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly Context context;
        public WriteRepository(Context context)
        {
            this.context = context;
        }


        public DbSet<T> Table => context.Set<T>();
        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }
        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }
        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }
        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }
        public async Task<bool> RemoveAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            return Remove(model);
        }
        public bool Update(T model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
        public async Task<int> SaveAsync()
            => await context.SaveChangesAsync();

        public async Task AddAndSaveAsync(T model)
        {
            await AddAsync(model);
            await SaveAsync();
        }

        public async Task UpdateAndSaveAsync(T model)
        {
            Update(model);
            await SaveAsync();
        }
    }
}
