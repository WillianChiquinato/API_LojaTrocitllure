namespace Api_LojaTricotllure.Models.DTO;

public class ShoppingCartRequest
{
    public int UserId { get; set; }
    public string SessionId { get; set; } = string.Empty;
    public List<ShoppingProductRequest> Products { get; set; } = new List<ShoppingProductRequest>();
}

public class ShoppingProductRequest
{
    public int ProductId { get; set; }
    public string Size { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public int Quantity { get; set; }
}