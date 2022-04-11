using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidator : AbstractValidator<Announcement>
    { 

        public AnnouncementValidator()
        {

            RuleFor(x=>x.Title).NotEmpty().WithMessage("Duyuru Başlığı boş olamaz!"); 
            RuleFor(x=>x.Content).NotEmpty().WithMessage("Duyuru İçeriği boş olamaz!");
            RuleFor(x => x.Title).MaximumLength(20).WithMessage("Duyuru Başlığı maksimum 20 karakterden oluşabilir!");
            RuleFor(x => x.Content).MaximumLength(200).WithMessage("Duyuru İçeriği maksimum 200 karakterden oluşabilir!");

        }


    }
}
