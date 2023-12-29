using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Services.Interfaces;
using DtoLayer.DTOs.EducationDtos;
using EntityLayer.Entities;
using BusinessLayer.Validators;

namespace MyResume.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class EducationController : Controller
    {
        private readonly IGenericService<Education> _educationService;
        private readonly IMapper _mapper;

        public EducationController(IGenericService<Education> educationService, IMapper mapper)
        {
            _educationService = educationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _educationService.GetAllAsync();
            var educationList = _mapper.Map<List<ResultEducationDto>>(values);

            return View(educationList);
        }
        public async Task<IActionResult> Delete(string id)
        {
            await _educationService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateEducationDto createEducationDto)
        {
            EducationValidator validator = new EducationValidator();
            var newEducation = _mapper.Map<Education>(createEducationDto);
            var result = validator.Validate(newEducation);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }
            

            await _educationService.CreateAsync(newEducation);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(string id)
        {
          var education = await _educationService.GetByIdAsync(id);
            var value = _mapper.Map<UpdateEducationDto>(education);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateEducationDto updateEducationDto)
        {
            var updateEducation = _mapper.Map<Education>(updateEducationDto);
            await _educationService.UpdateAsync(updateEducation);
            return RedirectToAction(nameof(Index));

        }
    }
}
