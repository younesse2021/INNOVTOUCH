using Newtonsoft.Json;
namespace Shared.DTO.InnovTouch.DTO
{
    public  class JwtToken
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
