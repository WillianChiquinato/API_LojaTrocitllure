using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_LojaTricotllure.Models;

[Table("product_consolidateds")]
public class ProductConsolidateds
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("category_id")]
    public int CategoryId { get; set; }
    
    [Column("name")]
    public string? Name { get; set; }
    
    [Column("description")]
    public string? Description { get; set; }
    
    [Column("is_active")]
    public bool IsActive { get; set; }
    
    [Column("sold_out_count")]
    public int SoldOutCount { get; set; }
    
    [Column("created_at", TypeName = "datetime(6)")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime(6)")]
    public DateTime? UpdatedAt { get; set; }
    
    // 🔗 Relacionamentos
    [ForeignKey(nameof(CategoryId))]
    public ProductConsolidatedsCategory Category { get; set; }
}