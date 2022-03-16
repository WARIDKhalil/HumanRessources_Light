using HumanRessources_Light_API.Models;
using HumanRessources_Light_API.Shared.Responses;

namespace HumanRessources_Light_API.Responses
{
    /// <summary>
    ///     Sign-in response template
    /// </summary>
    public class SignInResponse : IResponse
    {
        public string roleName { get; set; }
        public Person user { get; set; }
        public Account account { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public string Token { get; set; }

        public SignInResponse()
        {

        }

        public void SetStatus(int status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}
