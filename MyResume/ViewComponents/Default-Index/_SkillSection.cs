using AutoMapper;
using DataAccessLayer.Services.Interfaces;
using DtoLayer.DTOs.SkillDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyResume.ViewComponents.Default_Index
{
    public class _SkillSection:ViewComponent
    {
        private readonly IGenericService<Skill> _skillService;
        private readonly IMapper _mapper;

        public _SkillSection(IGenericService<Skill> skillService, IMapper mapper)
        {
            _skillService = skillService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _skillService.GetAllAsync();
            var values = _mapper.Map<List<ResultSkillDto>>(result);
            return View(values);
        }
    }
}
