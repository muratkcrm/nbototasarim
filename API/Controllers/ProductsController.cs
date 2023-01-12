﻿using API.Core.DbModels;
using API.Core.Interfaces;
using API.Core.Specifications;
using API.Dtos;
using API.Helpers;
using API.Infrastructure.DataContext;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.System;

namespace API.Controllers
{

    public class ProductsController : BaseApiController
    {

        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        private readonly IGenericRepository<UserApi> _userRepository;

        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepository, 
            IGenericRepository<ProductBrand> productBrandRepository,
            IGenericRepository<UserApi> userRepository,
            IGenericRepository<ProductType> productTypeRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery]ProductSpecParams productSpecParams)
        {
            var spec = new ProductsWithProductTypeAndBrandsSpecification(productSpecParams);
            var countSpec = new ProductWithFiltersForCountSpecification(productSpecParams);
            var totalItems = await _productRepository.CountAsync(spec);
            var products = await _productRepository.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);

            return Ok(new Pagination<ProductToReturnDto>(productSpecParams.PageIndex, productSpecParams.PageSize, totalItems, data));

        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithProductTypeAndBrandsSpecification(id);
            var product = await _productRepository.GetEntityWithSpec(spec);
            return _mapper.Map<Product, ProductToReturnDto>(product);
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
        //[HttpGet("Users")]
        //public async Task<ActionResult<IReadOnlyList<UserApi>>> GetUsers() { 
        //    var data = await _userRepository.ListAllAsync();
        //    return Ok(data);
        //}

    }
}
