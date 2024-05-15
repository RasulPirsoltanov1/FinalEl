using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.ProductDtos;
using Villa.Entity.Entites;

namespace Villa.WebUi.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService=productService;
            _mapper=mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _productService.TGetListAsync();
            var valueList = _mapper.Map<List<ResultProductDto>>(values);
            return View(valueList);
        }

        public async Task<IActionResult> DeleteProduct(ObjectId id)
        {
            await _productService.TDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var newValue = _mapper.Map<Product>(createProductDto);
            await _productService.TCreateAsync(newValue);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UptadeProduct(ObjectId id)
        {
            var value = await _productService.TGetByIdAsync(id);
            var uptadeValue = _mapper.Map<UpdateProductDto>(value);
            return View(uptadeValue);
        }

        [HttpPost]
        public async Task<IActionResult> UptadeProduct(UpdateProductDto uptadeProductDto)
        {
            var uptadeValue = _mapper.Map<Product>(uptadeProductDto);
            await _productService.TUptadeAsync(uptadeValue);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ProductDetails(ObjectId id)
        {
            var value = await _productService.TGetByIdAsync(id);
            var product=_mapper.Map<ResultProductDto>(value);
            return View(product);
        }
    }
}
