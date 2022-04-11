using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SocialMediaValidator : AbstractValidator<SocialMedia>
    {

        public SocialMediaValidator()
        {


            RuleFor(x=>x.Name).NotEmpty().WithMessage("Sosyal Medya adı boş olamaz!");  
            RuleFor(x=>x.Url).NotEmpty().WithMessage("Sosyal Medya URL yolu boş olamaz!");   
            RuleFor(x=>x.Icon).NotEmpty().WithMessage("Sosyal Medya ikon yolu boş olamaz!");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Sosyal Medya adı maksimum 20 karakterden oluşabilir!");
            RuleFor(x => x.Url).MaximumLength(60).WithMessage("Sosyal Medya URL yolu maksimum 40 karakterden oluşabilir!");  
            RuleFor(x=>x.Icon).MaximumLength(20).WithMessage("Sosyal Medya ikon yolu maksimum 20 karakterden oluşabilir!");


        }


    }
}
