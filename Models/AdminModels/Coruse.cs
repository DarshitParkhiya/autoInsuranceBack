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
        public string course { get; set; }
        public float fees { get; set; }


    }
}
