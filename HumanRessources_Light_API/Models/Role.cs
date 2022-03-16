using HumanRessources_Light_API.Shared;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace HumanRessources_Light_API.Models
{
    public class Role : IBaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string RoleName { get; set; }
        public List<string> AccountsIds { get; set; }

        [BsonConstructor]
        public Role()
        {

        }

        [BsonConstructor]
        public Role(string roleName)
        {
            Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString(); ;
            RoleName = roleName;
            AccountsIds = new List<string>();
        }

    }
}
