using Dentist.Application.Common.Models;
using Dentist.Domain;

namespace Dentist.Application.Common.Interfaces
{
    public interface IRepository
    {
        Task<T> GetById<T>(int id) where T : BaseEntity;

        Task<List<T>> GetAll<T>() where T : BaseEntity;

        Task SaveChangesAsync();

        void Add<T>(T entity) where T : BaseEntity;

        Task<T> Delete<T>(int id) where T : BaseEntity;

        Task<PaginatedResult<TDto>> GetPagedData<TEntity, TDto>(PagedRequest pagedRequest) 
            where TEntity : BaseEntity 
            where TDto : class;
    }
}
