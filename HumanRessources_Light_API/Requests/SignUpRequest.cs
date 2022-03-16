using HumanRessources_Light_API.Models;
using System;

namespace HumanRessources_Light_API.Requests
{
    /// <summary>
    ///  Sign Up request template
    /// </summary>
    public class SignUpRequest
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public SignUpRequest()
        {

        }

    }
}
