namespace Authenticator.API.V1.Models
{
    public class ValidationApiModel
    {
        public string Status { get => Messages == null || !Messages.Any() ? "OK" : "Error"; }
        public string[]? Messages { get; set; }
        public string? Token { get; set; }
    }
}
