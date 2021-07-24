using FluentValidation;

namespace Auth.Models.Validator {
    public class UserValidator : AbstractValidator<User> {
        public UserValidator () {

            RuleFor(a => a.Username)
                .NotEmpty().WithMessage("O nome do usu�rio precisa ser fornecido");
        }
    }
}