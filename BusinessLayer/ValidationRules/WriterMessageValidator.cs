using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterMessageValidator : AbstractValidator<WriterMessage>
    {

        public WriterMessageValidator()
        {

            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj İçeriği boş olamaz!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Başlığı boş olamaz!");
            RuleFor(x => x.Receiver).NotEmpty().WithMessage("Alıcının e-posta adresi boş olamaz!");
            RuleFor(x => x.MessageContent).MinimumLength(5).WithMessage("Mesaj İçeriği en az 5 karakterden oluşmalıdır!");
            RuleFor(x => x.MessageContent).MaximumLength(200).WithMessage("Mesaj İçeriği en fazla 200 karakterden oluşmalıdır!");
            RuleFor(x => x.Subject).MinimumLength(1).WithMessage("Mesaj Başlığı en az 1 karakterden oluşmalıdır!");
            RuleFor(x => x.Subject).MaximumLength(40).WithMessage("Mesaj Başlığı en fazla 40 karakterden oluşmalıdır!");
            RuleFor(x => x.Receiver).MaximumLength(30).WithMessage("Alıcının e-posta adresi en fazla 30 karakterden oluşmalıdır!");

        }

    }
}
