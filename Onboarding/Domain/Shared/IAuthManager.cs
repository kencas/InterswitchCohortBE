using Domain.Aggregate;

namespace Domain.Shared
{
    public interface IAuthManager
    {
        Task<string> CreateTokenAsync(User user);
        string HashPasword(string password);
        bool VerifyHash(string password, string passwordHash);
    }
}
