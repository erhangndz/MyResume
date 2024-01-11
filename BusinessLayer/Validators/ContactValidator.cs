using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validators
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş bırakılamaz.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir email adresi girin");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres boş bırakılamaz.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon boş bırakılamaz.");
            RuleFor(x => x.MapUrl).NotEmpty().WithMessage("Harita Embed linki boş bırakılamaz.");
           
        }
    }
}
