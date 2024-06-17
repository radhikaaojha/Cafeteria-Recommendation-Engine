using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaRecommendationSystem.Services.Interfaces
{
    public interface ICrudBaseService<T>
    {
        Task<int> Add<TModel>(TModel model);

        Task<List<TModel>> GetList<TModel>(string include = null, string filter = null, List<string> sort = null, int limit = 0, int offset = 0, System.Linq.Expressions.Expression<Func<T, bool>> predicate = null);

        Task<TModel> GetById<TModel>(int id, string include = null);

        Task<int> Update<TModel>(int entityId, TModel model, List<string> updatedProperties = null);

        Task<int> Update<TModel>(T baseEntity, TModel model, List<string> updatedProperties = null);

        Task<int> Delete(int id);

        Task<int> DeleteRange(List<T> entities);

        Task<int> AddRange<TModel>(List<TModel> entities);

        Task<int> UpdateRange<TModel>(List<TModel> entities);
    }

}
