using FluentValidation;
using Frutas.Models.Dto;

namespace Frutas.Models.Validator {
    public class FrutaValidator : AbstractValidator<FrutaDto> {
        public FrutaValidator () {
            RuleFor (Fruta => Fruta.Nome)
                .NotEmpty ().WithMessage ("O campo {PropertyName} precisa ser fornecido");
            RuleFor (Fruta => Fruta.Descricao)
                .NotEmpty ().WithMessage ("O campo {PropertyName} precisa ser fornecido");
            RuleFor (Fruta => Fruta.Foto)
                .NotEmpty ().WithMessage ("O campo {PropertyName} precisa ser fornecido");
            RuleFor (Fruta => Fruta.Quantidade).
                GreaterThan (-1).WithMessage ("O campo {PropertyName} não pode ser menor que zero");
            RuleFor(Fruta => Fruta.Valor).
                GreaterThan(-1).WithMessage("O campo {PropertyName} não pode ser menor que zero");
        }
    }
}