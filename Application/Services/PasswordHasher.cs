using Application.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public string CalculateHash(string password, string salt, string pepper, int iteration)
        {
            if (iteration <= 0) return password;

            using var sha256 = SHA256.Create();
            var passwordSaltPepper = $"{password}{salt}{pepper}";
            var byteValue = Encoding.UTF8.GetBytes(passwordSaltPepper);
            var byteHash = sha256.ComputeHash(byteValue);
            var hash = Convert.ToBase64String(byteHash);
            return CalculateHash(hash, salt, pepper, iteration - 1);
        }

        public string GenerateSalt()
        {
            using var random = RandomNumberGenerator.Create();
            var byteSalt = new byte[16];
            random.GetBytes(byteSalt);
            var salt = Convert.ToBase64String(byteSalt);
            return salt;
        }
    }
}
