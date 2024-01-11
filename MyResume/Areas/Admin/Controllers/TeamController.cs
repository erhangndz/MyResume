using AutoMapper;
using BusinessLayer.Validators;
using DataAccessLayer.Services.Interfaces;
using DtoLayer.DTOs.TeamDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyResume.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class TeamController : Controller
    {
        private readonly IGenericService<Team> _teamService;
        private readonly IMapper _mapper;

        public TeamController(IGenericService<Team> teamService, IMapper teamMapper)
        {
            _teamService = teamService;
            _mapper = teamMapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _teamService.GetAllAsync();
            var values= _mapper.Map<List<ResultTeamDto>>(result);
            return View(values);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _teamService.DeleteAsync(id);
            return RedirectToAction(nameof(Index)); 
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTeamDto createTeamDto)
        {
            ModelState.Clear();
            var newTeam = _mapper.Map<Team>(createTeamDto);
            var validator = new TeamValidator();
            var result = validator.Validate(newTeam);
            if (!result.IsValid)
            {
                result.Errors.ForEach(x =>
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                });
                return View();
            }

            await _teamService.CreateAsync(newTeam);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(string id)
        {
            var value = await _teamService.GetByIdAsync(id);
            var updateValue = _mapper.Map<UpdateTeamDto>(value);
            return View(updateValue);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTeamDto updateTeamDto)
        {
            var updateValue = _mapper.Map<Team>(updateTeamDto);
            await _teamService.UpdateAsync(updateValue);
            return RedirectToAction(nameof(Index));
        }


    }
}
