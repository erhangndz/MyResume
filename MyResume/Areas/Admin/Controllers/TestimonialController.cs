using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Services.Interfaces;
using DtoLayer.DTOs.TestimonialDtos;
using EntityLayer.Entities;
using BusinessLayer.Validators;

namespace MyResume.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class TestimonialController : Controller
    {
        private readonly IGenericService<Testimonial> _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(IGenericService<Testimonial> testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var testimonials = await _testimonialService.GetAllAsync();
            var values = _mapper.Map<List<ResultTestimonialDto>>(testimonials);
            return View(values);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _testimonialService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialDto createTestimonialDto)
        {
            ModelState.Clear();
            var validator = new TestimonialValidator();
            
            var newTestimonial = _mapper.Map<Testimonial>(createTestimonialDto);
           var result = validator.Validate(newTestimonial);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);

                });
                return View(createTestimonialDto);

            }

            await _testimonialService.CreateAsync(newTestimonial);
            return RedirectToAction(nameof(Index));

            

        }

        public async Task<IActionResult> Update(string id)
        {
            var testimonial = await _testimonialService.GetByIdAsync(id);
            var value = _mapper.Map<UpdateTestimonialDto>(testimonial);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTestimonialDto updateTestimonialDto)
        {
            var updateTestimonial = _mapper.Map<Testimonial>(updateTestimonialDto);
            await _testimonialService.UpdateAsync(updateTestimonial);
            return RedirectToAction(nameof(Index));

        }
    }
}
