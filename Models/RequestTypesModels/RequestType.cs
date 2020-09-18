using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TestApi.Models.RequestTypesModels
{
    public class RequestType
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string type { get; set; }
        public List<string> listItem { get; set; }
        public bool IsActive { get; set; }


    }
}
