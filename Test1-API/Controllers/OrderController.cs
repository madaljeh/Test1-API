using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test1_API.DTOs.OrderDTO;
using Test1_API.Interfaces;
using Test1_API.Services;

namespace Test1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _orderService;
        public OrderController(IOrder orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var response = await _orderService.GetAllOrders();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllOrdersAndCustomerName()
        {
            try
            {
                var response = await _orderService.GetAllOrdersAndCustomerName();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrdersAndCustomer()
        {
            try
            {
                var response = await _orderService.GetOrdersAndCustomer();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrdersbyID(int Id)
        {
            try
            {
                var response = await _orderService.GetOrdersbyID(Id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrdersbyCustomerID(int Id)
        {
            try
            {
                var response = await _orderService.GetOrdersbyCustomerID(Id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateNewOrder(NewOrderDTO input)
        {
            try
            {
                var response = await _orderService.CreateNewOrder(input);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateOrder(UpdateOrderDTO input)
        {
            try
            {
                var response = await _orderService.UpdateOrder(input);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteOrder(int Id)
        {
            try
            {
                var response = await _orderService.DeleteOrder(Id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
