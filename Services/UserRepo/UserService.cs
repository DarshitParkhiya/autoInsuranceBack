using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestApi.Models.UserModels;

namespace TestApi.Services.UserRepo
{
	public class UserService : IUserService<User>
	{

		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task Add(User model)
		{
			try
			{
				await _userRepository.Collection.InsertOneAsync(model);
			}
			catch (Exception ex)
			{
				// log or manage the exception
				throw ex;
			}
		}

		public async Task<bool> Delete(string id)
		{
			try
			{
				FilterDefinition<User> filter = Builders<User>.Filter.Eq(m => m._id, id);

				DeleteResult deleteResult = await _userRepository
													.Collection
													.DeleteOneAsync(filter);

				return deleteResult.IsAcknowledged
					&& deleteResult.DeletedCount > 0;
			}
			catch (Exception ex)
			{
				// log or manage the exception
				throw ex;
			}
		}

		public async Task<IEnumerable<User>> GetAll()
		{
			try
			{
				return await _userRepository.Collection.Find(x => x.IsActive == true).ToListAsync();

			}
			catch (Exception ex)
			{
				// log or manage the exception
				throw ex;
			}
		}

		public async Task<bool> Update(User model)
		{
			try
			{
				ReplaceOneResult updateResult =
			 await _userRepository
							 .Collection
							 .ReplaceOneAsync(
									 filter: g => g._id == model._id,
									 replacement: model);

				return updateResult.IsAcknowledged
								&& updateResult.ModifiedCount > 0;
			}
			catch (Exception ex)
			{
				// log or manage the exception
				throw ex;
			}
		}


		public async Task<User> GetByID(string id)
		{
			try
			{
				return await _userRepository.Collection.Find(x => x._id == id).FirstOrDefaultAsync();

			}
			catch (Exception ex)
			{
				// log or manage the exception
				throw ex;
			}
		}

		
	}
}
