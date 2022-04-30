using fiapweb2022.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiapweb2022.Application.Validations
{
    public class AlunoValidation: AbstractValidator<Aluno>
    {
        public AlunoValidation()
        {
            RuleFor(a => a.Nome).NotNull().WithMessage("insira o {PropertyName}");
            //RuleFor(a => a.Nome).().WithMessage("insira o {PropertyName}");
        }
    }
}
