using Microsoft.AspNetCore.Mvc;
using OrderManagmentAPI.Model;
using OrderManagmentAPI.Repository;
using OrderManagmentAPI.Service;
using OrderManagmentAPI.Service.Dto;
using OrderManagmentAPI.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagmentAPI.Controllers
{
    [Route("api/Product")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        readonly IProductService _ProductService;
        public ProductController(IProductService productService)
        {
            _ProductService = productService;
        }
        [HttpPost]
        public IActionResult PostProduct(ProductDtoForCreation product)
        {
            var ProductToReturn = _ProductService.InsertProduct(product);
            return CreatedAtRoute("GetProductBYId", new { Id = ProductToReturn.id }, ProductToReturn);
        }
        [HttpGet()]
        public ActionResult GetProducts([FromQuery] ProductResourceParameter productResourceParameter)
        {
            if (productResourceParameter == null)
            {
                var AllProducts = _ProductService.AllRows();
                return new JsonResult(AllProducts);
            }
            else
            {
                var AllProducts = _ProductService.SearchedRows(productResourceParameter);
                return Ok(AllProducts);
            }
        }
        [HttpGet("{id}", Name = "GetProductBYId")]
        public ActionResult GetProductBYId(int Id)
        {
            var Product = _ProductService.FindById(Id);
            if (Product == null)
            {
                return NotFound("This Product Id is not exist in database.");

            }

            return Ok(Product);
        }
    }
}
