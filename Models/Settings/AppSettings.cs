namespace TestApi.Models.Settings
{
	public interface IAppSettings
	{
		string KafkaServerID { get; set; }
	}
	public class AppSettings : IAppSettings
	{
		public const string DefaultKafkaServerID = "192.168.1.172:9092";
		public string KafkaServerID { get; set; }
	}
}
