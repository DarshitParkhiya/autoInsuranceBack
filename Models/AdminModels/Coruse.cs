using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using JsonSubTypes;
using Newtonsoft.Json;

namespace TestApi.Models.AdminModels
{
    public class Course
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string course { get; set; }
        public float fees { get; set; }
        public Course()
        {
            this._id = ObjectId.GenerateNewId().ToString();
        }
    }



}
