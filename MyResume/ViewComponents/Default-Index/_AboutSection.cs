using AutoMapper;
using DataAccessLayer.Services.Interfaces;
using DtoLayer.DTOs.AboutSectionDtos;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace MyResume.ViewComponents.Default_Index
{
    public class _AboutSection:ViewComponent
    {
        private readonly IGenericService<_AboutSection> _aboutSectionService;
        private readonly IMapper _mapper;

        public _AboutSection(IGenericService<_AboutSection> aboutSectionService, IMapper mapper)
        {
            _aboutSectionService = aboutSectionService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _aboutSectionService.GetAllAsync();
            var values = _mapper.Map<List<ResultAboutSectionDto>>(result);
            return View(values);
        }
    }
}
