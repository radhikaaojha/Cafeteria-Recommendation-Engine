using CafeteriaRecommendationSystem.Services.Interfaces;
using Data_Access_Layer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaRecommendationSystem.Services
{
    public class CrudBaseService<T> : ICrudBaseService<T> where T : class
    {
        private readonly ICrudBaseRepository<T> _repository;

        public CrudBaseService(ICrudBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public Task<int> Add(T entity) => _repository.Add(entity);
        public Task<List<T>> GetList(string include = null, string filter = null, List<string> sort = null, int limit = 0, int offset = 0, System.Linq.Expressions.Expression<Func<T, bool>> predicate = null) => _repository.GetList(include, filter, sort, limit, offset, predicate);
        public Task<T> GetById(int entityId, string include = null) => _repository.GetById(entityId, include);
        public Task<int> Update(T entity) => _repository.Update(entity);
        public Task<int> Delete(int entityId) => _repository.Delete(entityId);
        public Task<int> DeleteRange(List<T> entities) => _repository.DeleteRange(entities);
        public Task<int> AddRange(List<T> entities) => _repository.AddRange(entities);
        public Task<int> UpdateRange(List<T> entities) => _repository.UpdateRange(entities);
    }

}
