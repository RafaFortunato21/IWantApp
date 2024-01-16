using AutoMapper;
using IWantApp.Application.Contracts;
using IWantApp.Application.DTO;
using IWantApp.Domain.Entities;
using IWantApp.Infra.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantApp.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _productRepository  = productRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<ProductResponse> Add(ProductRequest productResponseDTO, string userCreate)
        {

            var category = await _categoryRepository.GetByIdAsync(productResponseDTO.CategoryId);
            var product = _mapper.Map<Product>(productResponseDTO);

            product.CreatedBy = userCreate.ToString();
            product.CreatedOn = DateTime.Now;

            product.EditedBy = userCreate.ToString();
            product.EditedOn = DateTime.Now;

            if (category == null)
                return null;
            
            product.CategoryId = category.Id;


            var productReturn = await _productRepository.CreateAsync(product);

            if (product == null)
                throw new Exception("Fail to return product");

            return _mapper.Map<ProductResponse>(productReturn);



        }

        public async Task<ProductResponse> GetById(Guid productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            var productDTO = _mapper.Map<ProductResponse>(product);

            return productDTO;
        }

        public async Task<IEnumerable<ProductResponse>> GetProducts()
        {
            var products = await _productRepository.GetProductsAsync();
            
            var productsDTO = _mapper.Map<List<ProductResponse>>(products);

            return productsDTO;
        }
    }
}
