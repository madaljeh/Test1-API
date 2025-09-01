using Test1_API.DTOs.CustomerDTO;
using Test1_API.Models;

namespace Test1_API.Interfaces
{
    public interface ICustomer
    {
        Task<List<CustomerInfoDTO>> Getallcustomers();
        Task<List<CustomerInfoDTO>> GetcustomerbyID(int Id);
        Task<NewCustomerDTO> CreateNewCustomer(NewCustomerDTO input);
        Task<CustomerInfoDTO> UpdateCustomer(UpdateCustomerDTO input);
        Task<bool> DeleteCustomer(int Id);
        Task<List<CustomerDetailsDTO>> Getcustomerhaveorder();
        Task<List<CustomerDetailsAndOrderDTO>> GetcustomerWithtotalorder();
    }
}
