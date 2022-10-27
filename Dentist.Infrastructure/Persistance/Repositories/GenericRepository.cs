using AutoMapper;
using Dentist.Application.Common.Interfaces;
using Dentist.Domain;
using Dentist.Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Dentist.Infrastructure.Persistance.Repositories
{
    public class GenericRepository : IRepository
    {
        private readonly DentistDbContext _dbContext;
        private readonly IMapper _mapper;

        public GenericRepository(DentistDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Add<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Add(entity);
        }

        public async Task<T> Delete<T>(int id) where T : BaseEntity
        {
            var item = await _dbContext.Set<T>().FindAsync(id);

            if (item == null)
            {
                throw new ValidationException($"Object of type {typeof(T)} with id { id } not found");
            }

            _dbContext.Set<T>().Remove(item);

            return item;
        }

        public async Task<List<T>> GetAll<T>() where T : BaseEntity
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById<T>(int id) where T : BaseEntity
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }  
              
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
