using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test1_API.DTOs.CustomerDTO;
using Test1_API.Interfaces;
using Test1_API.Services;

namespace Test1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customerServices;
        public CustomerController(ICustomer customerServices)
        {
            _customerServices = customerServices;
        }

        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> Getallcustomers()
        {
            try
            {
                var response = await _customerServices.Getallcustomers();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetcustomerbyID")]
        public async Task<IActionResult> GetcustomerbyID([FromHeader] int Id)
        {
            try
            {
                var response = await _customerServices.GetcustomerbyID(Id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Getcustomerhaveorder()
        {
            try
            {
                var response = await _customerServices.Getcustomerhaveorder();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetcustomerWithtotalorder()
        {
            try
            {
                var response = await _customerServices.GetcustomerWithtotalorder();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateNewCustomer(NewCustomerDTO input)
        {
            try
            {
                var response = await _customerServices.CreateNewCustomer(input);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDTO input)
        {
            try
            {
                var response = await _customerServices.UpdateCustomer(input);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteCustomer(int Id)
        {
            try
            {
                var response = await _customerServices.DeleteCustomer(Id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
