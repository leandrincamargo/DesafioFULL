using DesafioFULL.Domain.DTOs;
using FluentValidation;

namespace DesafioFULL.Application.Validators
{
    public class NewDebtValidation : AbstractValidator<DebtDtoRequest>
    {
        public NewDebtValidation()
        {
            RuleFor(d => d.Number).GreaterThan(0).WithMessage("O Número é obrigatório");

            RuleFor(d => d.DebtorName)
                .NotEmpty().WithMessage("O Nome é obrigatório")
                .MaximumLength(200).WithMessage("Tamanho máximo do campo nome é de 200 caracteres");

            RuleFor(d => d.InterestPercent).GreaterThanOrEqualTo(0).WithMessage("O Percentual de Juros é obrigatório");

            RuleFor(d => d.PenaltyPercent).GreaterThanOrEqualTo(0).WithMessage("O Percentual de Multa é obrigatório");

            RuleFor(d => d.DebtorCpf)
                .NotEmpty().WithMessage("O CPF é obrigatório")
                .IsValidCPF().WithMessage("O CPF está inválido");

            RuleFor(d => d.Installments)
                .NotEmpty().WithMessage("As parcelas são obrigatórias")
                .SetValidator(new InstallmentCollectionValidation());
        }
    }
}
