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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _order;
        public OrderController(IOrderRepository order)
        {
            _order = order ??
                throw new ArgumentNullException(nameof(order));
        }
        [HttpGet]
        [Route("GetOrder")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _order.GetOrder());
        }
        //[HttpGet]
        //[Route("GetDepartmentByID/{Id}")]
        //public async Task<IActionResult> GetDeptById(int Id)
        //{
        //    return Ok(await _department.GetDepartmentByID(Id));
        //}
        [HttpPost]
        [Route("AddOrder")]
        public async Task<IActionResult> Post(Order ord)
        {
            ord.OrderDate = System.DateTime.Now;
            var result = await _order.InsertOrder(ord);
            if (result.OrderID == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }
        [HttpPut]
        [Route("UpdateOrder")]
        public async Task<IActionResult> Put(Order ord)
        {
            await _order.UpdateOrder(ord);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        [HttpDelete("{id}")]
        [Route("DeleteOrder")]
        public JsonResult Delete(int id)
        {

            _order.DeleteOrder(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
