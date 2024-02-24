using MediatR;
using System.ComponentModel;

namespace OnionArchitecture.Application.Features.Auth.Command.Login
{
    public class LoginCommandRequest:IRequest<LoginCommandResponse>
    {
        [DefaultValue("ahmetarmutcu2017@gmail.com")]
        public string Email { get; set; }
        [DefaultValue("123321")]
        public string Password { get; set; }
    }
}
