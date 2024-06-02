using DummyProject.Application.Contracts;
using DummyProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DummyProject.Infrastructure.Repositories
{
    public class EfRepository<TEntity> : IRepository<TEntity>
     where TEntity : class
    {
        public EfRepository(DummyProjectDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.DbSet = this.Context.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet { get; set; }

        protected DummyProjectDbContext Context { get; set; }

        public IQueryable<TEntity> All() => this.DbSet;

        public IQueryable<TEntity> AllAsNoTracking() => this.DbSet.AsNoTracking();

        public IQueryable<TEntity> AllWithDeleted() => All().IgnoreQueryFilters();

        public IQueryable<TEntity> AllAsNoTrackingWithDeleted() => AllAsNoTracking().IgnoreQueryFilters();

        public Task AddAsync(TEntity entity) => this.DbSet.AddAsync(entity).AsTask();

        public void Update(TEntity entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public void Delete(TEntity entity) => this.DbSet.Remove(entity);

        public Task<int> SaveChangesAsync() => this.Context.SaveChangesAsync();
    }
}
