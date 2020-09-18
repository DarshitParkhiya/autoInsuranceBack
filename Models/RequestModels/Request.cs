using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TestApi.Models.RequestModels
{
    public class Request
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string requestrName { get; set; }
        public string requestrEmail { get; set; }
        public string hostStartDate { get; set; }
        public string hostEndDate { get; set; }
        public string RequestDescription { get; set; }
        public string reqestType { get; set; }
        public List<string> listItem { get; set; }
        public bool IsActive { get; set; }


    }
}
