namespace HrgAuthApi.Dto
{
    public class SuccessfulResponseDto<T>
    {
        public string Status { get; set; } = string.Empty;
        public int StatusCode { get; set; }
        public T Data { get; set; } = default!;
    }
}
