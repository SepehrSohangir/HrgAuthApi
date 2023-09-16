namespace HrgAuthApi.Dto
{
    public class FailedResponseDto
    {
        public string Status { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public Dictionary<string, string> Errors { get; set; } = new Dictionary<string, string>();
        public int StatusCode { get; set; }
    }
}
