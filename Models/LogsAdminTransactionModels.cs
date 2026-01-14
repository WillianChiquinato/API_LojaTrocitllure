using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_LojaTricotllure.Models;

[Table("logsAdmin_transaction")]
public class LogsAdminTransaction
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("admin_id")]
    public int AdminId { get; set; }
    
    [Column("created_at", TypeName = "datetime(6)")]
    public DateTime? CreatedAt { get; set; }
    
    // 🔗 Relacionamentos
    [ForeignKey(nameof(AdminId))]
    public AdminUser Admin { get; set; }
}