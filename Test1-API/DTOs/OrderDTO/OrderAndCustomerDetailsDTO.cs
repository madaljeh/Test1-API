namespace Test1_API.DTOs.OrderDTO
{
    public class OrderAndCustomerDetailsDTO
    {
        public int OrderId { get; set; }

        public DateTime? OrderDate { get; set; }
        public string? Status { get; set; }
        public string? Email { get; set; }
    }
}
