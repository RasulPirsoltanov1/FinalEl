using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.ContactDtos;
using Villa.Entity.Entites;

namespace Villa.WebUi.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService=contactService;
            _mapper=mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _contactService.TGetListAsync();
            var contactList = _mapper.Map<List<ResultContactDto>>(values);
            return View(contactList);
        }

        public async Task<IActionResult> DeleteContact(ObjectId id)
        {
            await _contactService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            var newContact=_mapper.Map<Contact>(createContactDto);
            await _contactService.TCreateAsync(newContact);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UptadeContact(ObjectId id)
        {
            var value= await _contactService.TGetByIdAsync(id);
            var contact = _mapper.Map<UptadeContactDto>(value);
            return View(contact);
        }

        [HttpPost]        
        public async Task<IActionResult> UptadeContact(UptadeContactDto uptadeContactDto)
        {
            var contact =_mapper.Map<Contact>(uptadeContactDto);
            await _contactService.TUptadeAsync(contact);
            return RedirectToAction("Index");
        }
        

    }
}
