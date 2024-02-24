using FluentValidation;

namespace OnionArchitecture.Application.Features.Auth.Command.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(2)
                .WithName("İsim soyisim");
            RuleFor(x => x.Email)
               .NotEmpty()
               .MaximumLength(60)
               .MinimumLength(8)
               .EmailAddress()
               .WithName("E-posta Adresi");

            RuleFor(x => x.Password)
           .MinimumLength(6)
           .WithName("Parola");

            RuleFor(x => x.ConfirmPassword)
           .MinimumLength(6)
           .Equal(x => x.Password)
           .WithName("Parola Tekrarı");
        }
    }
}
