using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApi.Services.SettingHelpers
{
    public interface IRepository<T>
    {
        IMongoCollection<T> Collection { get; }
    }
}
