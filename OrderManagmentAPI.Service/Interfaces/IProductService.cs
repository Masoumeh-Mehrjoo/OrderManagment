using OrderManagmentAPI.Model;
using OrderManagmentAPI.Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagmentAPI.Service.Interfaces
{
    public interface IProductService
    {
        public ProductDto  InsertProduct(ProductDtoForCreation product);

        public IEnumerable<ProductDto> AllRows();

        public ProductDto FindById(int Id);

        public IEnumerable<ProductDto> SearchedRows(ProductResourceParameter  productResourceParameter);

    }
}
