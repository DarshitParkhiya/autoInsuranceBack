using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using JsonSubTypes;
using Newtonsoft.Json;

namespace TestApi.Models.StudentModels
{
    public class Student
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string name { get; set; }
        // [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        // public DateTime? dob { get; set; }
        public string email { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string universityId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string coursesId { get; set; }
        public string password { get; set; }
        public string fatherName { get; set; }


    }
}
