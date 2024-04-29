using DogShelter.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DogShelter.Infrastructure.SeedWork
{
    public abstract class RepositoryBase(DbContext dbContext)
    {
        protected DbContext DbContext { get; } = dbContext;
        
        protected T New<T>() where T : class
        {
            return DbContext.CreateProxy<T>();
        }
        public virtual async Task<int> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync();
        }
        public virtual void CreateOrUpdateOnSave<T>(T TObject) where T : class
        {
            EntityEntry entry = DbContext.Entry(TObject);
            switch (entry.State)
            {
                case EntityState.Detached:
                case EntityState.Added:
                    CreateOnSave(TObject);
                    break;
                case EntityState.Modified:
                    SetUpdateInfo(TObject);
                    break;
            }
        }
        public virtual T CreateOnSave<T>(T TObject) where T : class
        {
            SetCreateInfo(TObject);
            T newEntry = DbContext.Set<T>().Add(TObject).Entity;
            return newEntry;
        }
        public virtual T SetCreateInfo<T>(T TObject) where T : class
        {
            if (TObject is IEntityCanCreate)
            {
                IEntityCanCreate? model = TObject as IEntityCanCreate;
                model.CreatedOn = DateTime.UtcNow;
            }
            SetUpdateInfo(TObject);
            return TObject;
        }
        public virtual T SetUpdateInfo<T>(T TObject) where T : class
        {
            if (TObject is IEntityCanUpdate)
            {
                IEntityCanUpdate? model = TObject as IEntityCanUpdate;
                model.LastUpdated = DateTime.UtcNow;
            }
            return TObject;
        }
    }
}
