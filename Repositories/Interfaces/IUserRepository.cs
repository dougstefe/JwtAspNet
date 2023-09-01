using JwtAspNet.Models;

namespace JwtAspNet.Repositories.Interfaces;

public interface IUserRepository {
    User? FindByEmail(string email);
}