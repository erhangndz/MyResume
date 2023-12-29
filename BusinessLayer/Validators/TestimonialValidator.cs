using EntityLayer.Entities;
using FluentValidation;

namespace BusinessLayer.Validators
{
    public class TestimonialValidator:AbstractValidator<Testimonial>
    {

        
        public TestimonialValidator()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad Soyad boş bırakılamaz");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Unvan boş bırakılamaz");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Yorum boş bırakılamaz");
        }
    }
}
