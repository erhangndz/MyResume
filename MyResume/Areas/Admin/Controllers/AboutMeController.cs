using AutoMapper;
using BusinessLayer.Validators;
using DataAccessLayer.Services.Interfaces;
using DtoLayer.DTOs.AboutMeDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NuGet.DependencyResolver;

namespace MyResume.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AboutMeController : Controller
    {
        private readonly IGenericService<AboutMe> _aboutMeService;
        private readonly IMapper _mapper;

        public AboutMeController(IGenericService<AboutMe> aboutMeService, IMapper mapper)
        {
            _aboutMeService = aboutMeService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var results = await _aboutMeService.GetAllAsync();
            var values = _mapper.Map<List<ResultAboutMeDto>>(results);
            return View(values);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _aboutMeService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutMeDto createAboutMeDto)
        {
            var newAboutMe= _mapper.Map<AboutMe>(createAboutMeDto);
            var validator = new AboutMeValidator();
            var result= await validator.ValidateAsync(newAboutMe);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError("", x.ErrorMessage);
                });
                return View();
            }
            await _aboutMeService.CreateAsync(newAboutMe);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(string id)
        {
            var result = await _aboutMeService.GetByIdAsync(id);
            var value = _mapper.Map<UpdateAboutMeDto>(result);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateAboutMeDto updateAboutMeDto)
        {
            var updateAboutMe = _mapper.Map<AboutMe>(updateAboutMeDto);
            await _aboutMeService.UpdateAsync(updateAboutMe);
            return RedirectToAction(nameof(Index));
        }


    }
}
