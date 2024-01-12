using AutoMapper;
using BusinessLayer.Validators;
using DataAccessLayer.Services.Interfaces;
using DtoLayer.DTOs.MessageDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyResume.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IGenericService<Message> _messageService;
        private readonly IMapper _mapper;

        public DefaultController(IGenericService<Message> messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {
            var newMessage = _mapper.Map<Message>(createMessageDto);
            var validator = new MessageValidator();
            var result = validator.Validate(newMessage);
            if (!result.IsValid)
            {
                TempData["errorMessage"] = "mesaj gönderilemedi";
                return NoContent();
            }

            TempData["errorMessage"] = null;
            await _messageService.CreateAsync(newMessage);
            return NoContent();
        }
    }
}
