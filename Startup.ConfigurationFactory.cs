using TestApi.Models.Settings;

namespace TestApi
{
    public partial class Startup
	{
		private ApiConnectionStrings BuildApiConnectionStrings()
		{
			return new ApiConnectionStrings()
			{
				MongoDbConnectionString = Configuration.GetSection("ConnectionStrings:MongoDbConnectionString").Value,
				MongoDbName = Configuration.GetSection("ConnectionStrings:MongoDbName").Value
			};
		}

		private AppSettings BuildAppSettings()
		{
			string _kafkaServerID = string.IsNullOrEmpty(Configuration.GetSection("AppSettings:KafkaServerID").Value) ? AppSettings.DefaultKafkaServerID : Configuration.GetSection("AppSettings:KafkaServerID").Value;

			return new AppSettings()
			{
				KafkaServerID = _kafkaServerID				
			};


		}
	}
}


