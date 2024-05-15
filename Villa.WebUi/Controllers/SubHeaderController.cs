using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.SubHeaderDtos;
using Villa.Entity.Entites;

namespace Villa.WebUi.Controllers
{
    public class SubHeaderController : Controller
    {
        private readonly ISubHeaderService _subHeaderService;
        private readonly IMapper _mapper;

        public SubHeaderController(ISubHeaderService subHeaderService, IMapper mapper)
        {
            _subHeaderService=subHeaderService;
            _mapper=mapper;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _subHeaderService.TGetListAsync();
            var valueList = _mapper.Map<List<ResultSubHeaderDto>>(values);
            return View(valueList);
        }

        public async Task<IActionResult> DeleteSubHeader(ObjectId id)
        {
            await _subHeaderService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateSubHeader()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubHeader(CreateSubHeaderDto createSubHeaderDto)
        {
            var newValue = _mapper.Map<SubHeader>(createSubHeaderDto);
            await _subHeaderService.TCreateAsync(newValue);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UptadeSubHeader(ObjectId id)
        {
            var value = await _subHeaderService.TGetByIdAsync(id);
            var uptadeValue = _mapper.Map<UpdateSubHeaderDto>(value);
            return View(uptadeValue);
        }

        [HttpPost]
        public async Task<IActionResult> UptadeSubHeader(UpdateSubHeaderDto uptadeSubHeaderDto)
        {
            var uptadeValue = _mapper.Map<SubHeader>(uptadeSubHeaderDto);
            await _subHeaderService.TUptadeAsync(uptadeValue);
            return RedirectToAction("Index");
        }
    }
}
