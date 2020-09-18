using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TestApi.Models.AssetModels
{
    public class OrganizationModel : Asset
    {
        public string emailId { get; set; }

        public string address { get; set; }
    }
}
