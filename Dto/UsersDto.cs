using Newtonsoft.Json;

namespace HrgAuthApi.Dto;

public class UsersDto
{
    [JsonProperty()]
    public int UserId { get; set; }
    public string Password { get; set; } = string.Empty;
    public int CompanyID { get; set; }
}
