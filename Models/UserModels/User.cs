using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TestApi.Models.UserModels
{
    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string UserName { get; set; }
        public string UserEmaildId { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
