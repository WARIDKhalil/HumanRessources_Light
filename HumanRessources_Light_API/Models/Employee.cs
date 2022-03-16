using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace HumanRessources_Light_API.Models
{
    public class Employee : Person
    {
        public string RegistrationNumber { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string SupervisorId { get; set; }
        public List<string> SubordinatesIds { get; set; } = new List<string>();

        [BsonConstructor]
        public Employee()
          : base()
        {
            
        }

        [BsonConstructor]
        public Employee(string firstname, string lastname, Gender gender, DateTime birthday,
                        string registrationNumber, DateTime hireDate, decimal salary) 
          : base(firstname, lastname, gender, birthday)
        {
            RegistrationNumber = registrationNumber;
            HireDate = hireDate;
            Salary = salary;
            SubordinatesIds = new List<string>();
        }
    }
}
