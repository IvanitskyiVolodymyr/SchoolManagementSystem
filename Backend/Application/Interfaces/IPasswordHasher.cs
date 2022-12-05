namespace Application.Interfaces
{
    public interface IPasswordHasher
    {
        public string CalculateHash(string password, string salt, string pepper, int iteration);
        public string GenerateSalt();
    }
}
