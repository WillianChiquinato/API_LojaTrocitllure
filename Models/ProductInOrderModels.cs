using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_LojaTricotllure.Models;

[Table("product_in_order")]
public class ProductInOrder
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("order_id")]
    public int OrderId { get; set; }
    
    [Column("productSku_id")]
    public int ProductId { get; set; }
    
    [Column("product_name")]
    public string? ProductName { get; set; }
    
    [Column("color")]
    public string? Color { get; set; }
    
    [Column("size")]
    public string? Size { get; set; }
    
    [Column("unit_price")]
    public decimal UnitPrice { get; set; }
    
    [Column("quantity")]
    public int Quantity { get; set; }
}