using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using OnionArchitecture.Application.Bases;
using OnionArchitecture.Application.Features.Auth.Rules;
using OnionArchitecture.Application.Interfaces.AutoMapper;
using OnionArchitecture.Application.Interfaces.Tokens;
using OnionArchitecture.Application.Interfaces.UnitOfWorks;
using OnionArchitecture.Domain.Entites;
using System.IdentityModel.Tokens.Jwt;

namespace OnionArchitecture.Application.Features.Auth.Command.Login
{
    public class LoginCommandHandler:BaseHandler,IRequestHandler<LoginCommandRequest,LoginCommandResponse>
    {
        private readonly AuthRules _authRules;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;

        public LoginCommandHandler(AuthRules authRules,IConfiguration configuration,ITokenService tokenService,UserManager<User> userManager,IMapper mapper, IUnitOfWork unitOfWork,IHttpContextAccessor httpContextAccessor):base(mapper, unitOfWork, httpContextAccessor)
        {
            _authRules = authRules;
            _configuration = configuration;
            _tokenService = tokenService;
            _userManager = userManager;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await _userManager.FindByEmailAsync(request.Email);
            bool checkPassword = await _userManager.CheckPasswordAsync(user, request.Password);

            await _authRules.EmailOrPasswordShouldNotBeInvalid(user, checkPassword);

            var roles = await _userManager.GetRolesAsync(user);

            JwtSecurityToken token = await _tokenService.CreateToken(user, roles);

            string refreshToken = _tokenService.GenerateRefreshToken();

           _= int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

            await _userManager.UpdateAsync(user);
            await _userManager.UpdateSecurityStampAsync(user);

            string _token=new JwtSecurityTokenHandler().WriteToken(token);

            await _userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);

            return new()
            {
                Token = _token,
                RefreshToken = refreshToken,
                Expiration = token.ValidTo
            };
        }
    }
}
