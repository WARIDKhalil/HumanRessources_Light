using HumanRessources_Light_API.Shared;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace HumanRessources_Light_API.Models
{
    public class Department : IBaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string DepartmentName { get; set; }
        public List<string> WorkersIds { get; set; }

        [BsonConstructor]
        public Department()
        {

        }

        [BsonConstructor]
        public Department(string departmentName)
        {
            Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString(); ;
            DepartmentName = departmentName;
            WorkersIds = new List<string>();
        }

    }
}
