using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using JsonSubTypes;
using Newtonsoft.Json;

namespace TestApi.Models.AssetModels
{
    // [BsonDiscriminator(Required = true)]

    // [BsonKnownTypes(typeof(OrganizationModel), typeof(PumpstationModel))]
    [JsonConverter(typeof(JsonSubtypes), "assetType")]
    [JsonSubtypes.KnownSubType(typeof(OrganizationModel), AssetTypeEnum.Organization)]
    public class Asset
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string assetName { get; set; }
        public string organizationId { get; set; }
        public List<string> parentAssetId { get; set; }
        public AssetTypeEnum assetType { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime createdDate { get; set; }


    }
}
