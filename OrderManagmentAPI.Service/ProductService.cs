using AutoMapper;
using OrderManagmentAPI.Model;
using OrderManagmentAPI.Model.Repository;
using OrderManagmentAPI.Repository;
using OrderManagmentAPI.Service.Dto;
using OrderManagmentAPI.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagmentAPI.Service
{
    public class ProductService : IProductService

    {
        IProductRepository _iProductRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this._iProductRepository = productRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public ProductDto InsertProduct(ProductDtoForCreation product)
        {
            try
            {
                var ProductRep = _mapper.Map<Model.Product>(product);
                _iProductRepository.Insert(ProductRep);

                var ProductToReturn = _mapper.Map<ProductDto>(ProductRep);
                return ProductToReturn;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ProductDto> AllRows()
        {
            try
            {
                var Rep_Products = _iProductRepository.AllRows();
                var products = new List<ProductDto>();

                var ProductsToReturn = _mapper.Map<IEnumerable<ProductDto>>(Rep_Products);
                return (ProductsToReturn);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ProductDto FindById(int Id)
        {
            var Rep_Product = _iProductRepository.findbyId(Id);
            var ProductToReturn = _mapper.Map<ProductDto>(Rep_Product);
            return (ProductToReturn);

        }

        public IEnumerable<ProductDto> SearchedRows(ProductResourceParameter productResourceParameter)
        {
            var Rep_Product = _iProductRepository.SearchedRows(productResourceParameter);
            var productToReturn = _mapper.Map<IEnumerable<ProductDto>>(Rep_Product);
            return (productToReturn);
        }
    }
}



