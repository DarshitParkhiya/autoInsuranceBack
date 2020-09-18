using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestApi.Services.SettingHelpers
{
	public interface IService<T>
	{
		Task<IEnumerable<T>> GetAll();
		Task<T> GetByID(string id);
		Task Add(T model);
		Task<bool> Update(T model);
		Task<bool> Delete(string id);
	}
}