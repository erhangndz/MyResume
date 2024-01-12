using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validators
{
    public class MessageValidator: AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email adresi boş bırakılamaz.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir email adresi girin.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş bırakılamaz.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Mesaj alanı boş bırakılamaz.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad Soyad boş bırakılamaz.");
        }
    }
}
