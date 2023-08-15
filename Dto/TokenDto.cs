namespace HrgAuthApi.Dto
{
    public class TokenDto
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresIn { get; set; }
        public DateTime GeneratedAt { get; set; }
    }
}
