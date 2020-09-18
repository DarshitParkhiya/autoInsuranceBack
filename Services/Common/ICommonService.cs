using System.Threading.Tasks;
using TestApi.Services.SettingHelpers;

namespace TestApi.Services.Common
{
    public interface ICommonService<T> : IService<T>
    {
        Task<bool> UpdatebyID(T model, string id);
    }
}
