using AutoMapper;
using BusinessLayer.Validators;
using DataAccessLayer.Services.Interfaces;
using DtoLayer.DTOs.ContactDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using NuGet.DependencyResolver;

namespace MyResume.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ContactController : Controller
    {
        private readonly IGenericService<Contact> _contactService;
        private readonly IMapper _mapper;

        public ContactController(IGenericService<Contact> contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _contactService.GetAllAsync();
            var values = _mapper.Map<List<ResultContactDto>>(result);
            return View(values);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _contactService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactDto createContactDto)
        {
            ModelState.Clear();
            var newContact = _mapper.Map<Contact>(createContactDto);
            var validator = new ContactValidator();
            var result = validator.Validate(newContact);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }

            await _contactService.CreateAsync(newContact);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Update(string id)
        {
            var contact = await _contactService.GetByIdAsync(id);
            var updateContact = _mapper.Map<UpdateContactDto>(contact);
            return View(updateContact);


        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateContactDto updateContactDto)
        {
            var value = _mapper.Map<Contact>(updateContactDto);
            await _contactService.UpdateAsync(value);
            return RedirectToAction(nameof(Index));
        }


     }
}
