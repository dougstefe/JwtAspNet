using JwtAspNet.Models;

namespace JwtAspNet.Services.Interfaces;

public interface IAuthService {
    LoginResponse? Auth(LoginRequest login);
}