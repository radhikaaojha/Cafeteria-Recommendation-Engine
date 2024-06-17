using Data_Access_Layer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    public class CrudBaseRepository<T> : ICrudBaseRepository<T> where T : class
    {
        protected readonly CMSDbContext _context;

        public CrudBaseRepository(CMSDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetList(
            string include = null,
            string filter = null,
            List<string> sort = null,
            int limit = 0,
            int offset = 0,
            Expression<Func<T, bool>> predicate = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (!string.IsNullOrEmpty(include))
            {
                string[] includedList = include.Split(",");

                foreach (var item in includedList)
                {
                    string[] parts = item.Split(".");
                    var prop = typeof(T).GetProperties().Where(p => p.Name.ToLower() == parts[0].ToLower().Trim()).FirstOrDefault();

                    if (prop != null)
                    {
                        parts[0] = prop.Name;
                        query = query.Include(string.Join('.', parts));
                    }
                }
            }

/*            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(filter);
            }

            if (sort != null)
            {
                foreach (var sortField in sort)
                {
                    query = query.OrderBy(sortField);
                }
            }*/

            if (limit > 0)
            {
                query = query.Skip(offset).Take(limit);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetById(int entityId, string include = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (!string.IsNullOrEmpty(include))
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == entityId);
        }

        public async Task<int> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int entityId)
        {
            var entity = await _context.Set<T>().FindAsync(entityId);
            if (entity == null)
            {
                throw new ArgumentException("Entity not found");
            }

            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteRange(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddRange(List<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateRange(List<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
            return await _context.SaveChangesAsync();
        }
    }

}
