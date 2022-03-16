using HumanRessources_Light_API.Shared;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace HumanRessources_Light_API.Models
{

    public enum Gender
    {
        Male,
        Female,
        None
    };

    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(Employee), typeof(Administrator))]
    [BsonIgnoreExtraElements]
    public class Person : IBaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string AccountId { get; set; }

        [BsonConstructor]
        public Person()
        {
            
        }

        [BsonConstructor]
        public Person(string firstname, string lastname, Gender gender, DateTime birthday)
        {
            Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
            Firstname = firstname;
            Lastname = lastname;
            Gender = gender;
            Birthday = birthday;
        }


    }
}
