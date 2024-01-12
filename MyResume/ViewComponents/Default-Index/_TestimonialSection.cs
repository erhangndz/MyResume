using AutoMapper;
using DataAccessLayer.Services.Interfaces;
using DtoLayer.DTOs.TestimonialDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyResume.ViewComponents.Default_Index
{
    public class _TestimonialSection:ViewComponent
    {
        private readonly IGenericService<Testimonial> _testimonialService;
        private readonly IMapper _mapper;

        public _TestimonialSection(IGenericService<Testimonial> testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _testimonialService.GetAllAsync();
            var values = _mapper.Map<List<ResultTestimonialDto>>(result);
            return View(values);
        }
    }
}
