
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestApi.Models.UserModels;
using TestApi.Services.SettingHelpers;

namespace TestApi.Services.UserRepo
{
	public interface IUserService<T> : IService<User>
	{
	}
}
