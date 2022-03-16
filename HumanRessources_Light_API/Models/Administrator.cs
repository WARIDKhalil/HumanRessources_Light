using MongoDB.Bson.Serialization.Attributes;
using System;

namespace HumanRessources_Light_API.Models
{
    public class Administrator : Person
    {

        [BsonConstructor]
        public Administrator()
          : base()
        {

        }

        [BsonConstructor]
        public Administrator(string firstname, string lastname, Gender gender, DateTime birthday)
          : base(firstname, lastname, gender, birthday)
        {

        }

    }
}
