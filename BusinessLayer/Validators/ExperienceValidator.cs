using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validators
{
    public class ExperienceValidator : AbstractValidator<Experience>
    {
        public ExperienceValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("İş unvanı boş bırakılamaz");
            RuleFor(x => x.Company).NotEmpty().WithMessage("Şirket ismi boş bırakılamaz");
            RuleFor(x => x.StartDate).NotEmpty().WithMessage("Başlama tarihi boş bırakılamaz");
            RuleFor(x => x.EndDate).NotEmpty().WithMessage("Bitiş tarihi boş bırakılamaz, Eğer bitmediyse 'Devam Ediyor' yazabilirsiniz.");
        }
    }
}
