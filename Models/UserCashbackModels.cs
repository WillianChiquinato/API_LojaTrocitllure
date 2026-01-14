using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_LojaTricotllure.Models;

[Table("user_cashback")]
public class UserCashback
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("user_id")]
    public int UserId { get; set; }
    
    [Column("order_id")]
    public int OrderId { get; set; }
    
    [Column("amount")]
    public int Amount { get; set; }
    
    [Column("is_used")]
    public bool IsUsed { get; set; }
    
    [Column("created_at", TypeName = "datetime(6)")]
    public DateTime? CreatedAt { get; set; }
    
    // 🔗 Relacionamentos
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    
    // 🔗 Relacionamentos
    [ForeignKey(nameof(OrderId))]
    public OrderPurchase OrderPurchase { get; set; }
}