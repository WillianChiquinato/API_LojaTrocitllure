using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_LojaTricotllure.Models;

[Table("product_consolidateds_sku")]
public class ProductConsolidatedsSku
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("product_id")]
    public int ProductId { get; set; }
    
    [Column("sku_code")]
    public string? SkuCode { get; set; }
    
    [Column("color")]
    public string? Color { get; set; }
    
    [Column("size")]
    public string? Size { get; set; }
    
    [Column("price", TypeName = "decimal(10,2)")]
    public decimal? Price { get; set; }
    
    [Column("stock")]
    public int? Stock { get; set; }
    
    [Column("is_active")]
    public bool IsActive { get; set; }
    
    [Column("created_at", TypeName = "datetime(6)")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime(6)")]
    public DateTime? UpdatedAt { get; set; }
    
    // 🔗 Relacionamentos
    [ForeignKey(nameof(ProductId))]
    public ProductConsolidateds Product { get; set; }
}