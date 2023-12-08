using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using FluentValidation;

namespace CPF_CACL.GestaoSocio.Domain.Models.Validation
{
    public class TipoPagamentoValidation : AbstractValidator<TipoPagamento>
    {
        public TipoPagamentoValidation()
        {
            RuleFor(c => c.Nome)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido")
               .Length(2, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

           
        }
    }
}
