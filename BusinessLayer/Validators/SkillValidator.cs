using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validators
{
    public class SkillValidator : AbstractValidator<Skill>
    {
        public SkillValidator()
        {
            RuleFor(x => x.SkillName).NotEmpty().WithMessage("Yetenek ismi boş bırakılamaz");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Yüzdelik değer boş bırakılamaz");
            RuleFor(x => x.BgColor).NotEmpty().WithMessage("Renk kodu boş bırakılamaz");
        }
    }
}
