using System.Text.Json.Serialization;

namespace UI.Models
{
    public class LoginApiModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
