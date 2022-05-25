using ChallengeAlternativo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAlternativo.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> Get();
        Task<T> GetById(int Id);
        Task<bool> Add(T Entity);
        Task<bool> Update(T Entity);
        Task<bool> Delete(int Id);
    }


    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly GeographicIconsDbContext _context;

        public GenericRepository(GeographicIconsDbContext context)
        {
            _context = context;
        }

        public async Task<List<TEntity>> Get()
        {
            try
            {
                var listEntities = await _context.Set<TEntity>().ToListAsync();

                return listEntities;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<TEntity> GetById(int Id)
        {
            try
            {
                var entity = await _context.Set<TEntity>().FindAsync(Id);

                return entity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Add(TEntity entity)
        {
            if (entity == null)
                return false;
            try
            {
                await _context.Set<TEntity>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Delete(int Id)
        {
            try
            {
                var entity = await GetById(Id);

                if (entity == null)
                    return false;

                _context.Set<TEntity>().Remove(entity);

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Update(TEntity entity)
        {
            if (entity == null)
                return false;
            try
            {
                _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
