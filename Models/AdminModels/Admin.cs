using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using JsonSubTypes;
using Newtonsoft.Json;

namespace TestApi.Models.AdminModels
{
    public class Admin
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string name { get; set; }
        //[BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        //public DateTime? dob { get; set; }

        public string city { get; set; }

        public List<University> universities { get; set; }


    }
}
