using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.MessageDtos;
using Villa.Dto.Dtos.ProductDtos;

namespace Villa.WebUi.ViewComponents.Default_Index
{
    public class _DefaultMessage : ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public _DefaultMessage(IMessageService messageService, IMapper mapper)
        {
            _messageService=messageService;
            _mapper=mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _messageService.TGetListAsync();
            var messageList = _mapper.Map<List<ResultMessageDto>>(values);
            return View(messageList);
        }
    }
}
