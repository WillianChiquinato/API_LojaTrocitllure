using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_LojaTricotllure.Models;

[Table("shopping_cart_item")]
public class ShoppingCartItem
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("shoppingCart_id")]
    public int ShoppingCartId { get; set; }
    
    [Column("productSku_id")]
    public int ProductSkuId { get; set; }
    
    [Column("unit_price", TypeName = "decimal(10,2)")]
    public decimal UnitPrice { get; set; }
    
    [Column("quantity")]
    public int Quantity { get; set; }
    
    [Column("created_at", TypeName = "datetime(6)")]
    public DateTime? CreatedAt { get; set; }
    
    // 🔗 Relacionamentos
    [ForeignKey(nameof(ShoppingCartId))]
    public ShoppingCart ShoppingCart { get; set; }
    
    // 🔗 Relacionamentos
    [ForeignKey(nameof(ProductSkuId))]
    public ProductConsolidatedsSku ProductConsolidatedsSku { get; set; }
}