using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace TestApi.Models.StudentModels
{
    public class StudentAuth
    {        
        public string emailId { get; set; }

        public string password { get; set; }
    }
}
