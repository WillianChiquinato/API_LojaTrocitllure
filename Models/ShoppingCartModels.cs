using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_LojaTricotllure.Models;

[Table("shopping_cart")]
public class ShoppingCart
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("session_id")]
    public string SessionId { get; set; }

    [Column("created_at", TypeName = "datetime(6)")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime(6)")]
    public DateTime? UpdatedAt { get; set; }
    
    // 🔗 Relacionamentos
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
}