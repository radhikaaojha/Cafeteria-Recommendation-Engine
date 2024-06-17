using AutoMapper;
using CafeteriaRecommendationSystem.Services.Interfaces;
using CMS.Common.Exceptions;
using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CafeteriaRecommendationSystem.Services
{
    public class CrudBaseService<T> : ICrudBaseService<T> where T : class
    {
        private readonly ICrudBaseRepository<T> _crudBaseRepository;
        private readonly IMapper _mapper;

        protected virtual string ModifiableInclude => null;
        public CrudBaseService(ICrudBaseRepository<T> repository, IMapper mapper)
        {
            _crudBaseRepository = repository;
            _mapper = mapper;
        }

        public virtual async Task<int> Add<TModel>(TModel model)
        {
            if (model == null)
            {
                Dictionary<string, string> paramDict = new Dictionary<string, string>()
                {
                    { nameof(model), "null" }
                };

                throw new ApiException(ErrorResponse.ErrorEnum.NullObject);
            }

            return await _crudBaseRepository.Add(_mapper.Map<TModel, T>(model));
        }

        public virtual async Task<List<TModel>> GetList<TModel>(string include = null, string filter = null, List<string> sort = null, int limit = 0, int offset = 0, System.Linq.Expressions.Expression<Func<T, bool>> predicate = null)
        {
            return _mapper.Map<List<T>, List<TModel>>(await _crudBaseRepository.GetList(include, filter, sort, limit, offset, predicate));
        }

        public virtual async Task<TModel> GetById<TModel>(int id, string include = null)
        {
            if (id <= 0)
            {
                Dictionary<string, string> paramDict = new Dictionary<string, string>()
                {
                    { nameof(id), id.ToString() },
                };

                throw new ApiException(ErrorResponse.ErrorEnum.Validation);
            }

            var entity = await _crudBaseRepository.GetById(id, include);
            return _mapper.Map<T, TModel>(entity);
        }

        public virtual async Task<int> Update<TModel>(int entityId, TModel model, List<string> updatedProperties = null)
        {
            if (entityId <= 0 || model == null)
            {
                Dictionary<string, string> paramDict = new Dictionary<string, string>()
                {
                    { nameof(entityId), entityId.ToString() },
                    { nameof(model), model == null?"null":JsonSerializer.Serialize(model) },
                };

                throw new ApiException(ErrorResponse.ErrorEnum.Validation);
            }

            T baseEntity = await _crudBaseRepository.GetById(entityId, ModifiableInclude);

            return await Update<TModel>(baseEntity, model, updatedProperties);
        }

        public virtual async Task<int> Update<TModel>(T baseEntity, TModel model, List<string> updatedProperties = null)
        {
            if (baseEntity == null)
            {
                throw new ApiException(ErrorResponse.ErrorEnum.NotFound);
            }

            return await _crudBaseRepository.Update(baseEntity);
        }


        public virtual async Task<int> Delete(int id)
        {
            if (id <= 0)
            {
                Dictionary<string, string> paramDict = new Dictionary<string, string>()
                {
                    { nameof(id), id.ToString() },
                };

                throw new ApiException(ErrorResponse.ErrorEnum.Validation);
            }

            return await _crudBaseRepository.Delete(id);
        }

        public virtual async Task<int> DeleteRange(List<T> entities)
        {
            if (entities == null || entities.Count <= 0)
            {
                Dictionary<string, string> paramDict = new Dictionary<string, string>()
                {
                   { nameof(entities), JsonSerializer.Serialize(entities) },
                };

                throw new ApiException(ErrorResponse.ErrorEnum.NullObject);
            }

            return await _crudBaseRepository.DeleteRange(entities);
        }

        public virtual async Task<int> AddRange<TModel>(List<TModel> model)
        {
            if (model == null || model.Count <= 0)
            {
                Dictionary<string, string> paramDict = new Dictionary<string, string>()
                {
                   { nameof(model), JsonSerializer.Serialize(model) },
                };

                throw new ApiException(ErrorResponse.ErrorEnum.NullObject);
            }
            var entities = _mapper.Map<List<T>>(model);
            return await _crudBaseRepository.AddRange(entities);
        }

        public virtual async Task<int> UpdateRange<TModel>(List<TModel> model)
        {
            if (model == null || model.Count <= 0)
            {
                Dictionary<string, string> paramDict = new Dictionary<string, string>()
                {
                   { nameof(model), JsonSerializer.Serialize(model) },
                };

                throw new ApiException(ErrorResponse.ErrorEnum.NullObject);
            }
            var entities = _mapper.Map<List<T>>(model);

            return await _crudBaseRepository.UpdateRange(entities);
        }

    }

}
