using AutoMapper;
using DataAccessLayer.Services.Interfaces;
using DtoLayer.DTOs.ProjectDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyResume.ViewComponents.Default_Index
{
    public class _ProjectSection:ViewComponent
    {
        private readonly IGenericService<Project> _projectService;
        private readonly IMapper _mapper;

        public _ProjectSection(IGenericService<Project> projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _projectService.GetAllAsync();
            var values = _mapper.Map<List<ResultProjectDto>>(result);
            return View(values);
        }
    }
}
