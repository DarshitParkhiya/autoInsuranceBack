namespace TestApi.Models.Settings
{
	public interface IApiConnectionStrings
	{
		string MongoDbConnectionString { get; set; }
		string MongoDbName { get; set; }
	}
	public class ApiConnectionStrings : IApiConnectionStrings
	{
		public ApiConnectionStrings()
		{ }
		public string MongoDbConnectionString { get; set; }
		public string MongoDbName { get; set; }
	}
}
