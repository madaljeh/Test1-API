using Test1_API.DTOs.OrderDTO;

namespace Test1_API.Interfaces
{
    public interface IOrder
    {
        Task<List<OrderInfoDTO>> GetAllOrders();
        Task<List<OrderInfoDTO>> GetOrdersbyID(int Id);
        Task<List<OrderInfoDTO>> GetOrdersbyCustomerID(int Id);
        Task<NewOrderDTO> CreateNewOrder(NewOrderDTO input);
        Task<UpdateOrderDTO> UpdateOrder(UpdateOrderDTO input);
        Task<bool> DeleteOrder(int Id);

        Task<List<OrderDetailsDTO>> GetAllOrdersAndCustomerName();
        Task<List<OrderAndCustomerDetailsDTO>> GetOrdersAndCustomer();
    }
}
