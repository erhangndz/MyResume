using AutoMapper;
using BusinessLayer.Validators;
using DataAccessLayer.Services.Interfaces;
using DtoLayer.DTOs.EducationDtos;
using DtoLayer.DTOs.SkillDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyResume.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class SkillController : Controller
    {
        private readonly IGenericService<Skill> _skillService;
        private readonly IMapper _mapper;

        public SkillController(IGenericService<Skill> skillService, IMapper mapper)
        {
            _skillService = skillService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var skills= await _skillService.GetAllAsync();
            var values = _mapper.Map<List<ResultSkillDto>>(skills);
            return View(values);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _skillService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(string skillName, int value, string bgColor)
        {

            var newSkill = new Skill
            {
                SkillName = skillName,
                Value = value,
                BgColor = bgColor
            };


            await _skillService.CreateAsync(newSkill);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(string id)
        {
            var skill = await _skillService.GetByIdAsync(id);
            var value = _mapper.Map<UpdateSkillDto>(skill);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateSkillDto updateSkillDto)
        {
            var updateSkill = _mapper.Map<Skill>(updateSkillDto);
            await _skillService.UpdateAsync(updateSkill);
            return RedirectToAction(nameof(Index));

        }
    }
}
