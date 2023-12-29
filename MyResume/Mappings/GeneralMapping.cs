using AutoMapper;
using DtoLayer.DTOs.AboutMeDtos;
using DtoLayer.DTOs.EducationDtos;
using DtoLayer.DTOs.TestimonialDtos;
using EntityLayer.Entities;

namespace MyResume.Mappings
{
    public class GeneralMapping: Profile
    {

        public GeneralMapping()
        {
            CreateMap<CreateEducationDto,Education>().ReverseMap();
            CreateMap<UpdateEducationDto,Education>().ReverseMap();
            CreateMap<ResultEducationDto,Education>().ReverseMap();

            CreateMap<ResultTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<CreateTestimonialDto, Testimonial>().ReverseMap();

            CreateMap<ResultAboutMeDto, AboutMe>().ReverseMap();
            CreateMap<CreateAboutMeDto, AboutMe>().ReverseMap();
            CreateMap<UpdateAboutMeDto, AboutMe>().ReverseMap();
        }
    }
}
