using API.Core.DbModels;
using API.Core.Interfaces;
using API.Infrastructure.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //private readonly StoreContext _context;
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var data = await _productRepository.GetProductsAsync();
            return Ok(data);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrands>>> GetProductBrands()
        {
            var data = await _productRepository.GetProductBrandsAsync();
            return Ok(data);
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductTypes>>> GetProductType()
        {
            var data = await _productRepository.GetProductTypesAsync();
            return Ok(data);
        }
    }
}
