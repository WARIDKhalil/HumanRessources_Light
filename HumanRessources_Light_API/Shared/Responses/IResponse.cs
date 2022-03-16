namespace HumanRessources_Light_API.Shared.Responses
{
    /// <summary>
    ///     Shared properties and methods with all responses types
    /// </summary>
    public interface IResponse
    {
        public string Message { get; set; }
        public int Status { get; set; }
        public void SetStatus(int status, string message);
    }
}
