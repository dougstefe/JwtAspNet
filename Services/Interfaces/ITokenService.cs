using JwtAspNet.Models;

namespace JwtAspNet.Services.Interfaces;

public interface ITokenService {
    string Create(User user);
}