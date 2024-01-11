using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validators
{
    public class AboutSectionValidator: AbstractValidator<AboutSection>
    {

        public AboutSectionValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz");
            RuleFor(x => x.AboutImage1).NotEmpty().WithMessage("1. Resim Url boş bırakılamaz");
            RuleFor(x => x.AboutImage2).NotEmpty().WithMessage("2. Resim Url boş bırakılamaz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz");

        }
    }
}
