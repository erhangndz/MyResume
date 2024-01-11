using AutoMapper;
using DataAccessLayer.Services.Interfaces;
using DtoLayer.DTOs.ServiceDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyResume.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ServiceController : Controller
    {

        private readonly IGenericService<Service> _serviceService;
        private readonly IMapper _mapper;

      
        public ServiceController(IGenericService<Service> serviceService, IMapper mapper)
        {
            _serviceService = serviceService;
            _mapper = mapper;
        }

       
        public async Task<IActionResult> Index()
        {
            var services =await _serviceService.GetAllAsync();
            var values = _mapper.Map<List<ResultServiceDto>>(services);
            return View(values);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _serviceService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(string id)
        {
            var service = await _serviceService.GetByIdAsync(id);
            var value = _mapper.Map<UpdateServiceDto>(service);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateServiceDto updateServiceDto)
        {
            var updateService = _mapper.Map<Service>(updateServiceDto);
            await _serviceService.UpdateAsync(updateService);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Create(string title,string price, string description, string icon)
        {
            var newService = new Service
            {
                Title = title,
                Description = description,
                Icon = icon,
                Price = price
            };

            await _serviceService.CreateAsync(newService);
            return RedirectToAction(nameof(Index));
        }

    }
}
