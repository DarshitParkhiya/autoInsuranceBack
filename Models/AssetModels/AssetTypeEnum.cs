using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TestApi.Models.AssetModels
{
    public enum AssetTypeEnum
    {
        Organization,
        Area,
        Pumpstation,
        Valve
    }
}
