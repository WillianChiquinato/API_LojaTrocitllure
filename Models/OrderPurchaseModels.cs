using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_LojaTricotllure.Models;

[Table("order_purchase")]
public class OrderPurchase
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("user_id")]
    public int UserId { get; set; }
    
    [Column("total_price")]
    public decimal TotalPrice { get; set; }
    
    [Column("is_shippingFree")]
    public bool IsShippingFree { get; set; }
    
    [Column("cashBack_applied")]
    public decimal CashBackApplied { get; set; }
    
    [Column("discount_applied")]
    public decimal DiscountApplied { get; set; }
    
    [Column("status")]
    public string? Status { get; set; }
    
    [Column("created_at", TypeName = "datetime(6)")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime(6)")]
    public DateTime? UpdatedAt { get; set; }
    
    // 🔗 Relacionamentos
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    
}