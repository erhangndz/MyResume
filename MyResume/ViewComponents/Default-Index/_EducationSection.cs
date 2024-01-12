using AutoMapper;
using DataAccessLayer.Services.Interfaces;
using DtoLayer.DTOs.EducationDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyResume.ViewComponents.Default_Index
{
    public class _EducationSection:ViewComponent
    {
        private readonly IGenericService<Education> _educationService;
        private readonly IMapper _mapper;

        public _EducationSection(IGenericService<Education> educationService, IMapper mapper)
        {
            _educationService = educationService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _educationService.GetAllAsync();
            var values = _mapper.Map<List<ResultEducationDto>>(result);
            return View(values);
        }
    }
}
