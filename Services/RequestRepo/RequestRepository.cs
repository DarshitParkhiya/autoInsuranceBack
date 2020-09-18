
using TestApi.Models.RequestModels;
using TestApi.Models.Settings;
using TestApi.Services.SettingHelpers;


namespace TestApi.Services.RequestRepo
{
	public class RequestRepository : Repository<Request>, IRequestRepository
	{
		public RequestRepository(IApiConnectionStrings apiConnectionStrings) : base(apiConnectionStrings)
		{ }
	}
}
