using AutoMapper;
using DataAccessLayer.Services.Interfaces;
using DtoLayer.DTOs.AboutSectionDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace MyResume.ViewComponents.Default_Index
{
    public class _AboutSection:ViewComponent
    {
        private readonly IGenericService<AboutSection> _aboutSectionService;
        private readonly IMapper _mapper;

        public _AboutSection(IGenericService<AboutSection> aboutSectionService, IMapper mapper)
        {
            _aboutSectionService = aboutSectionService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _aboutSectionService.GetAllAsync();
            var values = _mapper.Map<List<ResultAboutSectionDto>>(result);
            var today = DateTime.Today;
            var startDay = (DateTime.Parse("01.09.2022"));
            var time = today - startDay;
            ViewBag.time = time.Days;
            return View(values);
        }
    }
}
