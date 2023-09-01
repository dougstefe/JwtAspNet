using JwtAspNet.Models;
using JwtAspNet.Repositories.Interfaces;
using JwtAspNet.Services.Interfaces;

namespace JwtAspNet.Services;

public class AuthService : IAuthService {
    private readonly ITokenService _tokenService;
    private readonly IUserRepository _userRepository;

    public AuthService(ITokenService tokenService, IUserRepository userRepository)
    {
        _tokenService = tokenService;
        _userRepository = userRepository;
    }

    public LoginResponse? Auth(LoginRequest login){
        var user = _userRepository.FindByEmail(login.email);
        if(user?.Password == login.password) {
            var token = _tokenService.Create(user);
            return new LoginResponse(token);
        }
        return null;
    }
}