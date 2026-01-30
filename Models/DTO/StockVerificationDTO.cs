namespace Api_LojaTricotllure.Models.DTO
{
    public class StockVerificationDTO
    {
        public int ProductId { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public int AvailableStock { get; set; }
        public bool IsStockSufficient { get; set; }
    }
}