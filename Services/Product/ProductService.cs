// ProductService.cs

using AutoMapper;
using DTOs.Create;
using DTOs.Display;
using DTOs.Update;
using Models.Model;
using Repository.Contract;
using System.Collections.Generic;
using System.Linq;

namespace Services.Order
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository _productRepository, IMapper _mapper)
        {
            productRepository = _productRepository;
            mapper = _mapper;
        }

        public List<GetProductDTO> GetAll()
        {
            var Products = productRepository.GetAll().ToList();
            var mappedPrducts = mapper.Map<List<GetProductDTO>>(Products);
            return mappedPrducts;
        }

        public GetProductDTO GetOne(int ProductId)
        {
            var product = productRepository.GetOne(ProductId);
            var mappedproduct = mapper.Map<GetProductDTO>(product);
            return mappedproduct;
        }

        // ProductService.cs

        public List<GetProductDTO> Delete(int ProductId)
        {
            var productDeleted = productRepository.GetOne(ProductId);
            if (productDeleted == null)
            {
                // If the product with the given ID does not exist, return an empty list
                return new List<GetProductDTO>();
            }
            else
            {
                // Delete the product
                productRepository.Delete(productDeleted);

                // Get all products after deletion
                var remainingProducts = productRepository.GetAll().ToList();

                // Map remaining products to DTOs and return the list
                var remainingProductsDTO = mapper.Map<List<GetProductDTO>>(remainingProducts);
                return remainingProductsDTO;
            }
        }


        public ReturnProduct Create(CreateProductDTO product)
        {
            var productEntity = mapper.Map<Product>(product);
            productRepository.Create(productEntity);

            // Get the newly created product's ID
            int productId = productEntity.ProductId;

            // Create a new ReturnProduct object with the product ID and default status
            var createdProductDTO = new ReturnProduct
            {
                ProductId = productId,
                Status = "Created"
            };

            return createdProductDTO;
        }

        public ReturnProduct Update(UpdateProduct product, int ProductId)
        {
            var existingProductEntity = productRepository.GetOne(ProductId);

            var productUpdated = mapper.Map(product, existingProductEntity);


            productRepository.Update(productUpdated, ProductId);

            var response = new ReturnProduct
            {
                ProductId = productUpdated.ProductId,
                Status = "Updated"
            };

            return response;
        }
    }
}
