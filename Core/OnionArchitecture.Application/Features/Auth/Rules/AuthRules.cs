using OnionArchitecture.Application.Bases;
using OnionArchitecture.Domain.Entites;
using OnionArchitecture.Application.Features.Auth.Exceptions;

namespace OnionArchitecture.Application.Features.Auth.Rules
{
    public class AuthRules:BaseRules
    {
        public Task UserShouldNotBeExist(User ? user)
        {
            if (user is not null) throw new UserAlreadyExistException();
            return Task.CompletedTask;
        }
        public Task EmailOrPasswordShouldNotBeInvalid(User?user,bool checkPassword)
        {
            if (user is null || !checkPassword) throw new EmailOrPasswordShouldNotBeInvalidException();
            return Task.CompletedTask;
        }
        public Task RefreshTokenShouldNotBeExpired(DateTime? expiryDate)
        {
            if (expiryDate <= DateTime.Now)
                throw new RefreshTokenShouldNotBeExpiredException();

            return Task.CompletedTask;
        }
        public Task EmaillAddressShouldBeValid(User? user)
        {
            if (user is null) throw new EmaillAddressShouldBeValidException();

            return Task.CompletedTask;
        }
    }
}
