
using TestApi.Models.AdminModels;
using TestApi.Models.Settings;
using TestApi.Services.SettingHelpers;


namespace TestApi.Services.AdminRepo
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        public AdminRepository(IApiConnectionStrings apiConnectionStrings) : base(apiConnectionStrings)
        { }
    }
}
