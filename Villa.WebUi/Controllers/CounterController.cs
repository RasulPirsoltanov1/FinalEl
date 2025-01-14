﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.CounterDtos;
using Villa.Dto.Dtos.CounterDtos;
using Villa.Entity.Entites;

namespace Villa.WebUi.Controllers
{
    public class CounterController : Controller
    {
        private readonly ICounterService _counterService;
        private readonly IMapper _mapper;

        public CounterController(ICounterService counterService, IMapper mapper)
        {
            _counterService=counterService;
            _mapper=mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _counterService.TGetListAsync();
            var counterList = _mapper.Map<List<ResultCounterDto>>(values);
            return View(counterList);
        }

        public async Task<IActionResult> DeleteCounter(ObjectId id)
        {
            await _counterService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateCounter()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCounter(CreateCounterDto createCounterDto)
        {
            var newCounter = _mapper.Map<Counter>(createCounterDto);
            await _counterService.TCreateAsync(newCounter);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UptadeCounter(ObjectId id)
        {
            var value = await _counterService.TGetByIdAsync(id);
            var counter = _mapper.Map<UpdateCounterDto>(value);
            return View(counter);
        }

        [HttpPost]
        public async Task<IActionResult> UptadeCounter(UpdateCounterDto uptadeCounterDto)
        {
            var counter = _mapper.Map<Counter>(uptadeCounterDto);
            await _counterService.TUptadeAsync(counter);
            return RedirectToAction("Index");
        }
    }
}
