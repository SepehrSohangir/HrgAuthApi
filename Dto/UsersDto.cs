namespace HrgAuthApi.Dto;

public class UsersDto
{
    public int UserId { get; set; }
    public short GroupCode { get; set; }
    public byte[] Password { get; set; } = new byte[32];
    public int CompanyID { get; set; }
}
