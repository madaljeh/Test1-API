using Microsoft.EntityFrameworkCore;
using Test1_API.DTOs.OrderDTO;
using Test1_API.Interfaces;
using Test1_API.Models;

namespace Test1_API.Services
{
    public class OrderServices: IOrder
    {
        private readonly TestDbContext _context;
        public OrderServices(TestDbContext context)
        {
            _context = context;
        }

        public async Task<NewOrderDTO> CreateNewOrder(NewOrderDTO input)
        {
            var order = new Order
            {
                OrderDate = input.OrderDate,
                TotalAmount = input.TotalAmount,
                Status = input.Status,
                CustomerId = input.CustomerId,
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return new NewOrderDTO
            {
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                CustomerId = order.CustomerId,
            };
        }

        public async Task<bool> DeleteOrder(int Id)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(x=> x.OrderId==Id);
            if(order == null)
            {
                return false;
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<OrderInfoDTO>> GetAllOrders()
        {
            return await _context.Orders.Select(x=> new OrderInfoDTO
            {
                OrderId=x.OrderId,
                OrderDate = DateTime.Now,
                CustomerId = x.CustomerId,
                TotalAmount = x.TotalAmount,
                Status = x.Status,
            }).ToListAsync();
        }

        public async Task<List<OrderDetailsDTO>> GetAllOrdersAndCustomerName()
        {
            var ordersWithCustomerNames = from o in _context.Orders
                                          join c in _context.Customers
                                          on o.CustomerId equals c.CustomerId
                                          select new OrderDetailsDTO
                                          {
                                              OrderId = o.OrderId,
                                              OrderDate = DateTime.Now,
                                              CustomerId = o.CustomerId,
                                              TotalAmount = o.TotalAmount,
                                              Status = o.Status,
                                              FullName = c.FullName,
                                          };

            return await ordersWithCustomerNames.ToListAsync();
        }

        public async Task<List<OrderAndCustomerDetailsDTO>> GetOrdersAndCustomer()
        {
                           var resulte =  from o in _context.Orders
                                          join c in _context.Customers
                                          on o.CustomerId equals c.CustomerId
                                          select new OrderAndCustomerDetailsDTO
                                          {
                                              OrderId = o.OrderId,
                                              OrderDate = DateTime.Now,
                                              Status = o.Status,
                                              Email=c.Email,
                                              
                                          };

            return await resulte.ToListAsync();
        }

        public async Task<List<OrderInfoDTO>> GetOrdersbyCustomerID(int Id)
        {
            return await _context.Orders.Where(x => x.CustomerId == Id).Select(x => new OrderInfoDTO
            {
                OrderId = x.OrderId,
                OrderDate = DateTime.Now,
                CustomerId = x.CustomerId,
                TotalAmount = x.TotalAmount,
                Status = x.Status,
            }).ToListAsync();
        }

        public async Task<List<OrderInfoDTO>> GetOrdersbyID(int Id)
        {
            return await _context.Orders.Where(x => x.OrderId == Id).Select(x => new OrderInfoDTO
            {
                OrderId = x.OrderId,
                OrderDate = DateTime.Now,
                CustomerId = x.CustomerId,
                TotalAmount = x.TotalAmount,
                Status = x.Status,
            }).ToListAsync();
        }

        public async Task<UpdateOrderDTO> UpdateOrder(UpdateOrderDTO input)
        {
            var order = await _context.Orders.Where(x => x.OrderId == input.OrderId).FirstOrDefaultAsync();
            if (order == null)
            {
                return null;
            }

            order.OrderId = input.OrderId;
            order.OrderDate = DateTime.Now;
            order.TotalAmount = input.TotalAmount;
            order.Status = input.Status;

            await _context.SaveChangesAsync();
            return new UpdateOrderDTO
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status,

            };

        }
    }
}