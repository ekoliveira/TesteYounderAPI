using FluentValidation;
using TesteYounder.Application.CasosDeUso.Cliente.Request;

namespace TesteYounder.Application.CasosDeUso.Cliente.Base.Validations
{
    public class ClienteInserirValidation : AbstractValidator<InserirClienteRequest>
    {
        public ClienteInserirValidation()
        {
            ValidateNomeNulo();
            ValidateNomeTamanho();
            ValidateCpfNulo();
            ValidateCpfTamanho();
            ValidateRgNulo();
            ValidateRgTamanho();
            ValidateDataNascimentoNula();
        }

        protected void ValidateNomeNulo()
        {
            RuleFor(r => r.Nome)
                .NotNull()
                .NotEqual(string.Empty)
                .WithMessage("O nome do cliente é obrigatório!");
        }

        protected void ValidateNomeTamanho()
        {
            RuleFor(r => r.Nome)
               .MaximumLength(100)
               .WithMessage("O nome do cliente deve conter no máximo 100 caractéres!");
        }

        protected void ValidateCpfNulo()
        {
            RuleFor(r => r.Cpf)
               .NotNull()
               .NotEqual(string.Empty)
               .WithMessage("O CPF do cliente é obrigatório!");
        }

        protected void ValidateCpfTamanho()
        {
            RuleFor(r => r.Cpf)
               .MaximumLength(11)
               .MinimumLength(11)
               .WithMessage("O CPF do cliente deve conter 11 dígitos!");
        }

        protected void ValidateRgNulo()
        {
            RuleFor(r => r.Rg)
               .NotNull()
               .NotEqual(string.Empty)
               .WithMessage("O RG do cliente é obrigatório!");
        }

        protected void ValidateRgTamanho()
        {
            RuleFor(r => r.Rg)
               .MaximumLength(9)
               .MinimumLength(9)
               .WithMessage("O RG do cliente deve conter 11 dígitos!");
        }

        protected void ValidateDataNascimentoNula()
        {
            RuleFor(r => r.DataNascimento)
               .NotNull()
               .WithMessage("A data de nascimento do cliente é obrigatória!");
        }
    }
}