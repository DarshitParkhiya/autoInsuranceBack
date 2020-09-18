
using TestApi.Models.AssetModels;
using TestApi.Models.Settings;
using TestApi.Services.SettingHelpers;


namespace TestApi.Services.AssetRepo
{
	public class AssetRepository : Repository<Asset>, IAssetRepository
	{
		public AssetRepository(IApiConnectionStrings apiConnectionStrings) : base(apiConnectionStrings)
		{ }        
    }
}
