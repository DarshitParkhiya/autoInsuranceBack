using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestApi.Services.Common
{
	public class CommonService<T> : ICommonService<T>
	{
		private readonly ICommonRepository<T> _commonRepository;
		
		public CommonService(ICommonRepository<T> commonRepository)
		{
			_commonRepository = commonRepository;
		}
		public async Task Add(T model)
		{
			try
			{
				await _commonRepository.Collection.InsertOneAsync(model);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<bool> Delete(string id)
		{
			try
			{
				
				var parameterExpression = Expression.Parameter(typeof(T), "object");
				var propertyOrFieldExpression = Expression.PropertyOrField(parameterExpression, "_id");
				var equalityExpression = Expression.Equal(propertyOrFieldExpression, Expression.Constant(id, typeof(string)));
				var lambdaExpression = Expression.Lambda<Func<T, bool>>(equalityExpression, parameterExpression);

				DeleteResult deleteResult = await _commonRepository.Collection.DeleteOneAsync(lambdaExpression);
				return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<IEnumerable<T>> GetAll()
		{
			try
			{
				return await _commonRepository.Collection.Find(x => true).ToListAsync();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<T> GetByID(string id)
		{
			try
			{
				var parameterExpression = Expression.Parameter(typeof(T), "object");
				var propertyOrFieldExpression = Expression.PropertyOrField(parameterExpression, "_id");
				var equalityExpression = Expression.Equal(propertyOrFieldExpression, Expression.Constant(id, typeof(string)));
				var lambdaExpression = Expression.Lambda<Func<T, bool>>(equalityExpression, parameterExpression);

				return await _commonRepository.Collection.Find(lambdaExpression).FirstOrDefaultAsync();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<bool> UpdatebyID(T model, string id)
		{
			try
			{
				var parameterExpression = Expression.Parameter(typeof(T), "object");
				var propertyOrFieldExpression = Expression.PropertyOrField(parameterExpression, "_id");
				var equalityExpression = Expression.Equal(propertyOrFieldExpression, Expression.Constant(id, typeof(string)));
				var lambdaExpression = Expression.Lambda<Func<T, bool>>(equalityExpression, parameterExpression);

				ReplaceOneResult updateResult = await _commonRepository
				.Collection.ReplaceOneAsync(lambdaExpression, model);

				return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Task<bool> Update(T model)
		{
			throw new NotImplementedException();
		}
	}
}
