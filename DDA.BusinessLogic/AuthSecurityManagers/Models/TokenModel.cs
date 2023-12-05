namespace DDA.BusinessLogic.AuthSecurityManagers.Models
{
    public class TokenModel
    {
        public string Token { get; set; }
        public DateTimeOffset ExpiredAt { get; set; }
    }
}
