using CPF_CACL.GestaoSocio.Domain.Models.Entities;
using FluentValidation;

namespace CPF_CACL.GestaoSocio.Domain.Models.Validation
{
    public class SocioValidation : AbstractValidator<Socio>
    {
        public SocioValidation() 
        { 
            RuleFor(c => c.BI)
                .Length(14, 15).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
            
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(2, 300).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Genero)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(1, 9).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
             
            RuleFor(c => c.Nacionalidade)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
               .Length(2, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.NomeDoPai)
               .Length(2, 300).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.NomeDaMae)
               .Length(2, 300).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Endereco)
               .Length(2, 300).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");




        }
    }
}
