using OnionArchitecture.Application.Bases;

namespace OnionArchitecture.Application.Features.Auth.Exceptions
{
    public class UserAlreadyExistException:BaseException
    {
        public UserAlreadyExistException():base("Böyle bir kullanıcı zaten var!") { }
            
    }
}
