using AutoMapper;
using DataAccessLayer.Services.Interfaces;
using DtoLayer.DTOs.ContactDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyResume.ViewComponents.Default_Index
{
    public class _ContactSection:ViewComponent
    {
        private readonly IGenericService<Contact> _contactService;
        private readonly IMapper _mapper;

        public _ContactSection(IGenericService<Contact> contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _contactService.GetAllAsync();
            var values = _mapper.Map<List<ResultContactDto>>(result);
            return View(values);
        }
    }
}
