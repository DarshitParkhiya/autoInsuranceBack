

using TestApi.Models.Settings;
using TestApi.Services.SettingHelpers;

namespace TestApi.Services.Common
{
	public class CommonRepository<T> : Repository<T>, ICommonRepository<T>
	{
		public CommonRepository(IApiConnectionStrings apiConnectionStrings) : base(apiConnectionStrings)
		{ }
	}
}
