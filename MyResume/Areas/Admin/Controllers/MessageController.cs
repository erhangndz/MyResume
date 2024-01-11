using AutoMapper;
using DataAccessLayer.Services.Interfaces;
using DtoLayer.DTOs.MessageDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyResume.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class MessageController : Controller
    {
        private readonly IGenericService<Message> _messageService;
        private readonly IMapper _mapper;

        public MessageController(IGenericService<Message> messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _messageService.GetAllAsync();
            var values = _mapper.Map<List<ResultMessageDto>>(result);
            return View(values);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _messageService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string id)
        {
            var message = await _messageService.GetByIdAsync(id);
            var value = _mapper.Map<ResultMessageDto>(message);
            return View(value);
        }

        
    }
}
