using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Retailshop.Models;
using Retailshop.Repository;

namespace Retailshop.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _product;
        public ProductController(IProductRepository product)
        {
            _product = product ??
                throw new ArgumentNullException(nameof(product));
        }
        [HttpGet]
        [Route("GetProduct")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _product.GetProduct());
        }
        [HttpGet]
        [Route("GetProductByID/{Id}")]
        public async Task<IActionResult> GetProductByID(int Id)
        {
            return Ok(await _product.GetProductByID(Id));
        }
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> Post(Product prod)
        {
            var result = await _product.InsertProduct(prod);
            if (result.ProdID == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }
        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> Put(Product prod)
        {
            await _product.UpdateProduct(prod);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        [HttpDelete("{id}")]
        [Route("DeleteProduct")]
        public JsonResult Delete(int id)
        {
            _product.DeleteProduct(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
