using Microsoft.EntityFrameworkCore;
using Test1_API.DTOs.CustomerDTO;
using Test1_API.Interfaces;
using Test1_API.Models;

namespace Test1_API.Services
{
    public class CustomerServices : ICustomer
    {
        private readonly TestDbContext _context;
        public CustomerServices(TestDbContext context)
        {
            _context = context;
        }

        public async Task<NewCustomerDTO> CreateNewCustomer(NewCustomerDTO input)
        {
            // Map NewCustomerDTO to Customer model  
            var newCustomer = new Customer
            {
                FullName = input.FullName,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
                CreatedAt = DateTime.Now,
            };
            await _context.Customers.AddAsync(newCustomer);
            await _context.SaveChangesAsync();

            // Return the DTO with updated information  
            return new NewCustomerDTO
            {
                FullName = newCustomer.FullName,
                Email = newCustomer.Email,
                PhoneNumber = newCustomer.PhoneNumber,
                CreatedAt = newCustomer.CreatedAt,
            };
        }

        public async Task<bool> DeleteCustomer(int Id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(x=>x.CustomerId == Id);
            if (customer == null)
            {
                return false;
            }

            _context.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CustomerInfoDTO>> Getallcustomers()
        {
            return await _context.Customers.Select(x => new CustomerInfoDTO
            {
                CustomerId = x.CustomerId,
                FullName = x.FullName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                CreatedAt = x.CreatedAt

            }).ToListAsync();
        }

        public async Task<List<CustomerInfoDTO>> GetcustomerbyID(int Id)
        {
            return await _context.Customers.Where(x => x.CustomerId == Id).Select(x => new CustomerInfoDTO
            {
                CustomerId = x.CustomerId,
                FullName = x.FullName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                CreatedAt = x.CreatedAt

            }).ToListAsync();
        }

        public async Task<List<CustomerDetailsDTO>> Getcustomerhaveorder()
        {
            var customer = from c in _context.Customers
                           join o in _context.Orders
                           on c.CustomerId equals o.CustomerId
                           select new CustomerDetailsDTO
                           {
                               CustomerId = c.CustomerId,
                               FullName = c.FullName,
                               Email = c.Email,
                               PhoneNumber = c.PhoneNumber,
                               CreatedAt = c.CreatedAt,
                               OrderId = o.OrderId

                           };
            return await customer.ToListAsync();
        }

        public async Task<List<CustomerDetailsAndOrderDTO>> GetcustomerWithtotalorder()
        {
            var customer = from c in _context.Customers
                           join o in _context.Orders
                           on c.CustomerId equals o.CustomerId
                           group o by new
                           {
                               c.CustomerId,
                               c.FullName,
                               c.Email,
                               c.PhoneNumber,
                               c.CreatedAt
                           } into g
                           select new CustomerDetailsAndOrderDTO
                           {
                               CustomerId = g.Key.CustomerId,
                               FullName = g.Key.FullName,
                               Email = g.Key.Email,
                               PhoneNumber = g.Key.PhoneNumber,
                               CreatedAt = g.Key.CreatedAt,
                               TotalOrder = g.Count() // Assuming you want the count of orders  
                           };
            return await customer.ToListAsync();
        }

        public async Task<CustomerInfoDTO> UpdateCustomer(UpdateCustomerDTO input)
        {
            var updateCustomer = await _context.Customers.Where(x => x.CustomerId == input.CustomerId).FirstOrDefaultAsync();
            if (updateCustomer == null)
            {
                return null;
            }

            updateCustomer.CustomerId = input.CustomerId;
            updateCustomer.FullName = input.FullName;
            updateCustomer.Email = input.Email;
            updateCustomer.PhoneNumber = input.PhoneNumber;
            updateCustomer.CreatedAt = input.CreatedAt;

            await _context.SaveChangesAsync();
            return new CustomerInfoDTO
            {
                CustomerId = updateCustomer.CustomerId,
                FullName = updateCustomer.FullName,
                Email = updateCustomer.Email,
                PhoneNumber = updateCustomer.PhoneNumber,
                CreatedAt = updateCustomer.CreatedAt,
            };
        }
    }
}
