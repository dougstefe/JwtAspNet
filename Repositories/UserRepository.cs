using JwtAspNet.Models;
using JwtAspNet.Repositories.Interfaces;

namespace JwtAspNet.Repositories;

public class UserRepository : IUserRepository{
    private IEnumerable<User> _users => new List<User> {
        new User(1, "mustang@jwtaspnet.com", "must@ng", "Mustang", new[] {"user", "admin"}),
        new User(2, "edward.elric@jwtaspnet.com", "3dw@rd", "Edward Elric", new[] {"user"}),
        new User(3, "alfonse.elric@jwtaspnet.com", "@lph0ns3", "Alphone Elric", new[] {"user"})
    };
    public User? FindByEmail(string email) {
        return _users.SingleOrDefault(x => x.Email == email);
    }
}