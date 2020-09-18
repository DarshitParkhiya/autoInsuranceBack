namespace TestApi.Models.Settings
{
	public class WebAppConfiguration
	{
		private static string _BasePath { get; set; }
		public static string BasePath
		{
			get { return _BasePath; }
		}
		public static void SetBasePath(string value)
		{
			value = value + @"\";
			_BasePath = value;
		}
	}
}
