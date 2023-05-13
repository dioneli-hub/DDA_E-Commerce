namespace DDA.BusinessLogic.AuthManagers
{
    public class HashModel
    {
        public byte[] Salt { get; set; }
        public byte[] Hash { get; set; }
    }
}
