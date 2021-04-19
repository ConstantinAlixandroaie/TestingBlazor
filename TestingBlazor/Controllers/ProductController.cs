using CompletKitInstall.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingBlazor.Data.Acces;

namespace TestingBlazor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController:ControllerBase
    {
        private readonly IProductRepository _productRepo;

        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rv= await _productRepo.Get();
            return Ok(rv);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rv = await _productRepo.GetById(id);
            return Ok(rv);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel product)
        {
            var rv = await _productRepo.Add(product);
            return Ok(rv);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Update(int id, ProductViewModel product)
        {
            var rv = await _productRepo.Update(id, product);
            return Ok(rv);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rv = await _productRepo.RemoveById(id);
            return Ok(rv);
        }
    }
}
