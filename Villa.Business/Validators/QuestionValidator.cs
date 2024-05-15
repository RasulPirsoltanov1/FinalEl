using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entites;

namespace Villa.Business.Validators
{
    public class QuestionValidator: AbstractValidator<Quest>
    {
        public QuestionValidator()
        {
            RuleFor(x => x.Question).NotEmpty().WithMessage("The Question cannot be left blank");
            RuleFor(x => x.Answer).NotEmpty().WithMessage("The Answer cannot be left blank");
        }
    }
}
