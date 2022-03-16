namespace HumanRessources_Light_API.Requests
{
    /// <summary>
    ///     Sign In request template
    /// </summary>
    public class SignInRequest
    {
        public string login { get; set; }
        public string password { get; set; }

        public SignInRequest()
        {

        }
    }
}
