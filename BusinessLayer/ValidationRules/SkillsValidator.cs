using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SkillsValidator : AbstractValidator<Skills>
    {

        public SkillsValidator()
        {

            RuleFor(x => x.Title).NotEmpty().WithMessage("Yetenek adı boş olamaz!");
            RuleFor(x => x.Title).MinimumLength(2).WithMessage("Yetenek adı en az 2 karakterden oluşabilir!");
            RuleFor(x => x.Title).MaximumLength(30).WithMessage("Yetenek adı en fazla 30 karakterden oluşabilir!"); ;
            RuleFor(x => x.Value).NotEmpty().WithMessage("Yetenek oranı bir değere sahip olmalıdır!");
            RuleFor(x => x.Value).MaximumLength(3).WithMessage("Yetenek oranı maksimum 3 karakterden oluşabilir!");


        }


    }
}
