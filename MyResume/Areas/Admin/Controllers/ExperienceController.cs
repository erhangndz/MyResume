using AutoMapper;
using BusinessLayer.Validators;
using DataAccessLayer.Services.Interfaces;
using DtoLayer.DTOs.AboutMeDtos;
using DtoLayer.DTOs.ExperienceDtos;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace MyResume.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ExperienceController : Controller
    {
        private readonly IGenericService<Experience> _experienceService;
        private readonly IMapper _mapper;

        public ExperienceController(IGenericService<Experience> experienceService, IMapper mapper)
        {
            _experienceService = experienceService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var experiences = await _experienceService.GetAllAsync();
            var values = _mapper.Map<List<ResultExperienceDto>>(experiences);
            return View(values);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _experienceService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExperienceDto createExperienceDto)
        {
            ModelState.Clear();
            var newExperience= _mapper.Map<Experience>(createExperienceDto);
            var validator = new ExperienceValidator();
            var result = await validator.ValidateAsync(newExperience);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }
            await _experienceService.CreateAsync(newExperience);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(string id)
        {
            var result = await _experienceService.GetByIdAsync(id);
            var value = _mapper.Map<UpdateExperienceDto>(result);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateExperienceDto updateExperienceDto)
        {
            var updateExperience = _mapper.Map<Experience>(updateExperienceDto);
            await _experienceService.UpdateAsync(updateExperience);
            return RedirectToAction(nameof(Index));
        }
    }
}
