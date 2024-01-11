using AutoMapper;
using DtoLayer.DTOs.AboutMeDtos;
using DtoLayer.DTOs.AboutSectionDtos;
using DtoLayer.DTOs.ContactDtos;
using DtoLayer.DTOs.EducationDtos;
using DtoLayer.DTOs.ExperienceDtos;
using DtoLayer.DTOs.MessageDtos;
using DtoLayer.DTOs.ProjectDtos;
using DtoLayer.DTOs.ServiceDtos;
using DtoLayer.DTOs.SkillDtos;
using DtoLayer.DTOs.TeamDtos;
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

            CreateMap<ResultAboutSectionDto, AboutSection>().ReverseMap();
            CreateMap<CreateAboutSectionDto, AboutSection>().ReverseMap();
            CreateMap<UpdateAboutSectionDto, AboutSection>().ReverseMap();

            CreateMap<ResultExperienceDto, Experience>().ReverseMap();
            CreateMap<CreateExperienceDto, Experience>().ReverseMap();
            CreateMap<UpdateExperienceDto, Experience>().ReverseMap();

            CreateMap<ResultSkillDto, Skill>().ReverseMap();
            CreateMap<CreateSkillDto, Skill>().ReverseMap();
            CreateMap<UpdateSkillDto, Skill>().ReverseMap();


            CreateMap<ResultProjectDto, Project>().ReverseMap();
            CreateMap<CreateProjectDto, Project>().ReverseMap();
            CreateMap<UpdateProjectDto, Project>().ReverseMap();

            CreateMap<ResultServiceDto,Service>().ReverseMap();
            CreateMap<CreateServiceDto,Service>().ReverseMap();
            CreateMap<UpdateServiceDto,Service>().ReverseMap();



            CreateMap<UpdateTeamDto,Team>().ReverseMap();
            CreateMap<CreateTeamDto,Team>().ReverseMap();
            CreateMap<ResultTeamDto,Team>().ReverseMap();


            CreateMap<ResultContactDto,Contact>().ReverseMap();
            CreateMap<CreateContactDto,Contact>().ReverseMap();
            CreateMap<UpdateContactDto,Contact>().ReverseMap();


            CreateMap<UpdateMessageDto,Contact>().ReverseMap();
            CreateMap<CreateMessageDto,Contact>().ReverseMap();
            CreateMap<ResultMessageDto,Contact>().ReverseMap();



        }
    }
}
