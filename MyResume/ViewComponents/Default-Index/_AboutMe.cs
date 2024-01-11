using AutoMapper;
using DataAccessLayer.Services.Interfaces;
using DtoLayer.DTOs.AboutMeDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyResume.ViewComponents.Default_Index
{
    public class _AboutMe : ViewComponent
    {
        private readonly IGenericService<AboutMe> _aboutMeService;
        private readonly IMapper _mapper;

        public _AboutMe(IGenericService<AboutMe> aboutMeService, IMapper mapper)
        {
            _aboutMeService = aboutMeService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutMeService.GetAllAsync();
            var result= _mapper.Map<List<ResultAboutMeDto>>(values);
            return View(result);
        }
    }
}
