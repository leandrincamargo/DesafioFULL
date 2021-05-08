using DesafioFULL.Domain.DTOs;
using FluentValidation;
using System.Collections.Generic;

namespace DesafioFULL.Application.Validators
{
    public class InstallmentCollectionValidation : AbstractValidator<IEnumerable<InstallmentDtoRequest>>
    {
        public InstallmentCollectionValidation()
        {            
            RuleForEach(x => x).Cascade(CascadeMode.Stop).SetValidator(new InstallmentValidation());
        }
    }
}
