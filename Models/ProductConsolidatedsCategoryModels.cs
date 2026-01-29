using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_LojaTricotllure.Models;

[Table("product_consolidateds_category")]
public class ProductConsolidatedsCategory
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("parent_id")]
    public int? ParentId { get; set; }
    
    [Column("name")]
    public string? Name { get; set; }
    
    [Column("slug")]
    public string? Slug { get; set; }
    
    [Column("is_active")]
    public bool IsActive { get; set; }
    
    [Column("created_at", TypeName = "datetime(6)")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime(6)")]
    public DateTime? UpdatedAt { get; set; }
    
    // 🔗 Relacionamentos
    [ForeignKey(nameof(ParentId))]
    public ParentCategory Parent { get; set; }
}