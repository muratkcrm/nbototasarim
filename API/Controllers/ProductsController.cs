using API.Core.DbModels;
using API.Core.Interfaces;
using API.Core.Specifications;
using API.Dtos;
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

        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        public ProductsController(IGenericRepository<Product> productRepository, 
            IGenericRepository<ProductBrand> productBrandRepository, 
            IGenericRepository<ProductType> productTypeRepository)
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
        }

                [HttpGet]
        public async Task<ActionResult<List<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductsWithProductTypeAndBrandsSpecification();
            var data = await _productRepository.ListAsync(spec);
            //return Ok(data);

            return data.Select(pro => new ProductToReturnDto 
            {
                Id= pro.Id,
                Name= pro.Name,
                Description= pro.Description,
                Category= pro.Category,
                PictureUrl= pro.PictureUrl,
                Price= pro.Price,
                ProductBrand = pro.ProductBrand != null ? pro.ProductBrand.Name : string.Empty,
                ProductType = pro.ProductType != null ? pro.ProductType.Name : string.Empty,
            }).ToList();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var spec = new ProductsWithProductTypeAndBrandsSpecification(id);
            return await _productRepository.GetEntityWithSpec(spec);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand()
        {
            return Ok(await _productBrandRepository.ListAllAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductType()
        {
            var data = await _productTypeRepository.ListAllAsync();
            return Ok(data);
        }
    }
}
