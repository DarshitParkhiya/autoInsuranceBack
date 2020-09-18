using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TestApi.Models.AssetModels
{
    public class PumpstationModel : Asset
    {
        public string serialNo { get; set; }

        public string actualNo { get; set; }
    }
}
