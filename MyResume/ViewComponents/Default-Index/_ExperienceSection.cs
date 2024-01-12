using AutoMapper;
using DataAccessLayer.Services.Interfaces;
using DtoLayer.DTOs.ExperienceDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyResume.ViewComponents.Default_Index
{
    public class _ExperienceSection:ViewComponent
    {
        private readonly IGenericService<Experience> _experienceService;
        private readonly IMapper _mapper;

        public _ExperienceSection(IGenericService<Experience> experienceService, IMapper mapper)
        {
            _experienceService = experienceService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _experienceService.GetAllAsync();
            var values = _mapper.Map<List<ResultExperienceDto>>(result);
            return View(values);
        }
    }
}
