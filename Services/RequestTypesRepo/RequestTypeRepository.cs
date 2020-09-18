
using TestApi.Models.RequestTypesModels;
using TestApi.Models.Settings;
using TestApi.Services.SettingHelpers;


namespace TestApi.Services.RequestTypesRepo
{
	public class RequestTypeRepository : Repository<RequestType>, IRequestTypeRepository
	{
		public RequestTypeRepository(IApiConnectionStrings apiConnectionStrings) : base(apiConnectionStrings)
		{ }
	}
}
