using AutoMapper;
using DataAccessLayer.Services.Interfaces;
using DtoLayer.DTOs.ServiceDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyResume.ViewComponents.Default_Index
{
    public class _ServiceSection:ViewComponent
    {
        private readonly IGenericService<Service> _serviceService;
        private readonly IMapper _mapper;

        public _ServiceSection(IGenericService<Service> serviceService, IMapper mapper)
        {
            _serviceService = serviceService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _serviceService.GetAllAsync();
            var values = _mapper.Map<List<ResultServiceDto>>(result);
            return View(values);
        }
    }
}
