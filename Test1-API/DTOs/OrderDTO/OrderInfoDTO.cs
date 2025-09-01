namespace Test1_API.DTOs.OrderDTO
{
    public class OrderInfoDTO
    {
        public int OrderId { get; set; }

        public DateTime? OrderDate { get; set; }

        public decimal? TotalAmount { get; set; }

        public string? Status { get; set; }

        public int? CustomerId { get; set; }

    }
}
