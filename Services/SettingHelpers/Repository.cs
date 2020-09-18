
using MongoDB.Driver;
using System;
using TestApi.Models.Settings;

namespace TestApi.Services.SettingHelpers
{
	public class Repository<T> : IRepository<T>
	{
		private readonly string _collectionName = "";
		private readonly string _databaseName;
		private readonly MongoClient _client;
		private readonly IApiConnectionStrings _apiConnectionStrings;

		public Repository(IApiConnectionStrings apiConnectionStrings)
		{
			_collectionName = typeof(T).Name;
			_apiConnectionStrings = apiConnectionStrings;
			_client = new MongoClient(_apiConnectionStrings.MongoDbConnectionString);
			_databaseName = _apiConnectionStrings.MongoDbName;
		}

		public IMongoCollection<T> Collection
		{
			get
			{
				if (String.IsNullOrEmpty(_collectionName))
					throw new InvalidOperationException("CollectionName is either null or empty");

				//return Database.GetCollection<T>(_collectionName);
				return Database.GetCollection<T>(_collectionName);
			}
		}

		protected IMongoDatabase Database
		{
			get
			{
				return _client.GetDatabase(_databaseName);
			}
		}
	}
}
