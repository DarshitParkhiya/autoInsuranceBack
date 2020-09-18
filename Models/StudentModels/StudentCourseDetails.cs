using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace TestApi.Models.StudentModels
{
    public class StudentCourseDetails
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string universityId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string coursesId { get; set; }
    }
}
