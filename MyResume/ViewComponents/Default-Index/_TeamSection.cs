using AutoMapper;
using DataAccessLayer.Services.Interfaces;
using DtoLayer.DTOs.TeamDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyResume.ViewComponents.Default_Index
{
    public class _TeamSection: ViewComponent
    {
        private readonly IGenericService<Team> _teamService;
        private readonly IMapper _mapper;

        public _TeamSection(IGenericService<Team> teamService, IMapper mapper)
        {
            _teamService = teamService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _teamService.GetAllAsync();
            var values = _mapper.Map<List<ResultTeamDto>>(result);
            return View(values);
        }
    }
}
