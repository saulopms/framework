using FluentValidation;
using Frutas.Models.Dto;

namespace Frutas.Models.Validator {
    public class CarrinhoValidator : AbstractValidator<CarrinhoDto> {
        public CarrinhoValidator() {
            RuleFor(Carrinho => Carrinho.Itens)
                .NotEmpty()
                .WithMessage("Não é possível salvar o carrinho sem frutas");
        }
    }
}