namespace fiapweb2022.api.Models
{
    public class TokenInfo
    {
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public string? GrantType { get; set; }
        public string? RefreshToken { get; set; }
    }
}
