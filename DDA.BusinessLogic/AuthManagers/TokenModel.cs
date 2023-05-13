namespace DDA.BusinessLogic.AuthManagers
{
    public class TokenModel
    {
        public string Token { get; set; }
        public DateTimeOffset ExpiredAt { get; set; }
    }
}
