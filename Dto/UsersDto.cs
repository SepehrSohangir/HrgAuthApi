namespace HrgAuthApi.Dto;

public class UsersDto
{
    public int UserId { get; set; }
    public string Password { get; set; } = string.Empty;
    public int CompanyID { get; set; }
}
