namespace Test1_API.DTOs.CustomerDTO
{
    public class CustomerDetailsDTO
    {
        public int CustomerId { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime? CreatedAt { get; set; }
        public int OrderId { get; set; }
    }
}
