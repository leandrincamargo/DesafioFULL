using DesafioFULL.Domain.DTOs;
using FluentValidation;

namespace DesafioFULL.Application.Validators
{
    public class InstallmentValidation : AbstractValidator<InstallmentDtoRequest>
    {
        public InstallmentValidation()
        {
            RuleFor(d => d.Number).GreaterThan(0).WithMessage("O Número é obrigatório");

            RuleFor(d => d.DueDate)
                .NotEmpty().WithMessage("A Data de Vencimento é obrigatório");

            RuleFor(d => d.Value).GreaterThanOrEqualTo(0).WithMessage("O Valor é obrigatório");
        }
    }
}
