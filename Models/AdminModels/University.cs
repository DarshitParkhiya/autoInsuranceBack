using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using JsonSubTypes;
using Newtonsoft.Json;

namespace TestApi.Models.AdminModels
{
    public class University
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string universityName { get; set; }
        public List<Course> courses { get; set; }

        public University()
		{
			this._id = ObjectId.GenerateNewId().ToString();
		}


    }
}
