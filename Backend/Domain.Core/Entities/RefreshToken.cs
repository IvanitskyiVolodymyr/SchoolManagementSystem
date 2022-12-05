namespace Domain.Core.Entities
{
    public class RefreshToken
    {
        public int RefreshTokenId { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public int UserId { get; set; }
    }
}
