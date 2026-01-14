using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_LojaTricotllure.Models;

[Table("admin_user")]
public class AdminUser
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("is_active")]
    public bool IsActive { get; set; }
    
    [Column("login")]
    public string Login { get; set; }
    
    [Column("password")]
    public string Password { get; set; }
    
    [Column("created_at", TypeName = "datetime(6)")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime(6)")]
    public DateTime? UpdatedAt { get; set; }
}