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
    }
}
