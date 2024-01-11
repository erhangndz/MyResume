using AutoMapper;
using DataAccessLayer.Services.Interfaces;
using DtoLayer.DTOs.ProjectDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyResume.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ProjectController : Controller
    {
        private readonly IGenericService<Project> _projectService;
        private readonly IMapper _mapper;

        public ProjectController(IGenericService<Project> projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var projects = await _projectService.GetAllAsync();
            var values = _mapper.Map<List<ResultProjectDto>>(projects);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string imageUrl,string githubUrl, string projectType)
        {
            var newProject = new Project
            {
                GitHubUrl = githubUrl,
                ImageUrl = imageUrl,
                Type = projectType
            };

            await _projectService.CreateAsync(newProject);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _projectService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(string id)
        {
            var project  = await _projectService.GetByIdAsync(id);
            var value = _mapper.Map<UpdateProjectDto>(project);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProjectDto updateProjectDto)
        {
            var updateProject = _mapper.Map<Project>(updateProjectDto);

            await _projectService.UpdateAsync(updateProject);
            return RedirectToAction(nameof(Index));
        }


    }
}
