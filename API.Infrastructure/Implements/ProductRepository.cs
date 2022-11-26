using API.Core.DbModels;
using API.Core.Interfaces;
using API.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Infrastructure.Implements
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context) 
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductBrands>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductBrands)
                .Include(p => p.ProductTypes)
                .FirstOrDefaultAsync(p=> p.Id == id);
        }
        /// <summary>
        /// all product list
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(p => p.ProductBrands)
                .Include(p => p.ProductTypes)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductTypes>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}
