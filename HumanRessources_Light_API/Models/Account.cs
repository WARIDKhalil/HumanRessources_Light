using HumanRessources_Light_API.Shared;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace HumanRessources_Light_API.Models
{
    public class Account : IBaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string OwnerId { get; set; }
        public string RoleId { get; set; }

        [BsonConstructor]
        public Account()
        {

        }

        [BsonConstructor]
        public Account(string login, string password)
        {
            Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString(); ;
            Login = login;
            Password = password;
        }
    }
}
