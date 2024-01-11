using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validators
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad Soyad boş bırakılamaz");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Unvan boş bırakılamaz");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim URL boş bırakılamaz");
        }
    }
}
