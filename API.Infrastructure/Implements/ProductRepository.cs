using API.Core.DbModels;
using API.Core.Interfaces;
using API.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.System;

namespace API.Infrastructure.Implements
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context) 
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrand.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(x => x.ProductType)
                .Include(x => x.ProductBrand)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        /// <summary>
        /// all product list
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(x => x.ProductType)
                .Include(x => x.ProductBrand)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductType.ToListAsync();
        }
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync()
        {
            return await _context.ProductBrand.ToListAsync();
        }

        Task<Product> IProductRepository.GetProductByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<IReadOnlyList<Product>> IProductRepository.GetProductsAsync()
        {
            throw new System.NotImplementedException();
        }

        Task<IReadOnlyList<ProductType>> IProductRepository.GetProductTypesAsync()
        {
            throw new System.NotImplementedException();
        }

        Task<IReadOnlyList<ProductBrand>> IProductRepository.GetProductBrandsAsync()
        {
            throw new System.NotImplementedException();
        }



    }
}
