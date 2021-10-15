using System.Collections.Generic;

using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandsRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productsRepo,
            IGenericRepository<ProductBrand> productBrandsRepo,
            IGenericRepository<ProductType> productTypeRepo,
            IMapper mapper)
        {
            _mapper = mapper;
            _productsRepo = productsRepo;
            _productBrandsRepo = productBrandsRepo;
            _productTypeRepo = productTypeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var product = await _productsRepo.ListAsync(spec);
            var result = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDTO>>(product);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDTO>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var result = await _productsRepo.GetEntityWithSpec(spec);
            var product = _mapper.Map<Product, ProductToReturnDTO>(result);
            return Ok(product);

        }

        [HttpGet("brands")]
        public async Task<ActionResult<ProductBrand>> GetProductBrands()
        {
            var result = await _productBrandsRepo.ListAllAsync();
            return Ok(result);

        }
        [HttpGet("types")]
        public async Task<ActionResult<ProductType>> GetProductTypes()
        {
            var result = await _productTypeRepo.ListAllAsync();
            return Ok(result);

        }

    }
}