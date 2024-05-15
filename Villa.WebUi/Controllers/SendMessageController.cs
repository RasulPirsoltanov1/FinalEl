using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.MessageDtos;
using Villa.Entity.Entites;

namespace Villa.WebUi.Controllers
{
    public class SendMessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public SendMessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService=messageService;
            _mapper=mapper;
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {
            var newMessage=_mapper.Map<Message>(createMessageDto);
            await _messageService.TCreateAsync(newMessage);
            return RedirectToAction("Index","Default");
        }


    }
}
