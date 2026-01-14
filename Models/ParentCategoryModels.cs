using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_LojaTricotllure.Models;

[Table("parent_category")]
public class ParentCategory
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("name")]
    public string? Name { get; set; }

    [Column("created_at", TypeName = "datetime(6)")]
    public DateTime? CreatedAt { get; set; }
}