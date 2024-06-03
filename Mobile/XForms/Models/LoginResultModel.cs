using Newtonsoft.Json;

namespace XForms.Models
{
    public partial class LoginResultDataModel
    {
        [JsonProperty("generateCustomerToken")]
        public GenerateCustomerToken GenerateCustomerToken { get; set; }
    }

    public partial class RefreshTokenResultDataModel
    {
        [JsonProperty("refreshCustomerToken")]
        public GenerateCustomerToken RefreshCustomerToken { get; set; }
    }

    public partial class GenerateCustomerToken
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
