using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaRecommendationSystem.Services.Interfaces
{
    public interface ICrudBaseService<T>
    {
        Task<int> Add(T entity);
        Task<List<T>> GetList(string include = null, string filter = null, List<string> sort = null, int limit = 0, int offset = 0, System.Linq.Expressions.Expression<Func<T, bool>> predicate = null);
        Task<T> GetById(int entityId, string include = null);
        Task<int> Update(T entity);
        Task<int> Delete(int entityId);
        Task<int> DeleteRange(List<T> entities);
        Task<int> AddRange(List<T> entities);
        Task<int> UpdateRange(List<T> entities);
    }

}
