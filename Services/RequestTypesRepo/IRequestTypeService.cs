
using System.Threading.Tasks;
using TestApi.Models.RequestTypesModels;
using TestApi.Services.SettingHelpers;

namespace TestApi.Services.RequestTypesRepo
{
    public interface IRequestTypeService<T> : IService<RequestType>
    {
        Task<T> GetByReqyestType(string type);
    }
}
