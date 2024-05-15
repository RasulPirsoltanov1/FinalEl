using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.DealDtos;
using Villa.Entity.Entites;

namespace Villa.WebUi.Controllers
{
    public class DealController : Controller
    {
        private readonly IDealService _dealService;
        private readonly IMapper _mapper;

        public DealController(IMapper mapper, IDealService dealService)
        {
            _mapper=mapper;
            _dealService=dealService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _dealService.TGetListAsync();
            var valueList = _mapper.Map<List<ResultDealDto>>(values);
            return View(valueList);
        }

        public async Task<IActionResult> DeleteDeal(ObjectId id)
        {
            await _dealService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateDeal()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeal(CreateDealDto createDealDto)
        {
            var newValue = _mapper.Map<Deal>(createDealDto);
            await _dealService.TCreateAsync(newValue);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UptadeDeal(ObjectId id)
        {
            var value = await _dealService.TGetByIdAsync(id);
            var uptadeValue = _mapper.Map<UpdateDealDto>(value);
            return View(uptadeValue);
        }

        [HttpPost]
        public async Task<IActionResult> UptadeDeal(UpdateDealDto uptadeDealDto)
        {
            var uptadeValue = _mapper.Map<Deal>(uptadeDealDto);
            await _dealService.TUptadeAsync(uptadeValue);
            return RedirectToAction("Index");
        }
    }
}
