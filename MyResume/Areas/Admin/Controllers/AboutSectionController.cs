using AutoMapper;
using BusinessLayer.Validators;
using DataAccessLayer.Services.Interfaces;
using DtoLayer.DTOs.AboutSectionDtos;
using DtoLayer.DTOs.EducationDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyResume.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AboutSectionController : Controller
    {
        private readonly IGenericService<AboutSection> _aboutSectionService;
        private readonly IMapper _mapper;

        public AboutSectionController(IMapper mapper, IGenericService<AboutSection> aboutSectionService)
        {
            _mapper = mapper;
            _aboutSectionService = aboutSectionService;
        }

        public async Task<IActionResult> Index()
        {
            var aboutList = await _aboutSectionService.GetAllAsync();
            var values = _mapper.Map<List<ResultAboutSectionDto>>(aboutList);
            return View(values);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _aboutSectionService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutSectionDto createAboutSectionDto)
        {
            ModelState.Clear();
            AboutSectionValidator validator = new();
            var newAbout = _mapper.Map<AboutSection>(createAboutSectionDto);
            var result = validator.Validate(newAbout);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }


            await _aboutSectionService.CreateAsync(newAbout);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(string id)
        {
            var about = await _aboutSectionService.GetByIdAsync(id);
            var value = _mapper.Map<UpdateAboutSectionDto>(about);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateAboutSectionDto updateAboutSectionDto)
        {
            var updateAbout = _mapper.Map<AboutSection>(updateAboutSectionDto);
            await _aboutSectionService.UpdateAsync(updateAbout);
            return RedirectToAction(nameof(Index));

        }
    }
}
