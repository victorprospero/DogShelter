using DogShelter.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace DogShelter.Infrastructure.SeedWork
{
    public abstract class RepositoryBase(DbContext dbContext)
    {
        protected DbContext DbContext { get; } = dbContext;
        
        protected T New<T>() where T : class
        {
            return DbContext.CreateProxy<T>();
        }
        protected virtual async Task<int> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync();
        }
        protected virtual T UpdateOnSave<T>(T TObject) where T : class
        {
            SetUpdateInfo(TObject);
            T currentEntry = DbContext.Set<T>().Update(TObject).Entity;
            return currentEntry;
        }
        protected virtual T CreateOnSave<T>(T TObject) where T : class
        {
            SetCreateInfo(TObject);
            T newEntry = DbContext.Set<T>().Add(TObject).Entity;
            return newEntry;
        }

        #region Private Methods
        private void SetCreateInfo<T>(T TObject) where T : class
        {
            if (TObject is IEntityCanCreate model)
            {
                model.CreatedOn = DateTime.UtcNow;
            }
            SetUpdateInfo(TObject);
        }
        private void SetUpdateInfo<T>(T TObject) where T : class
        {
            if (TObject is IEntityCanUpdate model)
            {
                model.LastUpdated = DateTime.UtcNow;
            }
        }
        #endregion
    }
}
