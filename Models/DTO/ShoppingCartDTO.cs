namespace Api_LojaTricotllure.Models.DTO
{
    public class ShoppingCartDTO
    {
        public int Id { get; set; }
        public List<ShoppingCartItemDTO> Items { get; set; } = new List<ShoppingCartItemDTO>();
        public decimal TotalPrice { get; set; }
    }

    public class ShoppingCartItemDTO
    {
        public int ShoppingCartId { get; set; }
        public int ProductSkuId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}