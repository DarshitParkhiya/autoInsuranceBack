
using TestApi.Models.Settings;
using TestApi.Models.UserModels;
using TestApi.Services.SettingHelpers;


namespace TestApi.Services.UserRepo
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(IApiConnectionStrings apiConnectionStrings) : base(apiConnectionStrings)
		{ }
	}
}
