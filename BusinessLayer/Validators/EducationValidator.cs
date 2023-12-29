using EntityLayer.Entities;
using FluentValidation;

namespace BusinessLayer.Validators
{
    public class EducationValidator: AbstractValidator<Education>
    {

        public EducationValidator()
        {
            RuleFor(x => x.SchoolName).NotEmpty().WithMessage("Üniversite ismi boş bırakılamaz.");
            RuleFor(x => x.Department).NotEmpty().WithMessage("Bölüm ismi boş bırakılamaz.");
            RuleFor(x => x.StartYear).NotEmpty().WithMessage("Başlama yılı boş bırakılamaz.");
            RuleFor(x => x.FinishYear).NotEmpty().WithMessage("Mezuniyet yılı boş bırakılamaz. Mezun değilseniz tahmini tarihi girin");
        }
    }
}
